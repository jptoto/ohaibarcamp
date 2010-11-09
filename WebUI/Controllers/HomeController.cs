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
            string[] tagArray = new string[10];
            tagArray[0] = "developer";
            tagArray[1] = "designer";
            tagArray[2] = "asp.net";

            Attendee attendee = new Attendee();
            attendee.Name = "JP Toto";
            attendee.TwitterURL = "http://twitter.com/jptoto";
            attendee.AvatarURL = "http://a2.twimg.com/profile_images/1158960374/bc_normal.png";
            attendee.Tags = tagArray;

            return View();
        }

    }
}
