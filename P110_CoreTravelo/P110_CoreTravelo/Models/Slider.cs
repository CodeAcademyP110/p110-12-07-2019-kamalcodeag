using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace P110_CoreTravelo.Models
{
    public class Slider
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Image { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Photo should be selected for Slider")]
        public IFormFile Photo { get; set; }
    }
}
