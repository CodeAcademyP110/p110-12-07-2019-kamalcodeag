using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eatery.Models
{
    public class HomeVM
    {
        public IEnumerable<MainSlider> MainSliders { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public DishTypography DishTypography { get; set; }
        public IEnumerable<DishItem> DishItems { get; set; }
        public MenuTypography MenuTypography { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public TestimonialTypography TestimonialTypography { get; set; }
        public IEnumerable<TestimonialItem> TestimonialItems { get; set; }
        public BlogTypography BlogTypography { get; set; }
        public IEnumerable<BlogItem> BlogItems { get; set; }
    }
}
