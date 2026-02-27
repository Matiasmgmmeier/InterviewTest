using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

/// <summary>
/// Repositorio específico para la entidad Usuario.
/// Hereda las operaciones CRUD del repositorio genérico Repository<Usuario>
/// e implementa consultas adicionales propias de la entidad.
/// 
/// IMPORTANTE: Al sobreescribir GetByIdAsync y GetAllAsync, incluir siempre
/// el Include de la relación con Facturas para evitar referencias nulas.
/// 
/// Usar Include() de Entity Framework para cargar relaciones (Eager Loading).
/// Usar FirstOrDefaultAsync() para obtener un único registro.
/// Usar Where() para filtrar registros.
/// </summary>
public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Obtiene un usuario por su dirección de email, incluyendo sus facturas.
    /// TAREA: Usar _dbSet.Include(u => u.Facturas).FirstOrDefaultAsync(u => u.Email == email)
    /// </summary>
    public async Task<Usuario?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException("Implementar: buscar por email con Include de Facturas usando FirstOrDefaultAsync");
    }

    /// <summary>
    /// Obtiene todos los usuarios cuyo campo Activo sea true, incluyendo sus facturas.
    /// TAREA: Usar _dbSet.Where(u => u.Activo).Include(u => u.Facturas).ToListAsync()
    /// </summary>
    public async Task<IEnumerable<Usuario>> GetUsuariosActivosAsync()
    {
        throw new NotImplementedException("Implementar: filtrar por Activo == true con Include de Facturas");
    }

    /// <summary>
    /// Sobreescribe GetByIdAsync para incluir la relación con Facturas.
    /// TAREA: Usar _dbSet.Include(u => u.Facturas).FirstOrDefaultAsync(u => u.Id == id)
    /// </summary>
    public override async Task<Usuario?> GetByIdAsync(int id)
    {
        throw new NotImplementedException("Implementar: buscar por Id con Include de Facturas");
    }

    /// <summary>
    /// Sobreescribe GetAllAsync para incluir la relación con Facturas.
    /// TAREA: Usar _dbSet.Include(u => u.Facturas).ToListAsync()
    /// </summary>
    public override async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        throw new NotImplementedException("Implementar: obtener todos los usuarios con Include de Facturas");
    }
}
