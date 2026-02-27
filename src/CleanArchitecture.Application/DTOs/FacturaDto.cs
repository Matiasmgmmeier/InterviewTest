namespace CleanArchitecture.Application.DTOs;

public class FacturaDto
{
    public int Id { get; set; }
    public string NumeroFactura { get; set; } = string.Empty;
    public DateTime FechaEmision { get; set; }
    public decimal Total { get; set; }
    public string Estado { get; set; } = string.Empty;
    public int UsuarioId { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public List<DetalleFacturaDto> Detalles { get; set; } = new();
}

public class CreateFacturaDto
{
    public string NumeroFactura { get; set; } = string.Empty;
    public DateTime FechaEmision { get; set; }
    public string Estado { get; set; } = string.Empty;
    public int UsuarioId { get; set; }
    public List<CreateDetalleFacturaDto> Detalles { get; set; } = new();
}

public class UpdateFacturaDto
{
    public string NumeroFactura { get; set; } = string.Empty;
    public DateTime FechaEmision { get; set; }
    public string Estado { get; set; } = string.Empty;
}
