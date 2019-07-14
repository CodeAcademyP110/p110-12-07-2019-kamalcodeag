using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P110_CoreTravelo.Models
{
    public class Services
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Image { get; set; }

        [Required]
        [StringLength(200)]
        public string Heading { get; set; }

        [Required]
        [StringLength(400)]
        public string Info { get; set; }
    }
}
