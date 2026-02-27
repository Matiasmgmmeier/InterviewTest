using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers;

/// <summary>
/// Controlador REST para la gestión de Detalles de Factura.
/// 
/// RESPONSABILIDADES DEL CONTROLADOR:
/// 1. Gestionar los ítems individuales (líneas) de cada factura.
/// 2. Delegar toda la lógica al servicio (_detalleService).
/// 3. Retornar respuestas HTTP correctas.
/// 
/// ENDPOINTS A IMPLEMENTAR:
/// - GET    /api/detallesfactura                    → Lista todos los detalles.
/// - GET    /api/detallesfactura/{id}               → Obtiene un detalle por Id.
/// - GET    /api/detallesfactura/factura/{facturaId} → Detalles de una factura específica.
/// - POST   /api/detallesfactura/factura/{facturaId} → Agrega un detalle a una factura.
/// - PUT    /api/detallesfactura/{id}               → Actualiza un detalle.
/// - DELETE /api/detallesfactura/{id}               → Elimina un detalle.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class DetallesFacturaController : ControllerBase
{
    private readonly IDetalleFacturaService _detalleService;

    public DetallesFacturaController(IDetalleFacturaService detalleService)
    {
        _detalleService = detalleService;
    }

    /// <summary>
    /// GET api/detallesfactura
    /// Obtiene todos los detalles de factura.
    /// TAREA: Llamar a _detalleService.GetAllDetallesAsync() y retornar Ok(resultado).
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DetalleFacturaDto>>> GetAll()
    {
        throw new NotImplementedException("Implementar: llamar al servicio y retornar Ok con todos los detalles");
    }

    /// <summary>
    /// GET api/detallesfactura/{id}
    /// Obtiene un detalle de factura por su Id.
    /// TAREA: Llamar a _detalleService.GetDetalleByIdAsync(id).
    ///        Si es null → NotFound. Si existe → Ok(detalle).
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<DetalleFacturaDto>> GetById(int id)
    {
        throw new NotImplementedException("Implementar: buscar por Id, retornar NotFound si null o Ok si existe");
    }

    /// <summary>
    /// GET api/detallesfactura/factura/{facturaId}
    /// Obtiene todos los detalles de una factura específica.
    /// TAREA: Llamar a _detalleService.GetDetallesByFacturaIdAsync(facturaId) y retornar Ok(resultado).
    /// </summary>
    [HttpGet("factura/{facturaId}")]
    public async Task<ActionResult<IEnumerable<DetalleFacturaDto>>> GetByFacturaId(int facturaId)
    {
        throw new NotImplementedException("Implementar: obtener detalles por FacturaId y retornar Ok");
    }

    /// <summary>
    /// POST api/detallesfactura/factura/{facturaId}
    /// Agrega un nuevo detalle a una factura existente.
    /// TAREA: Llamar a _detalleService.CreateDetalleAsync(facturaId, createDto).
    ///        Retornar CreatedAtAction apuntando a GetById con el Id del nuevo detalle.
    /// </summary>
    [HttpPost("factura/{facturaId}")]
    public async Task<ActionResult<DetalleFacturaDto>> Create(int facturaId, [FromBody] CreateDetalleFacturaDto createDto)
    {
        throw new NotImplementedException("Implementar: crear detalle y retornar CreatedAtAction con el nuevo detalle");
    }

    /// <summary>
    /// PUT api/detallesfactura/{id}
    /// Actualiza un detalle de factura existente.
    /// TAREA: Llamar a _detalleService.UpdateDetalleAsync(id, updateDto).
    ///        Manejar excepción → NotFound. Éxito → NoContent().
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDetalleFacturaDto updateDto)
    {
        throw new NotImplementedException("Implementar: actualizar detalle, manejar excepción y retornar NoContent");
    }

    /// <summary>
    /// DELETE api/detallesfactura/{id}
    /// Elimina un detalle de factura por su Id.
    /// TAREA: Llamar a _detalleService.DeleteDetalleAsync(id) y retornar NoContent().
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        throw new NotImplementedException("Implementar: eliminar detalle y retornar NoContent");
    }
}
