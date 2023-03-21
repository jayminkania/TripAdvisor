using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripAdvisorApi.Models
{
    public class t_nearby
    {
        public int c_nearbyid { get; set; }

        public string c_description { get; set; }

        public int c_placeid { get; set; }

        public  string c_daystovisit { get; set; }

        public string c_timetovisit { get; set; }
    }
}