using LavandierAirLine.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LavandierAirLine.Modelos
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }

        public int BoletoId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
        public float Monto { get; set; }

        [Required]
        public DateTime FechaPago { get; set; } = DateTime.Now;

        [Required]
        public int? MetodoPagoId { get; set; }

        public MetodosPagos? MetodosPagos { get; set; }


        [StringLength(500)]
        public string Observaciones { get; set; }

        [Required]
        public string UsuarioId { get; set; }

        // Estado del pago (Pendiente, Completado, Cancelado, etc.)
        [Required]
        public int EstadoPagoId { get; set; } = 1;

        // Propiedades de navegación
        public Boleto? Boleto { get; set; }
        public ApplicationUser? Usuario { get; set; }
        public Estados? EstadoPago { get; set; }
    }
}
