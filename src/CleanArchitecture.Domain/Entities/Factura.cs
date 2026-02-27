namespace CleanArchitecture.Domain.Entities;

public class Factura
{
    public int Id { get; set; }
    public string NumeroFactura { get; set; } = string.Empty;
    public DateTime FechaEmision { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; } = string.Empty;
    
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;

    public ICollection<DetalleFactura> DetallesFactura { get; set; } = new List<DetalleFactura>();
}
