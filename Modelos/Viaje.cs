using System.ComponentModel.DataAnnotations;

namespace LavandierAirLine.Modelos;

public class Viaje
{
    [Key]
    public int ViajesId { get; set; }
    [Required(ErrorMessage = "La fecha de salida es obligatoria.")]
    public DateTime FechaSalida { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "La fecha de llegada es obligatoria.")]
    public DateTime FechaLlegada { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El origen es obligatorio.")]
    [StringLength(100, ErrorMessage = "El origen no puede tener más de 100 caracteres.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El origen solo puede contener letras y espacios.")]
    public string Origen { get; set; }

    [Required(ErrorMessage = "El destino es obligatorio.")]
    [StringLength(100, ErrorMessage = "El destino no puede tener más de 100 caracteres.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El destino solo puede contener letras y espacios.")]
    public string Destino { get; set; }
    [Required(ErrorMessage = "La imagen del Viaje es obligatoria")]
    public string? ImagenProducto { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un avión.")]
    public int AvionId { get; set; }

    public Avion? Avion { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
    public float Precio { get; set; }  // Precio del viaje
}
