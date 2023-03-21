using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TripAdvisorApi.Bal;
using TripAdvisorApi.Models;

namespace TripAdvisorApi.Controllers
{
    public class UserController : ApiController
    {
        UserHelper uh = new UserHelper();
        CityHelper ch = new CityHelper();
        // POST: api/User
        [HttpPost]
        [Route("~/api/User/Register")]
        public string Register([FromBody]t_user value)
        {
            string message;
            if(uh.Register(value))
            {
                message = "Register Succefull";
                
            }
            else
            {
                message = "Email is already Exits!";
            }
            return message;
           
        }

        // POst: api/User/5
        [HttpPost]
        [Route("~/api/User/Login")]
        public t_user Login([FromBody]VM_login value)
        {
          
            return uh.Login(value);
        }
        [HttpGet]
        [Route("~/api/User/CityList")]
        public List<t_city> CityList()
        {
           return  ch.GetAll();
        }


    }
}
