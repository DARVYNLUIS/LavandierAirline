using System.ComponentModel.DataAnnotations;

namespace LavandierAirLine.Modelos
{
    public class Estados
    {

        [Key]
        public int EstadosId { get; set; }
        public string? Nombre { get; set; }
    }
}
