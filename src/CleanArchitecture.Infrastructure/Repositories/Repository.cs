using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

/// <summary>
/// Repositorio genérico base que implementa las operaciones CRUD comunes para cualquier entidad.
/// Esta clase debe ser heredada por los repositorios específicos de cada entidad.
/// 
/// TAREA: Implementar cada método utilizando el DbContext (_context) y el DbSet (_dbSet).
/// - _context: Instancia del ApplicationDbContext inyectado por constructor.
/// - _dbSet: Referencia al DbSet<T> correspondiente a la entidad T.
/// 
/// Todos los métodos deben ser ASÍNCRONOS utilizando async/await.
/// </summary>
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    /// <summary>
    /// Obtiene una entidad por su identificador único.
    /// TAREA: Buscar la entidad usando FindAsync con el id recibido.
    /// Retornar null si no existe.
    /// </summary>
    public virtual async Task<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException("Implementar: buscar entidad por Id usando _dbSet.FindAsync(id)");
    }

    /// <summary>
    /// Obtiene todas las entidades de la tabla correspondiente.
    /// TAREA: Retornar la lista completa usando ToListAsync().
    /// </summary>
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException("Implementar: retornar todas las entidades usando _dbSet.ToListAsync()");
    }

    /// <summary>
    /// Agrega una nueva entidad a la base de datos.
    /// TAREA: Agregar la entidad al DbSet, guardar los cambios con SaveChangesAsync() y retornar la entidad.
    /// </summary>
    public virtual async Task<T> AddAsync(T entity)
    {
        throw new NotImplementedException("Implementar: agregar con _dbSet.AddAsync(entity) y luego _context.SaveChangesAsync()");
    }

    /// <summary>
    /// Actualiza una entidad existente en la base de datos.
    /// TAREA: Marcar la entidad como modificada con _dbSet.Update(entity) y guardar con SaveChangesAsync().
    /// </summary>
    public virtual async Task UpdateAsync(T entity)
    {
        throw new NotImplementedException("Implementar: actualizar con _dbSet.Update(entity) y luego _context.SaveChangesAsync()");
    }

    /// <summary>
    /// Elimina una entidad de la base de datos por su Id.
    /// TAREA: Primero obtener la entidad con GetByIdAsync(id).
    ///        Si existe, eliminarla con _dbSet.Remove(entity) y guardar con SaveChangesAsync().
    ///        Si no existe, no hacer nada.
    /// </summary>
    public virtual async Task DeleteAsync(int id)
    {
        throw new NotImplementedException("Implementar: obtener la entidad, si existe eliminar con _dbSet.Remove() y SaveChangesAsync()");
    }
}
