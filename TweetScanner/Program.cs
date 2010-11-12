using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Web;
using WebUI.Infrastructure;
using WebUI.Models;
using WebUI.Repositories;

namespace TweetScanner
{
    class Program
    {
        protected static MongoDBSettings Settings { get; set; }
        static Program() {
            Settings = new MongoDBSettings() {
                Server = "localhost",
                Database = "OhaiBarcamp",
                Port = 27017                
            };
        }

        static void Main(string[] args)
        {

            AttendeeRepository _repository = new AttendeeRepository() { Settings = Settings };

            var input = "@barcampphilly #ohai";
            
            var scrubbed = HttpUtility.UrlEncode(input);
            var reader = XmlReader.Create(string.Format("http://search.twitter.com/search.atom?&q={0}&rpp=100", scrubbed));
            var feed = SyndicationFeed.Load(reader);

            // Order these backwards so we allways do the newest feeds list since I suck at upserts
            foreach (SyndicationItem item in feed.Items.OrderBy(x=>x.Id))
            {
                Attendee attendee = new Attendee { Name = item.Authors[0].Name, TwitterURL = item.Authors[0].Uri, AvatarURL = item.Links[1].Uri.AbsoluteUri };
                
                // This whole situation here is cheese. C# arrays are annoying.
                string tweet = item.Title.Text;
                string[] tweetTags = tweet.Split(' ');
                string[] userTags = new string[20];
                int i = 0;
                foreach (string tag in tweetTags)
                {
                    if (tag.Contains("#") && (!tag.Contains("#ohai")))
                    {
                        userTags[i] = tag.Replace("#","");
                        i++;
                    }
                }

                attendee.Tags = userTags;

                // Really should try and get upserts working. Stop sucking already, Toto!
                _repository.Remove(new { TwitterURL = attendee.TwitterURL });
                _repository.Create(attendee);
            }

        }
    }

    public class AttendeeCollection : System.Collections.CollectionBase
    {
        public void Add(Attendee attendee)
        {
            List.Add(attendee);
        }
    }
}
