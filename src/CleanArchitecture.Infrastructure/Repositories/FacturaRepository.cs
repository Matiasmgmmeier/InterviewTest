using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

/// <summary>
/// Repositorio específico para la entidad Factura.
/// Hereda las operaciones CRUD del repositorio genérico Repository<Factura>
/// e implementa consultas adicionales propias de la entidad.
/// 
/// IMPORTANTE: Las facturas tienen dos relaciones:
/// - Include(f => f.Usuario): Para cargar el usuario dueño de la factura.
/// - Include(f => f.DetallesFactura): Para cargar los ítems de la factura.
/// 
/// Siempre incluir ambas relaciones en los overrides de GetByIdAsync y GetAllAsync.
/// </summary>
public class FacturaRepository : Repository<Factura>, IFacturaRepository
{
    public FacturaRepository(ApplicationDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Obtiene todas las facturas de un usuario específico, incluyendo sus detalles y el usuario.
    /// TAREA: Filtrar por UsuarioId usando Where() e incluir las relaciones con Include().
    /// </summary>
    public async Task<IEnumerable<Factura>> GetFacturasByUsuarioIdAsync(int usuarioId)
    {
        throw new NotImplementedException("Implementar: filtrar por UsuarioId con Include de DetallesFactura y Usuario");
    }

    /// <summary>
    /// Obtiene una factura por Id incluyendo todos sus detalles y el usuario relacionado.
    /// TAREA: Usar Include() para DetallesFactura y Usuario, luego FirstOrDefaultAsync por Id.
    /// </summary>
    public async Task<Factura?> GetFacturaConDetallesAsync(int id)
    {
        throw new NotImplementedException("Implementar: buscar por Id con Include de DetallesFactura y Usuario");
    }

    /// <summary>
    /// Sobreescribe GetByIdAsync para incluir las relaciones de Factura.
    /// TAREA: Usar Include para DetallesFactura y Usuario, filtrar por Id con FirstOrDefaultAsync.
    /// </summary>
    public override async Task<Factura?> GetByIdAsync(int id)
    {
        throw new NotImplementedException("Implementar: buscar por Id con Include de DetallesFactura y Usuario");
    }

    /// <summary>
    /// Sobreescribe GetAllAsync para incluir las relaciones de Factura.
    /// TAREA: Usar Include para DetallesFactura y Usuario, retornar con ToListAsync.
    /// </summary>
    public override async Task<IEnumerable<Factura>> GetAllAsync()
    {
        throw new NotImplementedException("Implementar: obtener todas las facturas con Include de DetallesFactura y Usuario");
    }
}
