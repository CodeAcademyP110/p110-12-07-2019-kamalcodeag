using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eatery.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Image { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Info { get; set; }
    }
}
