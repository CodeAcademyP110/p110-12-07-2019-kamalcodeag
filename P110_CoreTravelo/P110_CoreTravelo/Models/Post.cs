using System.ComponentModel.DataAnnotations;

namespace P110_CoreTravelo.Models
{
    public class Post
    {

        [Required(ErrorMessage = "Başlığı doldurun")]
        [StringLength(30, ErrorMessage = "Basliq 30-dan az olmalidir")]
        public string Basliq { get; set; }

        [Required(ErrorMessage = "Contenti doldurun"), MinLength(10)]
        public string Content { get; set; }

        [Required, MinLength(6), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Compare(nameof(Password)), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}