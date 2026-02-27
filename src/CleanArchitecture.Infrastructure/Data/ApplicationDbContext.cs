using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<DetalleFactura> DetallesFactura { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.FechaRegistro).IsRequired();
            entity.Property(e => e.Activo).IsRequired();

            entity.HasMany(e => e.Facturas)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.NumeroFactura).IsRequired().HasMaxLength(50);
            entity.Property(e => e.FechaEmision).IsRequired();
            entity.Property(e => e.Total).HasPrecision(18, 2);
            entity.Property(e => e.Estado).IsRequired().HasMaxLength(20);

            entity.HasMany(e => e.DetallesFactura)
                .WithOne(e => e.Factura)
                .HasForeignKey(e => e.FacturaId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Producto).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Cantidad).IsRequired();
            entity.Property(e => e.PrecioUnitario).HasPrecision(18, 2);
            entity.Property(e => e.Subtotal).HasPrecision(18, 2);
        });

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                Id = 1,
                Nombre = "Juan Pérez",
                Email = "juan.perez@email.com",
                Telefono = "+34 612 345 678",
                FechaRegistro = new DateTime(2024, 1, 15),
                Activo = true
            },
            new Usuario
            {
                Id = 2,
                Nombre = "María García",
                Email = "maria.garcia@email.com",
                Telefono = "+34 623 456 789",
                FechaRegistro = new DateTime(2024, 2, 20),
                Activo = true
            },
            new Usuario
            {
                Id = 3,
                Nombre = "Carlos López",
                Email = "carlos.lopez@email.com",
                Telefono = "+34 634 567 890",
                FechaRegistro = new DateTime(2024, 3, 10),
                Activo = false
            }
        );

        modelBuilder.Entity<Factura>().HasData(
            new Factura
            {
                Id = 1,
                NumeroFactura = "FAC-2024-001",
                FechaEmision = new DateTime(2024, 6, 1),
                Total = 1250.50m,
                Estado = "Pagada",
                UsuarioId = 1
            },
            new Factura
            {
                Id = 2,
                NumeroFactura = "FAC-2024-002",
                FechaEmision = new DateTime(2024, 6, 15),
                Total = 850.75m,
                Estado = "Pendiente",
                UsuarioId = 2
            },
            new Factura
            {
                Id = 3,
                NumeroFactura = "FAC-2024-003",
                FechaEmision = new DateTime(2024, 7, 5),
                Total = 2100.00m,
                Estado = "Pagada",
                UsuarioId = 1
            }
        );

        modelBuilder.Entity<DetalleFactura>().HasData(
            new DetalleFactura
            {
                Id = 1,
                Producto = "Laptop Dell XPS 15",
                Cantidad = 1,
                PrecioUnitario = 1200.00m,
                Subtotal = 1200.00m,
                FacturaId = 1
            },
            new DetalleFactura
            {
                Id = 2,
                Producto = "Mouse Logitech MX Master",
                Cantidad = 1,
                PrecioUnitario = 50.50m,
                Subtotal = 50.50m,
                FacturaId = 1
            },
            new DetalleFactura
            {
                Id = 3,
                Producto = "Teclado Mecánico Keychron K2",
                Cantidad = 2,
                PrecioUnitario = 89.99m,
                Subtotal = 179.98m,
                FacturaId = 2
            },
            new DetalleFactura
            {
                Id = 4,
                Producto = "Monitor LG 27 4K",
                Cantidad = 1,
                PrecioUnitario = 450.00m,
                Subtotal = 450.00m,
                FacturaId = 2
            },
            new DetalleFactura
            {
                Id = 5,
                Producto = "Webcam Logitech C920",
                Cantidad = 1,
                PrecioUnitario = 220.77m,
                Subtotal = 220.77m,
                FacturaId = 2
            },
            new DetalleFactura
            {
                Id = 6,
                Producto = "iPhone 15 Pro",
                Cantidad = 1,
                PrecioUnitario = 1299.99m,
                Subtotal = 1299.99m,
                FacturaId = 3
            },
            new DetalleFactura
            {
                Id = 7,
                Producto = "AirPods Pro",
                Cantidad = 2,
                PrecioUnitario = 249.99m,
                Subtotal = 499.98m,
                FacturaId = 3
            },
            new DetalleFactura
            {
                Id = 8,
                Producto = "Cargador USB-C 65W",
                Cantidad = 1,
                PrecioUnitario = 45.00m,
                Subtotal = 45.00m,
                FacturaId = 3
            },
            new DetalleFactura
            {
                Id = 9,
                Producto = "Cable USB-C a Lightning",
                Cantidad = 3,
                PrecioUnitario = 25.00m,
                Subtotal = 75.00m,
                FacturaId = 3
            }
        );
    }
}
