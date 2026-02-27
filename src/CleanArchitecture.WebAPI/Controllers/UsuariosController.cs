using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers;

/// <summary>
/// Controlador REST para la gestión de Usuarios.
/// 
/// RESPONSABILIDADES DEL CONTROLADOR:
/// 1. Recibir las peticiones HTTP y extraer los parámetros (ruta, body, query).
/// 2. Delegar toda la lógica al servicio (_usuarioService). NO poner lógica aquí.
/// 3. Retornar la respuesta HTTP adecuada según el resultado.
/// 
/// CÓDIGOS HTTP A USAR:
/// - Ok(data)           → 200: Consulta exitosa con datos.
/// - CreatedAtAction()  → 201: Recurso creado exitosamente.
/// - NoContent()        → 204: Operación exitosa sin datos que retornar (PUT, DELETE).
/// - NotFound(mensaje)  → 404: Recurso no encontrado.
/// - BadRequest(mensaje)→ 400: Datos de entrada inválidos.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    /// <summary>
    /// GET api/usuarios
    /// Obtiene la lista completa de usuarios.
    /// TAREA: Llamar a _usuarioService.GetAllUsuariosAsync() y retornar Ok(resultado).
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAll()
    {
        throw new NotImplementedException("Implementar: llamar al servicio y retornar Ok con la lista de usuarios");
    }

    /// <summary>
    /// GET api/usuarios/{id}
    /// Obtiene un usuario por su Id.
    /// TAREA: Llamar a _usuarioService.GetUsuarioByIdAsync(id).
    ///        Si retorna null → NotFound. Si existe → Ok(usuario).
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDto>> GetById(int id)
    {
        throw new NotImplementedException("Implementar: buscar por Id, retornar NotFound si null o Ok si existe");
    }

    /// <summary>
    /// GET api/usuarios/email/{email}
    /// Obtiene un usuario por su email.
    /// TAREA: Llamar a _usuarioService.GetUsuarioByEmailAsync(email).
    ///        Si retorna null → NotFound. Si existe → Ok(usuario).
    /// </summary>
    [HttpGet("email/{email}")]
    public async Task<ActionResult<UsuarioDto>> GetByEmail(string email)
    {
        throw new NotImplementedException("Implementar: buscar por email, retornar NotFound si null o Ok si existe");
    }

    /// <summary>
    /// GET api/usuarios/activos
    /// Obtiene solo los usuarios con estado Activo = true.
    /// TAREA: Llamar a _usuarioService.GetUsuariosActivosAsync() y retornar Ok(resultado).
    /// </summary>
    [HttpGet("activos")]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetActivos()
    {
        throw new NotImplementedException("Implementar: llamar al servicio y retornar Ok con usuarios activos");
    }

    /// <summary>
    /// POST api/usuarios
    /// Crea un nuevo usuario.
    /// TAREA: Llamar a _usuarioService.CreateUsuarioAsync(createDto).
    ///        Retornar CreatedAtAction apuntando a GetById con el Id del nuevo usuario.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<UsuarioDto>> Create([FromBody] CreateUsuarioDto createDto)
    {
        throw new NotImplementedException("Implementar: crear usuario y retornar CreatedAtAction con el nuevo recurso");
    }

    /// <summary>
    /// PUT api/usuarios/{id}
    /// Actualiza los datos de un usuario existente.
    /// TAREA: Llamar a _usuarioService.UpdateUsuarioAsync(id, updateDto).
    ///        Si el servicio lanza excepción por no encontrado → NotFound.
    ///        Si actualiza exitosamente → NoContent().
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUsuarioDto updateDto)
    {
        throw new NotImplementedException("Implementar: actualizar usuario, manejar excepción y retornar NoContent");
    }

    /// <summary>
    /// DELETE api/usuarios/{id}
    /// Elimina un usuario por su Id.
    /// TAREA: Llamar a _usuarioService.DeleteUsuarioAsync(id) y retornar NoContent().
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException("Implementar: eliminar usuario y retornar NoContent");
    }
}
