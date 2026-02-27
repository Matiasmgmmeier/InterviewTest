# Guía de Entrevista - Clean Architecture Demo

Esta guía contiene preguntas comunes que pueden surgir en entrevistas técnicas sobre este proyecto.

## 🏗️ Arquitectura

### ¿Por qué usar Clean Architecture?

**Respuesta:**
Clean Architecture proporciona varios beneficios clave:

1. **Independencia de Frameworks**: La lógica de negocio no depende de ASP.NET Core, EF Core u otros frameworks
2. **Testeable**: Puedo testear la lógica de negocio sin necesidad de base de datos o UI
3. **Mantenible**: La separación clara de responsabilidades facilita el mantenimiento
4. **Escalable**: Puedo agregar nuevas funcionalidades sin afectar el código existente
5. **Flexible**: Puedo cambiar la base de datos o el framework sin reescribir la lógica de negocio

### ¿Cuál es el flujo de dependencias en este proyecto?

**Respuesta:**
```
WebAPI → Application → Domain ← Infrastructure
```

- **WebAPI** depende de Application e Infrastructure (para configurar DI)
- **Application** depende solo de Domain
- **Infrastructure** depende de Application y Domain
- **Domain** no depende de nadie (núcleo del sistema)

Este flujo sigue el **Principio de Inversión de Dependencias** (SOLID).

### ¿Por qué Domain no tiene dependencias?

**Respuesta:**
El Domain contiene las entidades y las reglas de negocio fundamentales. No debe depender de detalles de implementación como bases de datos o frameworks. Esto permite:

1. Reutilizar las entidades en diferentes contextos
2. Testear las reglas de negocio de forma aislada
3. Cambiar la infraestructura sin afectar el dominio

## 🔧 Patrones de Diseño

### ¿Qué patrones de diseño se utilizan?

**Respuesta:**

1. **Repository Pattern**: Abstrae el acceso a datos
   - Interfaces en Domain
   - Implementaciones en Infrastructure
   - Facilita el testing con mocks

2. **Dependency Injection**: 
   - Configurado en `Program.cs`
   - Permite cambiar implementaciones fácilmente
   - Facilita el testing

3. **DTO Pattern**:
   - Separa las entidades de dominio de los objetos de transferencia
   - Controla qué datos se exponen en la API
   - Evita problemas de serialización circular

4. **Service Layer Pattern**:
   - Encapsula la lógica de negocio
   - Coordina operaciones entre repositorios
   - Mapea entre entidades y DTOs

### ¿Por qué usar DTOs en lugar de exponer las entidades directamente?

**Respuesta:**

1. **Seguridad**: No expongo propiedades internas o sensibles
2. **Control**: Puedo decidir exactamente qué datos enviar/recibir
3. **Versionado**: Puedo cambiar las entidades sin romper la API
4. **Serialización**: Evito problemas de referencias circulares
5. **Validación**: Puedo aplicar validaciones específicas para la API

## 🗄️ Entity Framework Core

### ¿Cómo se configuran las relaciones entre entidades?

**Respuesta:**
En `ApplicationDbContext.OnModelCreating()` usando Fluent API:

```csharp
// Usuario → Factura (1:N)
entity.HasMany(e => e.Facturas)
    .WithOne(e => e.Usuario)
    .HasForeignKey(e => e.UsuarioId)
    .OnDelete(DeleteBehavior.Cascade);

// Factura → DetalleFactura (1:N)
entity.HasMany(e => e.DetallesFactura)
    .WithOne(e => e.Factura)
    .HasForeignKey(e => e.FacturaId)
    .OnDelete(DeleteBehavior.Cascade);
```

### ¿Qué es el Seed Data y por qué es útil?

**Respuesta:**
El Seed Data son datos iniciales que se insertan en la base de datos. En este proyecto:

- Se configura en `ApplicationDbContext.OnModelCreating()`
- Usa `modelBuilder.Entity<T>().HasData()`
- Es útil para:
  - Desarrollo y pruebas
  - Demostrar funcionalidades
  - Datos de configuración inicial
  - Entornos de staging

### ¿Qué son las migraciones y cómo funcionan?

**Respuesta:**
Las migraciones son archivos que describen cambios en el esquema de la base de datos:

1. **Crear migración**: `dotnet ef migrations add NombreMigracion`
   - Genera archivos en `Migrations/`
   - Compara el modelo actual con el anterior
   
2. **Aplicar migración**: `dotnet ef database update`
   - Ejecuta las migraciones pendientes
   - Actualiza el esquema de la BD

3. **Ventajas**:
   - Control de versiones del esquema
   - Rollback posible
   - Sincronización entre entornos

## 🔐 SOLID Principles

### ¿Cómo se aplica SOLID en este proyecto?

**Respuesta:**

1. **S - Single Responsibility**:
   - Cada clase tiene una única responsabilidad
   - `UsuarioRepository` solo maneja el acceso a datos de usuarios
   - `UsuarioService` solo maneja la lógica de negocio de usuarios

2. **O - Open/Closed**:
   - Puedo extender funcionalidad sin modificar código existente
   - Ejemplo: Agregar un nuevo repositorio sin cambiar los existentes

3. **L - Liskov Substitution**:
   - Puedo reemplazar `IUsuarioRepository` con cualquier implementación
   - Los servicios funcionan con la interfaz, no con la implementación

4. **I - Interface Segregation**:
   - Interfaces específicas: `IUsuarioRepository`, `IFacturaRepository`
   - No hay una interfaz gigante con todos los métodos

5. **D - Dependency Inversion**:
   - Las capas superiores dependen de abstracciones (interfaces)
   - `UsuarioService` depende de `IUsuarioRepository`, no de `UsuarioRepository`

### ¿Dónde se ve el Dependency Inversion Principle?

**Respuesta:**

En `UsuarioService`:
```csharp
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    
    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
}
```

- El servicio depende de la **interfaz** `IUsuarioRepository`
- No conoce la implementación concreta
- La implementación se inyecta en tiempo de ejecución
- Facilita el testing con mocks

## 🧪 Testing

### ¿Cómo testearías este código?

**Respuesta:**

**Unit Tests para Servicios:**
```csharp
[Fact]
public async Task GetUsuarioById_DeberiaRetornarUsuario()
{
    // Arrange
    var mockRepo = new Mock<IUsuarioRepository>();
    mockRepo.Setup(r => r.GetByIdAsync(1))
        .ReturnsAsync(new Usuario { Id = 1, Nombre = "Test" });
    
    var service = new UsuarioService(mockRepo.Object);
    
    // Act
    var result = await service.GetUsuarioByIdAsync(1);
    
    // Assert
    Assert.NotNull(result);
    Assert.Equal("Test", result.Nombre);
}
```

**Integration Tests para Repositorios:**
```csharp
[Fact]
public async Task AddUsuario_DeberiaGuardarEnBaseDeDatos()
{
    // Arrange
    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase("TestDb")
        .Options;
    
    using var context = new ApplicationDbContext(options);
    var repo = new UsuarioRepository(context);
    
    // Act
    var usuario = new Usuario { Nombre = "Test", Email = "test@test.com" };
    await repo.AddAsync(usuario);
    
    // Assert
    Assert.True(usuario.Id > 0);
}
```

### ¿Qué frameworks de testing usarías?

**Respuesta:**

- **xUnit**: Framework de testing principal
- **Moq**: Para crear mocks de interfaces
- **FluentAssertions**: Para assertions más legibles
- **EF Core InMemory**: Para testing de repositorios
- **WebApplicationFactory**: Para integration tests de la API

## 🚀 Mejoras Posibles

### ¿Qué mejoras implementarías en este proyecto?

**Respuesta:**

**Corto Plazo:**
1. **Validaciones**: FluentValidation para validar DTOs
2. **Logging**: Serilog para logging estructurado
3. **Exception Handling**: Middleware global para manejo de errores
4. **AutoMapper**: Para mapeo automático entre entidades y DTOs
5. **Unit Tests**: Cobertura de tests completa

**Mediano Plazo:**
6. **CQRS**: Separar comandos y consultas con MediatR
7. **Paginación**: Implementar paginación en endpoints GET
8. **Autenticación**: JWT para autenticación y autorización
9. **Versionado de API**: Soporte para múltiples versiones
10. **Caché**: Redis para caché distribuido

**Largo Plazo:**
11. **Event Sourcing**: Para auditoría completa
12. **Microservicios**: Separar en servicios independientes
13. **Message Queue**: RabbitMQ/Azure Service Bus para comunicación asíncrona
14. **API Gateway**: Para enrutamiento y seguridad centralizada
15. **Observabilidad**: Application Insights, Prometheus, Grafana

### ¿Cómo implementarías paginación?

**Respuesta:**

**1. Crear clase de paginación:**
```csharp
public class PagedResult<T>
{
    public List<T> Items { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
}
```

**2. Modificar repositorio:**
```csharp
Task<PagedResult<Usuario>> GetPagedAsync(int pageNumber, int pageSize);
```

**3. Implementación:**
```csharp
public async Task<PagedResult<Usuario>> GetPagedAsync(int pageNumber, int pageSize)
{
    var totalCount = await _dbSet.CountAsync();
    var items = await _dbSet
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
    
    return new PagedResult<Usuario>
    {
        Items = items,
        PageNumber = pageNumber,
        PageSize = pageSize,
        TotalCount = totalCount,
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
    };
}
```

### ¿Cómo agregarías autenticación JWT?

**Respuesta:**

**1. Instalar paquetes:**
```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

**2. Configurar en Program.cs:**
```csharp
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });

app.UseAuthentication();
app.UseAuthorization();
```

**3. Proteger endpoints:**
```csharp
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto dto)
    {
        // Validar credenciales y generar token
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        // Solo accesible con token válido
    }
}
```

## 💡 Preguntas de Diseño

### ¿Por qué no usar stored procedures?

**Respuesta:**

**Ventajas de NO usar stored procedures:**
1. **Portabilidad**: El código funciona con cualquier BD
2. **Control de versiones**: Todo el código está en Git
3. **Testing**: Más fácil testear con EF Core InMemory
4. **Refactoring**: Herramientas de IDE funcionan mejor
5. **LINQ**: Consultas type-safe y compiladas

**Cuándo SÍ usar stored procedures:**
1. Operaciones muy complejas con mejor rendimiento en BD
2. Lógica de negocio que debe estar en la BD por políticas
3. Operaciones batch masivas
4. Integración con sistemas legacy

### ¿Cuándo usarías un Unit of Work pattern?

**Respuesta:**

**Unit of Work es útil cuando:**
1. Necesitas transacciones que abarcan múltiples repositorios
2. Quieres controlar exactamente cuándo se hace SaveChanges
3. Necesitas rollback manual de operaciones

**En este proyecto:**
- EF Core ya implementa Unit of Work internamente
- `DbContext` actúa como Unit of Work
- Para operaciones simples, no es necesario agregar otra capa

**Implementación si fuera necesario:**
```csharp
public interface IUnitOfWork
{
    IUsuarioRepository Usuarios { get; }
    IFacturaRepository Facturas { get; }
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
```

### ¿Cómo manejarías concurrencia?

**Respuesta:**

**1. Optimistic Concurrency (recomendado):**
```csharp
public class Usuario
{
    public int Id { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
    // ... otras propiedades
}
```

**2. Manejo de conflictos:**
```csharp
try
{
    await _context.SaveChangesAsync();
}
catch (DbUpdateConcurrencyException ex)
{
    // Recargar datos y reintentar o notificar al usuario
    var entry = ex.Entries.Single();
    var databaseValues = await entry.GetDatabaseValuesAsync();
    
    if (databaseValues == null)
    {
        // El registro fue eliminado
    }
    else
    {
        // Resolver conflicto
    }
}
```

## 🎯 Preguntas de Performance

### ¿Cómo optimizarías las consultas?

**Respuesta:**

**1. Eager Loading para relaciones:**
```csharp
// Malo: N+1 queries
var facturas = await _context.Facturas.ToListAsync();
foreach (var f in facturas)
{
    var detalles = f.DetallesFactura; // Query por cada factura
}

// Bueno: 1 query
var facturas = await _context.Facturas
    .Include(f => f.DetallesFactura)
    .ToListAsync();
```

**2. Proyecciones (Select):**
```csharp
// Malo: Trae todos los campos
var usuarios = await _context.Usuarios.ToListAsync();

// Bueno: Solo los campos necesarios
var usuarios = await _context.Usuarios
    .Select(u => new { u.Id, u.Nombre, u.Email })
    .ToListAsync();
```

**3. AsNoTracking para consultas read-only:**
```csharp
var usuarios = await _context.Usuarios
    .AsNoTracking()
    .ToListAsync();
```

**4. Índices en la base de datos:**
```csharp
modelBuilder.Entity<Usuario>()
    .HasIndex(u => u.Email)
    .IsUnique();
```

### ¿Cuándo usarías caché?

**Respuesta:**

**Casos de uso:**
1. Datos que cambian poco (catálogos, configuración)
2. Consultas costosas que se repiten frecuentemente
3. Datos que pueden estar ligeramente desactualizados

**Implementación con IMemoryCache:**
```csharp
public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync()
{
    var cacheKey = "usuarios_all";
    
    if (!_cache.TryGetValue(cacheKey, out IEnumerable<UsuarioDto> usuarios))
    {
        usuarios = await _usuarioRepository.GetAllAsync();
        
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
        
        _cache.Set(cacheKey, usuarios, cacheOptions);
    }
    
    return usuarios;
}
```

## 📚 Recursos Adicionales

- **Clean Architecture**: Robert C. Martin (Uncle Bob)
- **Domain-Driven Design**: Eric Evans
- **Patterns of Enterprise Application Architecture**: Martin Fowler
- **Microsoft Docs**: ASP.NET Core, EF Core
