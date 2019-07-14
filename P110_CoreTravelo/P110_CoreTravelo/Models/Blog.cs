using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P110_CoreTravelo.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Image { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Text { get; set; }
    }
}
