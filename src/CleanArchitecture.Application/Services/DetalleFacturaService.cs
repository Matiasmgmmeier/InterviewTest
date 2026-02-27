using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services;

public interface IDetalleFacturaService
{
    Task<IEnumerable<DetalleFacturaDto>> GetAllDetallesAsync();
    Task<DetalleFacturaDto?> GetDetalleByIdAsync(int id);
    Task<IEnumerable<DetalleFacturaDto>> GetDetallesByFacturaIdAsync(int facturaId);
    Task<DetalleFacturaDto> CreateDetalleAsync(int facturaId, CreateDetalleFacturaDto createDto);
    Task UpdateDetalleAsync(int id, UpdateDetalleFacturaDto updateDto);
    Task DeleteDetalleAsync(int id);
}

/// <summary>
/// Servicio de aplicación para la gestión de Detalles de Factura.
/// 
/// RESPONSABILIDADES:
/// 1. Gestionar los ítems individuales de cada factura.
/// 2. Al agregar o modificar un detalle, recalcular el Total de la factura padre.
/// 3. Calcular el Subtotal de cada detalle: Cantidad * PrecioUnitario.
/// 
/// LÓGICA DE RECÁLCULO DEL TOTAL:
/// Cada vez que se crea, actualiza o elimina un detalle, se debe:
///   1. Obtener la factura relacionada con _facturaRepository.GetFacturaConDetallesAsync(facturaId).
///   2. Recalcular: factura.Total = factura.DetallesFactura.Sum(d => d.Subtotal).
///   3. Guardar la factura actualizada con _facturaRepository.UpdateAsync(factura).
/// 
/// MAPEO REQUERIDO (Entidad → DTO):
/// DetalleFacturaDto {
///     Id, Producto, Cantidad, PrecioUnitario, Subtotal, FacturaId
/// }
/// </summary>
public class DetalleFacturaService : IDetalleFacturaService
{
    private readonly IDetalleFacturaRepository _detalleRepository;
    private readonly IFacturaRepository _facturaRepository;

    public DetalleFacturaService(IDetalleFacturaRepository detalleRepository, IFacturaRepository facturaRepository)
    {
        _detalleRepository = detalleRepository;
        _facturaRepository = facturaRepository;
    }

    /// <summary>
    /// Obtiene todos los detalles de factura.
    /// TAREA: Llamar a _detalleRepository.GetAllAsync() y mapear a DetalleFacturaDto.
    /// </summary>
    public async Task<IEnumerable<DetalleFacturaDto>> GetAllDetallesAsync()
    {
        throw new NotImplementedException("Implementar: obtener todos los detalles y mapear a DetalleFacturaDto");
    }

    /// <summary>
    /// Obtiene un detalle por su Id.
    /// TAREA: Llamar a _detalleRepository.GetByIdAsync(id) y mapear a DetalleFacturaDto.
    ///        Retornar null si no existe.
    /// </summary>
    public async Task<DetalleFacturaDto?> GetDetalleByIdAsync(int id)
    {
        throw new NotImplementedException("Implementar: obtener detalle por Id y mapear a DetalleFacturaDto");
    }

    /// <summary>
    /// Obtiene todos los detalles de una factura específica.
    /// TAREA: Llamar a _detalleRepository.GetDetallesByFacturaIdAsync(facturaId) y mapear a DetalleFacturaDto.
    /// </summary>
    public async Task<IEnumerable<DetalleFacturaDto>> GetDetallesByFacturaIdAsync(int facturaId)
    {
        throw new NotImplementedException("Implementar: obtener detalles por FacturaId y mapear a DetalleFacturaDto");
    }

    /// <summary>
    /// Agrega un nuevo detalle a una factura existente y recalcula el total.
    /// TAREA:
    ///   1. Crear la entidad DetalleFactura mapeando desde CreateDetalleFacturaDto.
    ///   2. Calcular Subtotal = Cantidad * PrecioUnitario.
    ///   3. Asignar FacturaId al detalle.
    ///   4. Guardar con _detalleRepository.AddAsync(detalle).
    ///   5. Recalcular el Total de la factura padre y guardarlo.
    ///   6. Mapear y retornar DetalleFacturaDto.
    /// </summary>
    public async Task<DetalleFacturaDto> CreateDetalleAsync(int facturaId, CreateDetalleFacturaDto createDto)
    {
        throw new NotImplementedException("Implementar: crear detalle, calcular subtotal, recalcular total de factura y retornar DTO");
    }

    /// <summary>
    /// Actualiza un detalle existente y recalcula el total de la factura padre.
    /// TAREA:
    ///   1. Obtener el detalle con _detalleRepository.GetByIdAsync(id).
    ///   2. Si no existe, lanzar excepción.
    ///   3. Actualizar Producto, Cantidad, PrecioUnitario y Subtotal (Cantidad * PrecioUnitario).
    ///   4. Guardar con _detalleRepository.UpdateAsync(detalle).
    ///   5. Recalcular el Total de la factura padre y guardarlo.
    /// </summary>
    public async Task UpdateDetalleAsync(int id, UpdateDetalleFacturaDto updateDto)
    {
        throw new NotImplementedException("Implementar: actualizar detalle, recalcular subtotal y total de factura");
    }

    /// <summary>
    /// Elimina un detalle y recalcula el total de la factura padre.
    /// TAREA:
    ///   1. Obtener el detalle para saber a qué factura pertenece (guardar facturaId).
    ///   2. Eliminar con _detalleRepository.DeleteAsync(id).
    ///   3. Recalcular el Total de la factura padre y guardarlo.
    /// </summary>
    public async Task DeleteDetalleAsync(int id)
    {
        throw new NotImplementedException("Implementar: eliminar detalle y recalcular total de factura padre");
    }
}
