using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers;

/// <summary>
/// Controlador REST para la gestión de Facturas.
/// 
/// RESPONSABILIDADES DEL CONTROLADOR:
/// 1. Recibir las peticiones HTTP y extraer los parámetros.
/// 2. Delegar la lógica al servicio (_facturaService). NO poner lógica aquí.
/// 3. Retornar la respuesta HTTP adecuada.
/// 
/// ENDPOINTS A IMPLEMENTAR:
/// - GET  /api/facturas              → Lista todas las facturas.
/// - GET  /api/facturas/{id}         → Obtiene una factura con sus detalles.
/// - GET  /api/facturas/usuario/{id} → Facturas de un usuario específico.
/// - POST /api/facturas              → Crea factura con sus detalles.
/// - PUT  /api/facturas/{id}         → Actualiza datos de la factura.
/// - DELETE /api/facturas/{id}       → Elimina la factura y sus detalles (cascada).
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class FacturasController : ControllerBase
{
    private readonly IFacturaService _facturaService;

    public FacturasController(IFacturaService facturaService)
    {
        _facturaService = facturaService;
    }

    /// <summary>
    /// GET api/facturas
    /// Obtiene todas las facturas con sus detalles y usuario relacionado.
    /// TAREA: Llamar a _facturaService.GetAllFacturasAsync() y retornar Ok(resultado).
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FacturaDto>>> GetAll()
    {
        throw new NotImplementedException("Implementar: llamar al servicio y retornar Ok con la lista de facturas");
    }

    /// <summary>
    /// GET api/facturas/{id}
    /// Obtiene una factura específica con todos sus detalles.
    /// TAREA: Llamar a _facturaService.GetFacturaByIdAsync(id).
    ///        Si es null → NotFound. Si existe → Ok(factura).
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<FacturaDto>> GetById(int id)
    {
        throw new NotImplementedException("Implementar: buscar por Id, retornar NotFound si null o Ok con la factura");
    }

    /// <summary>
    /// GET api/facturas/usuario/{usuarioId}
    /// Obtiene todas las facturas de un usuario específico.
    /// TAREA: Llamar a _facturaService.GetFacturasByUsuarioIdAsync(usuarioId) y retornar Ok(resultado).
    /// </summary>
    [HttpGet("usuario/{usuarioId}")]
    public async Task<ActionResult<IEnumerable<FacturaDto>>> GetByUsuarioId(int usuarioId)
    {
        throw new NotImplementedException("Implementar: obtener facturas por UsuarioId y retornar Ok");
    }

    /// <summary>
    /// POST api/facturas
    /// Crea una nueva factura con sus detalles incluidos en el body.
    /// TAREA: Llamar a _facturaService.CreateFacturaAsync(createDto).
    ///        Retornar CreatedAtAction apuntando a GetById con el Id de la nueva factura.
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<FacturaDto>> Create([FromBody] CreateFacturaDto createDto)
    {
        throw new NotImplementedException("Implementar: crear factura y retornar CreatedAtAction con la nueva factura");
    }

    /// <summary>
    /// PUT api/facturas/{id}
    /// Actualiza los datos principales de una factura (no los detalles).
    /// TAREA: Llamar a _facturaService.UpdateFacturaAsync(id, updateDto).
    ///        Manejar excepción → NotFound. Éxito → NoContent().
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateFacturaDto updateDto)
    {
        throw new NotImplementedException("Implementar: actualizar factura, manejar excepción y retornar NoContent");
    }

    /// <summary>
    /// DELETE api/facturas/{id}
    /// Elimina una factura. Los detalles se eliminan automáticamente por cascada.
    /// TAREA: Llamar a _facturaService.DeleteFacturaAsync(id) y retornar NoContent().
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException("Implementar: eliminar factura y retornar NoContent");
    }
}
