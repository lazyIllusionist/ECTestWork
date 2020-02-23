using ECTestWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECTestWebAPI.Services
{
    public class ValidationService : IValidationService
    {
        public bool Validate(DateIntervalForm form)
        {
            if(form.StartYear <= 0 || form.StartYear > 9999 || form.EndYear <= 0 || form.EndYear > 9999)
                throw new ArgumentException("Year can not be less than 1 and more than 9999");
            if (form.StartMonth < 1 || form.StartMonth > 12 || form.EndMonth < 1 || form.EndMonth > 12)
                throw new ArgumentException("Month can not be less than 1 and bigger than 12");
            if (form.StartDay < 1 || form.StartDay > 31 || form.EndDay < 1 || form.EndDay > 31)
                throw new ArgumentException("Day can not be less that 1 and bigger than 31");

            if (form.StartYear > form.EndYear)
                throw new ArgumentException("Error in years");
            if (form.StartYear == form.EndYear && form.StartMonth > form.EndMonth)
                throw new ArgumentException("Error in months");
            if(form.StartYear == form.EndYear && form.StartMonth == form.EndMonth && form.StartDay > form.EndDay)
                throw new ArgumentException("Error in days");

            return true;
        }

        public async Task<bool> ValidateAsync(DateIntervalForm form)
        {
            return await Task<bool>.Run(() => Validate(form));
        }
    }
}
