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


            return View();
        }

    }
}
