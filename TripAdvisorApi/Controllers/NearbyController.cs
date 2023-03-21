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
    public class NearbyController : ApiController
    {
        NearbyHelper nearbyhelper = new NearbyHelper();
        // GET: api/Nearby
        public List<t_nearby> Get()
        {
            return nearbyhelper.GetAll();
        }

        // GET: api/Nearby/5
        public t_nearby Get(int id)
        {
            return nearbyhelper.GetOne(id);
        }

        // POST: api/Nearby
        public bool Post([FromBody]t_nearby near)
        {
            return nearbyhelper.Add(near);
        }

        // PUT: api/Nearby/5
        public bool Put([FromBody]t_nearby near)
        {
            return nearbyhelper.Update(near);
        }

        // DELETE: api/Nearby/5
        public bool Delete(int id)
        {
            return nearbyhelper.Delete(id);
        }
    }
}
