using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P110_CoreTravelo.Models
{
    public class HoneyMoon
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [StringLength(200)]
        public string BackgroundImage { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Info { get; set; }
    }
}
