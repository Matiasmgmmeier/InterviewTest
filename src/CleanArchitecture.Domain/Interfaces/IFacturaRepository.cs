using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces;

public interface IFacturaRepository : IRepository<Factura>
{
    Task<IEnumerable<Factura>> GetFacturasByUsuarioIdAsync(int usuarioId);
    Task<Factura?> GetFacturaConDetallesAsync(int id);
}
