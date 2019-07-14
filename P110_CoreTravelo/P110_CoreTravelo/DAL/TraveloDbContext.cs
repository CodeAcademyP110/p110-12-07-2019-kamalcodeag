using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P110_CoreTravelo.Models;

namespace P110_CoreTravelo.DAL
{
    public class TraveloDbContext : DbContext
    {
        public TraveloDbContext(DbContextOptions<TraveloDbContext> options) : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<HoneyMoon> HoneyMoon { get; set; }
        public DbSet<HoneymoonDestinations> HoneymoonDestinations { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
