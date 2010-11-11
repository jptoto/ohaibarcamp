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

        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            
            var allAttendees = _repository.FindAll();
            
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

            viewModel.Attendees = allAttendees;
            viewModel.Hashtags = keys;

            return View(viewModel);
        }

        public ActionResult User(string Id)
        {
            var twitterUser =  _repository.FindById(Id);
            return View(twitterUser);
        }
    }
}
