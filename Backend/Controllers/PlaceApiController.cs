using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceApiController : ControllerBase
    {
        private readonly IPlaceRepository _placeRepository;

        // Constructor Injection
        public PlaceApiController(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        // GET: api/PlaceApi
        [HttpGet]
        public List<t_place> Get()
        {
            return _placeRepository.GetAll();
        }

        // GET: api/PlaceApi/2
        [HttpGet("{id}")]
        public t_place Get(int id)
        {
            return _placeRepository.GetOne(id);
        }

        // POST: api/PlaceApi
        [HttpPost]
        public bool Post([FromBody]t_place place)
        {
            return _placeRepository.Add(place);
        }

        // PUT: api/PlaceApi
        [HttpPut]
        public bool Put([FromBody]t_place place)
        {
            return _placeRepository.Update(place);
        }

        // DELETE: api/PlaceApi/2
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _placeRepository.Delete(id);
        }
    }
}