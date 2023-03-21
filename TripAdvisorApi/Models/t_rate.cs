using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripAdvisorApi.Models
{
    public class t_rate
    {
        public int c_rateid { get; set; }
        public int c_userid { get; set; }
        public int c_nearbyid { get; set; }
        public DateTime c_ratedate { get; set; }
        public int c_rate { get; set; }
    }
}