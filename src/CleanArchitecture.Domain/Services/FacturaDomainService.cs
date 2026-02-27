using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Services;

public class FacturaDomainService : IFacturaDomainService
{
    public decimal CalcularTotalFactura(IEnumerable<DetalleFactura> detalles)
    {
        if (detalles == null || !detalles.Any())
            return 0;

        return detalles.Sum(d => d.Subtotal);
    }

    public bool PuedeEliminarseFactura(Factura factura)
    {
        if (factura == null)
            throw new ArgumentNullException(nameof(factura));

        if (factura.Estado.Equals("Pagada", StringComparison.OrdinalIgnoreCase))
            return false;

        var diasDesdeEmision = (DateTime.Now - factura.FechaEmision).Days;
        if (diasDesdeEmision > 90)
            return false;

        return true;
    }

    public bool EsFacturaVencida(Factura factura, int diasVencimiento = 30)
    {
        if (factura == null)
            throw new ArgumentNullException(nameof(factura));

        if (factura.Estado.Equals("Pagada", StringComparison.OrdinalIgnoreCase))
            return false;

        var diasDesdeEmision = (DateTime.Now - factura.FechaEmision).Days;
        return diasDesdeEmision > diasVencimiento;
    }

    public string GenerarNumeroFactura(int usuarioId, DateTime fecha)
    {
        return $"FAC-{fecha:yyyy}-{usuarioId:D3}-{fecha:MMddHHmmss}";
    }
}
