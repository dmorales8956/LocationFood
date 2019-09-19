using LocationFood.Web.Controllers.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationFood.Web.Controllers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {

        }
        public DbSet <Restaurant> Restaurants { get; set; }

    }
}
