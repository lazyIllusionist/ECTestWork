using ECTestWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECTestWebAPI.Services
{
    public interface IDateService
    {
        IEnumerable<DateInterval> GetIntervals(DateIntervalForm dateInterval);
        IEnumerable<DateInterval> GetIntervals(DateTime startDate, DateTime endDate);
        void AddDateInterval(DateIntervalForm dateInterval);
        void AddDateInterval(DateTime startDate, DateTime endDate);

        Task<IEnumerable<DateInterval>> GetIntervalsAsync(DateIntervalForm dateInterval);
        Task<IEnumerable<DateInterval>> GetIntervalsAsync(DateTime startDate, DateTime endDate);
        Task AddDateIntervalAsync(DateIntervalForm dateInterval);
        Task AddDateIntervalAsync(DateTime startDate, DateTime endDate);
    }
}
