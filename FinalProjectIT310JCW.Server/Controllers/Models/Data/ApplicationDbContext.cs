//namespace FinalProjectIT310JCW.Server.Controllers.Models.Data
//{
//    public class ApplicationDbContext
//    {
//    }
//}


// ApplicationDbContext.cs - Entity Framework Core DB Context
using Microsoft.EntityFrameworkCore;
using FinalProjectIT310JCW.Server.Models;
using System.Collections.Generic;

namespace FinalProjectIT310JCW.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
