using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TripAdvisorApi.Models;
using TripAdvisorApi.Bal;

namespace TripAdvisorApi.Controllers
{
    public class PlaceController : ApiController
    {
        PlaceHelper placeHelper = new PlaceHelper();

        // GET: api/Place
        public List<t_place> Get()
        {
            return placeHelper.GetAll();
        }

        // GET: api/Place/5
        public t_place Get(int id)
        {
            return placeHelper.GetOne(id);
        }

        // POST: api/Place
        public bool Post([FromBody]t_place place)
        {
            return placeHelper.Add(place);
        }

        // PUT: api/Place/5
        public bool Put([FromBody]t_place place)
        {
            return placeHelper.Update(place);
        }

        // DELETE: api/Place/5
        public bool Delete(int id)
        {
            return placeHelper.Delete(id);
        }
    }
}
