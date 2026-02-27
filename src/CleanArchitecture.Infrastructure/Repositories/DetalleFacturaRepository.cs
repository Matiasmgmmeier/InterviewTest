using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

/// <summary>
/// Repositorio específico para la entidad DetalleFactura.
/// Hereda las operaciones CRUD del repositorio genérico Repository<DetalleFactura>
/// e implementa consultas adicionales propias de la entidad.
/// 
/// IMPORTANTE: Los detalles siempre están asociados a una Factura.
/// Usar Include(d => d.Factura) para cargar la factura relacionada.
/// </summary>
public class DetalleFacturaRepository : Repository<DetalleFactura>, IDetalleFacturaRepository
{
    public DetalleFacturaRepository(ApplicationDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Obtiene todos los detalles de una factura específica, incluyendo la factura relacionada.
    /// TAREA: Filtrar por FacturaId usando Where() e incluir la relación con Factura usando Include().
    /// </summary>
    public async Task<IEnumerable<DetalleFactura>> GetDetallesByFacturaIdAsync(int facturaId)
    {
        throw new NotImplementedException("Implementar: filtrar por FacturaId con Include de Factura");
    }

    /// <summary>
    /// Sobreescribe GetByIdAsync para incluir la relación con Factura.
    /// TAREA: Usar Include(d => d.Factura) y buscar por Id con FirstOrDefaultAsync.
    /// </summary>
    public override async Task<DetalleFactura?> GetByIdAsync(int id)
    {
        throw new NotImplementedException("Implementar: buscar por Id con Include de Factura");
    }

    /// <summary>
    /// Sobreescribe GetAllAsync para incluir la relación con Factura.
    /// TAREA: Usar Include(d => d.Factura) y retornar con ToListAsync.
    /// </summary>
    public override async Task<IEnumerable<DetalleFactura>> GetAllAsync()
    {
        throw new NotImplementedException("Implementar: obtener todos los detalles con Include de Factura");
    }
}
