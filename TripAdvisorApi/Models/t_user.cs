using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripAdvisorApi.Models
{
    public class t_user
    {
        public int c_userid { get; set; }

        public string c_username { get; set; }

        public string c_email { get; set; }

        public string c_pass { get; set; }

        public string c_address { get; set; }

        public string c_gender { get; set; }

        public int c_cityid { get; set; }

        public int c_mobile { get; set; }

        public string c_uimage { get; set; }
    }
}