namespace LavandierAirLine.Modelos;

public class DetalleBoleto
{
    public int DetalleBoletoId { get; set; }
    public string CategoriaId { get; set; }
    public int Cantidad { get; set; } // Cantidad de boletos en esa clase
    public float PrecioUnitario { get; set; } // Precio por boleto según la clase
    public float PrecioTotal { get; set; } // Precio total para esa clase (Cantidad * PrecioUnitario)

}
