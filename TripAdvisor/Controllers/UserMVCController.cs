using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TripAdvisor.Controllers
{
    public class UserMVCController : Controller
    {
        // GET: UserMVC
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public bool SetSession(int userid, string username)
        {
            Session["userid"] = userid;
            Session["username"] = username;
            return true;
        }

        public bool Logout()
        {
            Session.Abandon();
            return true;
        }
    }
}