using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserRepository _UserRepo;
        public RegisterController(IUserRepository UserRepo){
            _UserRepo =UserRepo;
        }
        [HttpPost]
        public ActionResult Post([FromBody]t_user value)
        {

           _UserRepo.Register(value);
         return Ok();
        }
    }
}