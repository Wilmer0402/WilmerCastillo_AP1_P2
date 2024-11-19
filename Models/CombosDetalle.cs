using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WilmerCastillo_AP1_P2.Models;

namespace WilmerCastillo_AP1_P2.Models
{
    public class CombosDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        [ForeignKey("CombosId")]
        public int CombosId { get; set; }
        public Combos? Combos { get; set; }

        [InverseProperty("CombosDetalle")]
        
        [ForeignKey("ProductoId")]
        public int ProductosId { get; set; }
        public Productos? Productos { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La Cantidad debe ser mayor que 0")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Favor Ingresar el Costo ")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se Permiten Numeros")]
        public double Costo  { get; set; }

    }
}




   
    
       
    

