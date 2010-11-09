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
        static void Main(string[] args)
        {

            var input = "jptoto";
            
            var scrubbed = HttpUtility.UrlEncode(input);
            var reader = XmlReader.Create(
                    string.Format("http://search.twitter.com/search.atom?lang=en&q={0}&page=1&rpp=1", scrubbed));
            var feed = SyndicationFeed.Load(reader);

            foreach (SyndicationItem item in feed.Items)
            {
                Console.WriteLine("\t{0} - {1}", item.Authors[0].Name, item.Title.Text, item.Content.ToString());
            }



            
        }
    }
}
