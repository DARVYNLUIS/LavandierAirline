using LavandierAirLine.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LavandierAirLine.Modelos
{
    public class Boleto
    {
        [Key]
        public int BoletoId { get; set; }

        [Required]
        public int ViajeId { get; set; }

        [Required]
        public string ClienteId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio total debe ser mayor que 0.")]
        public float PrecioTotal { get; set; }

        [Required]
        public DateTime FechaCompra { get; set; } = DateTime.Now;

        [Required]
        public int EstadosId { get; set; } = 1;
        public Estados? Estados { get; set; }

        public Viaje? Viaje { get; set; }
        public ApplicationUser? Cliente { get; set; }

        [Required]
        public List<DetalleBoleto> Detalles { get; set; } = new List<DetalleBoleto>();
    }
}
