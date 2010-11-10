using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class HomeViewModel
    {
        public IQueryable<Attendee> Attendees { get; set; }
    }
}