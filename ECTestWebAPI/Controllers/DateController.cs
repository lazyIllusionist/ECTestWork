using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECTestWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECTestWebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DateController : ControllerBase
    {
        [HttpGet("{startDate, endDate}", Name = nameof(GetInnerDates))]
        public async Task<ActionResult<DateIntervalResponse>> GetInnerDates(string startDate, string endDate)
        {
            return null;
        }

        [HttpPost(Name = nameof(AddDate))]
        public async Task<IActionResult> AddDate([FromBody] DateIntervalForm form)
        {
            return null;
        }
    }
}