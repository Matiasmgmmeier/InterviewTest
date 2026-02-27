using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services;

public interface IFacturaService
{
    Task<IEnumerable<FacturaDto>> GetAllFacturasAsync();
    Task<FacturaDto?> GetFacturaByIdAsync(int id);
    Task<IEnumerable<FacturaDto>> GetFacturasByUsuarioIdAsync(int usuarioId);
    Task<FacturaDto> CreateFacturaAsync(CreateFacturaDto createDto);
    Task UpdateFacturaAsync(int id, UpdateFacturaDto updateDto);
    Task DeleteFacturaAsync(int id);
}

/// <summary>
/// Servicio de aplicación para la gestión de Facturas.
/// Coordina la lógica entre Controladores y Repositorios para Factura y DetalleFactura.
/// 
/// RESPONSABILIDADES:
/// 1. Recibir CreateFacturaDto con los detalles incluidos.
/// 2. Calcular el Total de la factura sumando los subtotales de cada detalle (Cantidad * PrecioUnitario).
/// 3. Crear la Factura junto a sus DetallesFactura en una sola operación.
/// 4. Mapear la entidad Factura a FacturaDto para la respuesta.
/// 
/// MAPEO REQUERIDO (Entidad → DTO):
/// FacturaDto {
///     Id, NumeroFactura, FechaEmision, Total, Estado,
///     UsuarioId, NombreUsuario (desde factura.Usuario.Nombre),
///     Detalles (lista de DetalleFacturaDto)
/// }
/// 
/// DetalleFacturaDto {
///     Id, Producto, Cantidad, PrecioUnitario, Subtotal, FacturaId
/// }
/// </summary>
public class FacturaService : IFacturaService
{
    private readonly IFacturaRepository _facturaRepository;
    private readonly IDetalleFacturaRepository _detalleFacturaRepository;

    public FacturaService(IFacturaRepository facturaRepository, IDetalleFacturaRepository detalleFacturaRepository)
    {
        _facturaRepository = facturaRepository;
        _detalleFacturaRepository = detalleFacturaRepository;
    }

    /// <summary>
    /// Obtiene todas las facturas con sus detalles y usuario.
    /// TAREA: Llamar a _facturaRepository.GetAllAsync() y mapear cada Factura a FacturaDto.
    /// </summary>
    public async Task<IEnumerable<FacturaDto>> GetAllFacturasAsync()
    {
        throw new NotImplementedException("Implementar: obtener todas las facturas y mapear a FacturaDto");
    }

    /// <summary>
    /// Obtiene una factura por Id incluyendo sus detalles.
    /// TAREA: Llamar a _facturaRepository.GetFacturaConDetallesAsync(id) y mapear a FacturaDto.
    ///        Retornar null si no existe.
    /// </summary>
    public async Task<FacturaDto?> GetFacturaByIdAsync(int id)
    {
        throw new NotImplementedException("Implementar: obtener factura con detalles por Id y mapear a FacturaDto");
    }

    /// <summary>
    /// Obtiene todas las facturas de un usuario específico.
    /// TAREA: Llamar a _facturaRepository.GetFacturasByUsuarioIdAsync(usuarioId) y mapear a FacturaDto.
    /// </summary>
    public async Task<IEnumerable<FacturaDto>> GetFacturasByUsuarioIdAsync(int usuarioId)
    {
        throw new NotImplementedException("Implementar: obtener facturas por UsuarioId y mapear a FacturaDto");
    }

    /// <summary>
    /// Crea una nueva factura junto con sus detalles.
    /// TAREA:
    ///   1. Calcular el Total sumando (Cantidad * PrecioUnitario) de cada detalle del DTO.
    ///   2. Crear la entidad Factura mapeando desde CreateFacturaDto.
    ///   3. Crear los DetalleFactura para cada ítem en createDto.Detalles,
    ///      calculando el Subtotal = Cantidad * PrecioUnitario.
    ///   4. Asignar la lista de detalles a la propiedad Factura.DetallesFactura.
    ///   5. Guardar con _facturaRepository.AddAsync(factura).
    ///   6. Mapear y retornar FacturaDto.
    /// </summary>
    public async Task<FacturaDto> CreateFacturaAsync(CreateFacturaDto createDto)
    {
        throw new NotImplementedException("Implementar: calcular total, crear Factura con DetallesFactura y retornar FacturaDto");
    }

    /// <summary>
    /// Actualiza los datos principales de una factura (no los detalles).
    /// TAREA:
    ///   1. Obtener la factura con _facturaRepository.GetByIdAsync(id).
    ///   2. Si no existe, lanzar excepción.
    ///   3. Actualizar NumeroFactura, FechaEmision y Estado desde UpdateFacturaDto.
    ///   4. Guardar con _facturaRepository.UpdateAsync(factura).
    /// </summary>
    public async Task UpdateFacturaAsync(int id, UpdateFacturaDto updateDto)
    {
        throw new NotImplementedException("Implementar: buscar factura, actualizar campos y guardar");
    }

    /// <summary>
    /// Elimina una factura por su Id (los detalles se eliminan en cascada).
    /// TAREA: Llamar a _facturaRepository.DeleteAsync(id).
    /// </summary>
    public async Task DeleteFacturaAsync(int id)
    {
        throw new NotImplementedException("Implementar: llamar a _facturaRepository.DeleteAsync(id)");
    }
}
