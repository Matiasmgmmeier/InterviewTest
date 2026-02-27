using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Services;

public interface IFacturaDomainService
{
    decimal CalcularTotalFactura(IEnumerable<DetalleFactura> detalles);
    bool PuedeEliminarseFactura(Factura factura);
    bool EsFacturaVencida(Factura factura, int diasVencimiento = 30);
    string GenerarNumeroFactura(int usuarioId, DateTime fecha);
}
