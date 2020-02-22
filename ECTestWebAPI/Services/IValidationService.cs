using ECTestWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECTestWebAPI.Services
{
    public interface IValidationService
    {
        bool Validate(DateIntervalForm form);
        Task<bool> ValidateAsync(DateIntervalForm form);
     }
}
