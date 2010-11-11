using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Repositories;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private AttendeeRepository _repository = null;
        public HomeController()
        {
            _repository = new AttendeeRepository() { Settings = Settings };
        }

        public ActionResult Index(string hashTag)
        {
            HomeViewModel viewModel = new HomeViewModel();
            
            var allAttendees = _repository.FindAll();

            var selectAttendees = _repository.Find(new { Tags = hashTag });
            
            // Buid the tag tree. There are, obviously, more graceful ways to do this - but we're in a rush here.
            Dictionary<string, int> keys = new Dictionary<string,int>();

            foreach (var attendee in allAttendees)
            {
                foreach (var tag in attendee.Tags)
                {
                    if (tag != null)
                    {
                        if (keys.ContainsKey(tag))
                        {
                            keys[tag]++;
                        }
                        else
                        {
                            keys.Add(tag, 1);
                        }
                    }
                }
            }

            viewModel.Attendees = selectAttendees;
            viewModel.Hashtags = keys;

            return View(viewModel);
        }

        public ActionResult User(string Id)
        {
            var twitterUser =  _repository.FindById(Id);
            return View(twitterUser);
        }

        public ViewResult SelectUsers(string hashTag)
        {
            HomeViewModel viewModel = new HomeViewModel();

            var selectAttendees = _repository.Find(new { Tags = hashTag });

            viewModel.Attendees = selectAttendees;

            return View("UserList", viewModel);
        }
        

        public ActionResult Test()
        {
            for (int i = 0; i < 100; i++)
            {
                Attendee attendee = new Attendee { Name = "Some Guy", TwitterURL = "http://twitter.com/jptoto", AvatarURL = "http://a2.twimg.com/profile_images/1158960374/bc_normal.png" };
                string[] tagArray = new string[10];
                tagArray[0] = "developer";
                tagArray[1] = "designer";
                tagArray[2] = "asp.net";

                attendee.Tags = tagArray;
                _repository.Create(attendee);
            }
                return View("Index");
        }
    }
}
