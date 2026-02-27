using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces;

public interface IDetalleFacturaRepository : IRepository<DetalleFactura>
{
    Task<IEnumerable<DetalleFactura>> GetDetallesByFacturaIdAsync(int facturaId);
}
