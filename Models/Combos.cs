using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WilmerCastillo_AP1_P2.Models
{
    public class Combos
    {
        [Key]

        public int CombosId { get; set; }

        [Required(ErrorMessage = "Favor Complete este Campo")]

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Favor Ingrese la Observacion de la Cotización")]
        [RegularExpression(@"[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten Letras")]

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Favor Ingrese el Precio del Trabajo")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten Numeros")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "Favor Ingrese si el Combo esta Vendido ")]
        [RegularExpression(@"[a-zA-Z\s]+s", ErrorMessage = "Solo se permiten Letras")]

        public string? Vendido { get; set; }

        public ICollection<CombosDetalle> CombosDetalle { get; set; } = new List<CombosDetalle>();


    }
}



