using System.ComponentModel.DataAnnotations;

namespace LavandierAirLine.Modelos
{
    public class CategoriaVuelo
    {
        [Key]
        public int CategoriaVueloId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el nombre de la categoria.")]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public float Precio { get; set; }
    }
}
