using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class t_place
    {
        public int c_placeid { get; set; }

        public string c_placename { get; set; }

        public string c_description { get; set; }

        public string c_placeimage { get; set; }

        public string c_preferedmonths { get; set; }
    }
}