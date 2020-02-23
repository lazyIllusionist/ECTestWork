using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECTestWebAPI.Models;
using ECTestWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECTestWebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DateController : ControllerBase
    {
        IDateService _service;
        IValidationService _validator;
        public DateController(IDateService service, IValidationService validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpPut(Name = nameof(GetInnerDates))]
        public async Task<ActionResult<IEnumerable<DateInterval>>> GetInnerDates([FromBody] DateIntervalForm form)
        {
            try
            {
                if (await _validator.ValidateAsync(form))
                    return Ok(await _service.GetIntervalsAsync(form));
            }
            catch(ArgumentException e) { }
            return new BadRequestResult();
        }

        [HttpPost(Name = nameof(AddDateInterval))]
        public async Task<IActionResult> AddDateInterval([FromBody] DateIntervalForm form)
        {
           if (await _validator.ValidateAsync(form))
            {
                await _service.AddDateIntervalAsync(form);
                return new CreatedResult("Location", form);
            }
            return new BadRequestResult();
        }
    }
}