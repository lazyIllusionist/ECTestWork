using ECTestWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECTestWebAPI
{
    public class DateApiDbContext : DbContext
    {
        public DateApiDbContext(DbContextOptions<DateApiDbContext> options)
            : base(options) 
        {
             Database.EnsureCreated();
        }

        public DbSet<DateIntervalEntity> DateIntervals { get; set; }
    }
}
