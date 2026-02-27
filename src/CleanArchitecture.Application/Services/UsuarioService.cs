using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services;

public interface IUsuarioService
{
    Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync();

    Task<UsuarioDto?> GetUsuarioByIdAsync(int id);

    Task<UsuarioDto?> GetUsuarioByEmailAsync(string email);

    Task<IEnumerable<UsuarioDto>> GetUsuariosActivosAsync();

    Task<UsuarioDto> CreateUsuarioAsync(CreateUsuarioDto createDto);

    Task UpdateUsuarioAsync(int id, UpdateUsuarioDto updateDto);

    Task DeleteUsuarioAsync(int id);
}

/// <summary>
/// Servicio de aplicación para la gestión de Usuarios.
/// Actúa como intermediario entre los Controladores y los Repositorios.
///
/// RESPONSABILIDADES:
/// 1. Recibir los DTOs desde el controlador.
/// 2. Aplicar lógica de negocio (validaciones, transformaciones).
/// 3. Llamar al repositorio correspondiente (_usuarioRepository).
/// 4. Mapear las entidades del dominio (Usuario) a DTOs de respuesta (UsuarioDto).
/// 5. Retornar el DTO mapeado al controlador.
///
/// MAPEO REQUERIDO (Entidad → DTO):
/// UsuarioDto {
///     Id, Nombre, Email, Telefono, FechaRegistro, Activo
/// }
///
/// NOTA: No exponer nunca la entidad de dominio directamente. Siempre usar DTOs.
/// </summary>
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    /// <summary>
    /// Obtiene todos los usuarios y los retorna como lista de UsuarioDto.
    /// TAREA: Llamar a _usuarioRepository.GetAllAsync() y mapear cada Usuario a UsuarioDto.
    /// </summary>
    public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync()
    {
        var result = await _usuarioRepository.GetAllAsync();
        var dtolist = result.Select(x => new UsuarioDto
        {
            Id = x.Id,
            Nombre = x.Nombre,
            Email = x.Email,
            Telefono = x.Telefono,
            FechaRegistro = x.FechaRegistro,
            Activo = x.Activo
        });
        return dtolist.ToList();
    }

    /// <summary>
    /// Obtiene un usuario por Id y lo retorna como UsuarioDto.
    /// TAREA: Llamar a _usuarioRepository.GetByIdAsync(id).
    ///        Si es null retornar null, si existe mapear a UsuarioDto.
    /// </summary>
    public async Task<UsuarioDto?> GetUsuarioByIdAsync(int id)
    {
        throw new NotImplementedException("Implementar: obtener por Id y mapear a UsuarioDto, retornar null si no existe");
    }

    /// <summary>
    /// Obtiene un usuario por su email.
    /// TAREA: Llamar a _usuarioRepository.GetByEmailAsync(email) y mapear a UsuarioDto.
    /// </summary>
    public async Task<UsuarioDto?> GetUsuarioByEmailAsync(string email)
    {
        throw new NotImplementedException("Implementar: obtener por email y mapear a UsuarioDto");
    }

    /// <summary>
    /// Obtiene solo los usuarios activos.
    /// TAREA: Llamar a _usuarioRepository.GetUsuariosActivosAsync() y mapear a UsuarioDto.
    /// </summary>
    public async Task<IEnumerable<UsuarioDto>> GetUsuariosActivosAsync()
    {
        throw new NotImplementedException("Implementar: obtener usuarios activos y mapear a UsuarioDto");
    }

    /// <summary>
    /// Crea un nuevo usuario a partir del DTO recibido.
    /// TAREA:
    ///   1. Crear una nueva instancia de Usuario mapeando desde CreateUsuarioDto.
    ///   2. Asignar FechaRegistro = DateTime.Now.
    ///   3. Llamar a _usuarioRepository.AddAsync(usuario).
    ///   4. Mapear el resultado a UsuarioDto y retornarlo.
    /// </summary>
    public async Task<UsuarioDto> CreateUsuarioAsync(CreateUsuarioDto createDto)
    {
        throw new NotImplementedException("Implementar: mapear CreateUsuarioDto a Usuario, guardar y retornar UsuarioDto");
    }

    /// <summary>
    /// Actualiza los datos de un usuario existente.
    /// TAREA:
    ///   1. Obtener el usuario con _usuarioRepository.GetByIdAsync(id).
    ///   2. Si no existe, lanzar una excepción (ej: Exception o EntityNotFoundException).
    ///   3. Actualizar las propiedades con los valores del UpdateUsuarioDto.
    ///   4. Llamar a _usuarioRepository.UpdateAsync(usuario).
    /// </summary>
    public async Task UpdateUsuarioAsync(int id, UpdateUsuarioDto updateDto)
    {
        throw new NotImplementedException("Implementar: buscar usuario, actualizar propiedades y guardar");
    }

    /// <summary>
    /// Elimina un usuario por su Id.
    /// TAREA: Llamar a _usuarioRepository.DeleteAsync(id).
    /// </summary>
    public async Task DeleteUsuarioAsync(int id)
    {
        throw new NotImplementedException("Implementar: llamar a _usuarioRepository.DeleteAsync(id)");
    }
}