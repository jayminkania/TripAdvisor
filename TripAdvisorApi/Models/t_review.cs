﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripAdvisorApi.Models
{
    public class t_review
    {
        public int c_reviewid { get; set; }
        public int c_userid { get; set; }
        public int c_nearbyid { get; set; }
        public DateTime c_reviewdate { get; set; }
        public string c_review { get; set; }
    }
}