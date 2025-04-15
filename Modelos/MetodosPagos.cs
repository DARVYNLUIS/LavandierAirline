using System.ComponentModel.DataAnnotations;

namespace LavandierAirLine.Modelos
{
    public class MetodosPagos
    {
        [Key]
        public int MetodoPagoId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
