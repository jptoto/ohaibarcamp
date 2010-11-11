using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Attendee> Attendees { get; set; }
        public Dictionary<string, int> Hashtags { get; set; }
    }
}
