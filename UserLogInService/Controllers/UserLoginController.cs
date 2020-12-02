using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using UserLogInService.Services;
using UserLogInService.Model;
using UserLogInService.Helper;
using UserLogInService.Entities;


namespace UserLogInService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        

        public UserLoginController(IUserService userService , IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
       
        // GET: api/UserLogin
        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = _userService.GetAll().ToList();
            List<UserModel> usersModel = _mapper.Map<List<UserModel>>(users);
            return Ok(usersModel);
        }

        // GET: api/UserLogin/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserLogin
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/UserLogin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
