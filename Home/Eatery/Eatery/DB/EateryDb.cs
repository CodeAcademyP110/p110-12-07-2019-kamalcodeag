using Eatery.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eatery.DB
{
    public class EateryDb : DbContext
    {
        public EateryDb(DbContextOptions<EateryDb> options) : base(options)
        {
        }

        public DbSet<MainSlider> MainSliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DishTypography> DishTypographies { get; set; }
        public DbSet<DishItem> DishItems { get; set; }
        public DbSet<MenuTypography> MenuTypographies { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<TestimonialTypography> TestimonialTypographies { get; set; }
        public DbSet<TestimonialItem> TestimonialItems { get; set; }
        public DbSet<BlogTypography> BlogTypographies { get; set; }
        public DbSet<BlogItem> BlogItems { get; set; }

    }
}
