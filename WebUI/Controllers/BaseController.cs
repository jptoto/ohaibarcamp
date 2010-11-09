using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Infrastructure;

namespace WebUI.Controllers
{
    public class BaseController : Controller
    {
        static BaseController() {
            Settings = new MongoDBSettings() {
                Server = "localhost",
                Database = "OhaiBarcamp",
                Port = 27017                
            };
        }

        protected static MongoDBSettings Settings { get; set; }
    }
}
