using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eatery.Models
{
    public class TestimonialItem
    {
        public int Id { get; set; }

        [Required]
        public string Speech { get; set; }

        [Required, StringLength(100)]
        public string Image { get; set; }

        [Required, StringLength(100)]
        public string Author { get; set; }

        [Required, StringLength(100)]
        public string Profession { get; set; }
    }
}
