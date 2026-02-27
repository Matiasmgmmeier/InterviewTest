using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Services;

public interface IUsuarioDomainService
{
    bool PuedeCrearFactura(Usuario usuario);
    decimal ObtenerTotalFacturado(Usuario usuario);
    bool EsClientePreferencial(Usuario usuario);
}
