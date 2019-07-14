using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P110_CoreTravelo.Models;

namespace P110_CoreTravelo.ViewModel
{
    public class HomeIndexVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Destination> Destinations { get; set; }
        public HoneyMoon HoneyMoon { get; set; }
        public IEnumerable<HoneymoonDestinations> HoneymoonDestinations { get; set; }
        public IEnumerable<Services> Services { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
