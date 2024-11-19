using System.ComponentModel.DataAnnotations;

namespace WilmerCastillo_AP1_P2.Models
{
    public class Productos
    {
               [Key]

            public int ProductosId { get; set; }

            [Required(ErrorMessage = "Favor Ingresar la Descripcion")]
            public string? Descripcion { get; set; }

            [Required(ErrorMessage = "Favor Ingresar el Costo")]
            [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se Permiten Numeros")]

            public double Costo { get; set; }

            [Required(ErrorMessage = "Favor Ingresar el Precio")]
            [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se Permiten Numeros")]

            public double Precio { get; set; }

            [Required(ErrorMessage = "Favor Ingresar la  Existencia")]
            [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Solo se Permiten Numeros")]

            public int Existencia { get; set; }

            public string? DiscoDuro { get; set; }   

            public string? MemoriaRam { get; set; }  

            public string?  Procesador { get; set; }

           public string?  MemoriaGrafica { get; set; }  


        
    }
}




    

