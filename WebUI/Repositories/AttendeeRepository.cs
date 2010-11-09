using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.Repositories
{
    public class AttendeeRepository : NoRMRepositoryBase<Attendee>
    {
        protected override string _Collection
        {
            get { return "Attendees"; }
        }
    }
}