using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECTestWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECTestWebAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = "work !";
            return Ok(response); //TODO: make it normal
        }
    }
}