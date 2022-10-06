using System.ComponentModel.DataAnnotations;
namespace FinalFour.Models
{
    public class Pick
    {
        public string? UID { get; set; }
        public string? Id { get; set; }
        public string? Apuesta { get; set; }
        public float? Momio { get; set; }
        public float? Monto { get; set; }
        public int? Resultado { get; set; }

        
    }
}
