using System.ComponentModel.DataAnnotations;
namespace FinalFour.Models
{
    public class Pick
    {
        [Required]
        public string Apuesta { get; set; }
        [Required]
        public int Momio { get; set; }
        [Required] 
        public int Monto { get; set; }

        [Required]
        public bool Resultado { get; set; }
    }
}
