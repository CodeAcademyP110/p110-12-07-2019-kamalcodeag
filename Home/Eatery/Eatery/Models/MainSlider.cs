using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eatery.Models
{
    public class MainSlider
    {
        public int Id { get; set; }

        public string Background { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Info { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
