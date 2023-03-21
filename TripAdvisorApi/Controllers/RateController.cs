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
    public class RateController : ApiController
    {
        RateHelper rh = new RateHelper();
        // GET: api/Rate
 
        public List<t_rate> Get()
        {
            return rh.GetAll();
        }
        // GET: api/Rate/5
      
        public t_rate Get(int id)
        {
            return rh.GetOne(id);
        }

        // POST: api/Rate
        public void Post([FromBody]t_rate value)
        {
            rh.Insert(value);
        }

        // PUT: api/Rate/5
        public void Put(int id, [FromBody]t_rate value)
        {
            rh.Update(value);
        }

        // DELETE: api/Rate/5
        public void Delete(int id)
        {
            rh.Delete(id);
        }
    }
}
