using Application;
using Interfaces.WebAPI.Assembler;
using Interfaces.WebAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Interfaces.WebAPI.Controllers
{
    public class PersonApiController : ControllerBase
    {
        readonly ILogger<LeaveApiController> _logger;
        readonly IPersonApplicationService _personApplicationService;
        public PersonApiController(IPersonApplicationService personApplicationService, ILogger<LeaveApiController> logger)
        {
            _logger = logger;
            _personApplicationService = personApplicationService;
        }
        [HttpPost("/person")]
        public IActionResult Create([FromBody]PersonDTO personDTO)
        {
            try
            {
                _personApplicationService.Create(PersonAssembler.ToDO(personDTO));
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new NotFoundResult();
            }
        }

        [HttpPut]
        public IActionResult Update(PersonDTO personDTO)
        {
            try
            {
                _personApplicationService.Update(PersonAssembler.ToDO(personDTO));
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new NotFoundResult();
            }
        }

        [HttpDelete("/{personId}")]
        public IActionResult Delete(string personId)
        {
            _personApplicationService.DeleteById(personId);
            return Ok();
        }

        [HttpGet("/{personId}")]
        public IActionResult Get(string personId)
        {
            var person = _personApplicationService.FindById(personId);
            return Ok(PersonAssembler.ToDTO(person));
        }

        [HttpGet("/findFirstApprover")]
        public IActionResult FindFirstApprover(string applicantId, int leaderMaxLevel)
        {
            var person = _personApplicationService.FindFirstApprover(applicantId, leaderMaxLevel);
            return Ok(PersonAssembler.ToDTO(person));
        }
    }
}
