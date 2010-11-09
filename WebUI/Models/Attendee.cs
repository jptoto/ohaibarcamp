using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure;

namespace WebUI.Models
{
    public class Attendee : NoRMModelBase
    {
        public string Name { get; set; }
        public string AvatarURL { get; set; }
        public string TwitterURL { get; set; }
        public string[] Tags { get; set; }
    }
}