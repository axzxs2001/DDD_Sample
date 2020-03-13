using Application;
using Interfaces.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginApiController : ControllerBase
    {
        readonly ILoginApplicationService _loginApplicationService;
        public LoginApiController(ILoginApplicationService loginApplicationService)
        {
            _loginApplicationService = loginApplicationService;
        }

        public IActionResult Login(PersonDTO personDTO)
        {           
            return Ok();
        }
    }
}
