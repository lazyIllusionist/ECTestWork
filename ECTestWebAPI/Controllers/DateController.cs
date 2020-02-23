using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECTestWebAPI.Models;
using ECTestWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECTestWebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DateController : ControllerBase
    {
        readonly IDateService _service;
        readonly IValidationService _validator;
        readonly ILogger _logger;
        public DateController(IDateService service, IValidationService validator, ILogger<DateController> logger)
        {
            _service = service;
            _validator = validator;
            _logger = logger;
        }

        [HttpPut(Name = nameof(GetInnerDates))]
        public async Task<ActionResult<IEnumerable<DateInterval>>> GetInnerDates([FromBody] DateIntervalForm form)
        {
            try
            {
                if (await _validator.ValidateAsync(form))
                    return Ok(await _service.GetIntervalsAsync(form));
            }
            catch(ArgumentException e) { _logger.LogError(e.Message); }
            return new BadRequestResult();
        }

        [HttpPost(Name = nameof(AddDateInterval))]
        public async Task<IActionResult> AddDateInterval([FromBody] DateIntervalForm form)
        {
            try
            {
                if (await _validator.ValidateAsync(form))
                {
                    await _service.AddDateIntervalAsync(form);
                    return new CreatedResult("Location", form);
                }
            }
            catch (ArgumentException e) { _logger.LogError(e.Message); }
            return new BadRequestResult();
        }
    }
}