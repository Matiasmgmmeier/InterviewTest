using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Services;

public class UsuarioDomainService : IUsuarioDomainService
{
    public bool PuedeCrearFactura(Usuario usuario)
    {
        if (usuario == null)
            throw new ArgumentNullException(nameof(usuario));

        if (!usuario.Activo)
            return false;

        var facturasPendientes = usuario.Facturas?
            .Count(f => f.Estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase)) ?? 0;

        return facturasPendientes < 5;
    }

    public decimal ObtenerTotalFacturado(Usuario usuario)
    {
        if (usuario == null)
            throw new ArgumentNullException(nameof(usuario));

        return usuario.Facturas?
            .Where(f => f.Estado.Equals("Pagada", StringComparison.OrdinalIgnoreCase))
            .Sum(f => f.Total) ?? 0;
    }

    public bool EsClientePreferencial(Usuario usuario)
    {
        if (usuario == null)
            throw new ArgumentNullException(nameof(usuario));

        if (!usuario.Activo)
            return false;

        var totalFacturado = ObtenerTotalFacturado(usuario);
        var cantidadFacturas = usuario.Facturas?
            .Count(f => f.Estado.Equals("Pagada", StringComparison.OrdinalIgnoreCase)) ?? 0;

        return totalFacturado >= 5000 || cantidadFacturas >= 10;
    }
}
