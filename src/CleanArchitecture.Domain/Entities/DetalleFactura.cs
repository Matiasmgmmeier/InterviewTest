namespace CleanArchitecture.Domain.Entities;

public class DetalleFactura
{
    public int Id { get; set; }
    public string Producto { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
    
    public int FacturaId { get; set; }
    public Factura Factura { get; set; } = null!;
}
