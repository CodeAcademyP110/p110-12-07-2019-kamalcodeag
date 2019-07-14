using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eatery.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required, StringLength(5000)]
        public string Ingredient { get; set; }

        [Required, StringLength(5000)]
        public string Info { get; set; }

        public decimal Price { get; set; }

        [Required, StringLength(100)]
        public string Image { get; set; }
    }
}
