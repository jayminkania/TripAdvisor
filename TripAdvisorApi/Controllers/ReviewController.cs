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
    public class ReviewController : ApiController
    {
        // GET: api/ReviewApi
        ReviewHelper rh = new ReviewHelper();
        public List<t_review> Get()
        {
            List<t_review> ReviewAll = rh.GetAllReview();
            return ReviewAll;
        }

        // GET: api/ReviewApi/5
        public t_review Get(int id)
        {
            t_review review = rh.GetOne(id);
            return review;
        }

        // POST: api/ReviewApi
        public bool Post([FromBody]t_review value)
        {
           return rh.Add(value);
        }

        // PUT: api/ReviewApi/5
        public bool Put( [FromBody]t_review value)
        {
           return rh.Update(value);
        }

        // DELETE: api/ReviewApi/5
        public bool Delete(int id)
        {
           return rh.Delete(id);
        }
    }
}
