using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using ECTestWebAPI.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using ECTestWebAPI.Services;
using System.Collections.Generic;

namespace ECTestWebAPI.Tests
{
    class DateServiceTest
    {
        DateApiDbContext context;

        [Test]
        public void AddDateInterval_AddNewDateInterval_Succsess()
        {
            //Arrenge
            var options = new DbContextOptionsBuilder<DateApiDbContext>()
                .UseInMemoryDatabase(databaseName: "DateIntervals")
                .Options;

            context = new DateApiDbContext(options);

            var dateIntervalEntity1 = new DateIntervalEntity
            {
                Id = 1,
                StartDate = new DateTime(0001, 01, 01),
                EndDate = new DateTime(10, 01, 01)
            };

            var dateIntervalEntity2 = new DateIntervalEntity
            {
                Id = 2,
                StartDate = new DateTime(0020, 01, 01),
                EndDate = new DateTime(30, 01, 01)
            };

            var dateIntervalEntity3 = new DateIntervalEntity
            {
                Id = 3,
                StartDate = new DateTime(0100, 01, 01),
                EndDate = new DateTime(0210, 01, 01)
            };

            context.DateIntervals.Add(dateIntervalEntity1);
            context.DateIntervals.Add(dateIntervalEntity2);
            context.DateIntervals.Add(dateIntervalEntity3);
            context.SaveChanges();

            DateService service = new DateService(context);
            DateTime start = new DateTime(202, 01, 01);
            DateTime end = new DateTime(209, 01, 01);
            int intervals_count = context.DateIntervals.Count();

            //Act
            service.AddDateInterval(start, end);

            //Assert
            Assert.AreNotEqual(intervals_count, context.DateIntervals.Count());
        }

        [Test]
        public void GetIntervals_SentIntervalWhitcIntesectAllAnother_Get4DateIntervals()
        {
            DateService service = new DateService(context);
            DateTime start = new DateTime(01, 01, 01);
            DateTime end = new DateTime(1000, 01, 01);
            List<DateInterval> list;

            //Act
            list = service.GetIntervals(start, end).ToList();

            //Assert
            Assert.AreEqual(4, list.Count());
        }

        [Test]
        public void GetIntervals_SentIntervalWhitcIntesectSomeAnother_Get2DateIntervals()
        {
            DateService service = new DateService(context);
            DateTime start = new DateTime(1, 01, 01);
            DateTime end = new DateTime(30, 01, 01);
            List<DateInterval> list;

            //Act
            list = service.GetIntervals(start, end).ToList();

            //Assert
            Assert.AreEqual(2, list.Count());
        }

        [Test]
        public void GetInterals_SentIntervalWhitchDontCrossAnyAnother_Get0DateIntervals()
        {
            DateService service = new DateService(context);
            DateTime start = new DateTime(3000, 01, 01);
            DateTime end = new DateTime(4000, 01, 01);
            List<DateInterval> list;

            //Act
            list = service.GetIntervals(start, end).ToList();

            //Assert
            Assert.AreEqual(0, list.Count());
        }
    }
}
