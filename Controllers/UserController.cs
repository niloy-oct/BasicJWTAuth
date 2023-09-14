using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicJWTAuth.Models;
using BasicJWTAuth.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace BasicJWTAuth.Controllers
{
	[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public UsersController(IJWTManagerRepository jWTManager)
        {
            this._jWTManager = jWTManager;
        }

        [HttpGet]
        [Route("UserList")]
        public List<string> Get()
        {
            var users = new List<string>
            {
                "Mahedi Hasan Niloy",
                "Software Engineer",
                "Healthcare Pharmaceuticals Limited"
            };

            return users;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(User usersdata)
        {
            var token = _jWTManager.AuthenticateTokes(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
