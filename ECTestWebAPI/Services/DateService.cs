using ECTestWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ECTestWebAPI.Services
{
    public class DateService : IDateService
    {
        readonly DateApiDbContext _dbContext;
        public DateService(DateApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddDateInterval(DateIntervalForm form)
        {
            AddDateInterval(
                new DateTime(
                    form.StartYear,
                    form.StartMonth,
                    form.StartDay),
                new DateTime(
                    form.EndYear, 
                    form.EndMonth, 
                    form.EndDay));
        }

        public void AddDateInterval(DateTime startDate, DateTime endDate)
        {
            try
            {
                _dbContext.DateIntervals.Add(new DateIntervalEntity
                {
                    StartDate = startDate,
                    EndDate = endDate
                });

                _dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task AddDateIntervalAsync(DateIntervalForm form)
        {
            await AddDateIntervalAsync(new DateTime(form.StartYear, form.StartMonth, form.StartDay),
                new DateTime(form.EndYear, form.EndMonth, form.EndDay));
        }

        public async Task AddDateIntervalAsync(DateTime startDate, DateTime endDate)
        {
            await Task.Run(() => AddDateInterval(startDate, endDate));
        }

        public IEnumerable<DateInterval> GetIntervals(DateIntervalForm form)
        {
            return GetIntervals(
                new DateTime(
                    form.StartYear,
                    form.StartMonth,
                    form.StartDay),
                new DateTime(
                    form.EndYear,
                    form.EndMonth,
                    form.EndDay
                    ));
        }

        public IEnumerable<DateInterval> GetIntervals(DateTime startDate, DateTime endDate)
        {
            return _dbContext.DateIntervals.Where(x => 
            !(x.StartDate.CompareTo(endDate) > 0 || x.EndDate.CompareTo(startDate) < 0)) 
                .Select(x => new DateInterval
            {
                StartDate = x.StartDate,
                EndDate = x.EndDate
            }).AsEnumerable();
        }

        public async Task<IEnumerable<DateInterval>> GetIntervalsAsync(DateIntervalForm form)
        {
            return await Task<IEnumerable<DateInterval>>.Run(() => GetIntervals(form));
        }

        public async Task<IEnumerable<DateInterval>> GetIntervalsAsync(DateTime startDate, DateTime endDate)
        {
            return await Task<IEnumerable<DateInterval>>.Run(() => GetIntervals(startDate, endDate));
        }
    }
}
