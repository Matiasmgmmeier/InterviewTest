using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroFactura = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaEmision = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Estado = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetallesFactura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Producto = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesFactura_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "Email", "FechaRegistro", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, true, "juan.perez@email.com", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan Pérez", "+34 612 345 678" },
                    { 2, true, "maria.garcia@email.com", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "María García", "+34 623 456 789" },
                    { 3, false, "carlos.lopez@email.com", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos López", "+34 634 567 890" }
                });

            migrationBuilder.InsertData(
                table: "Facturas",
                columns: new[] { "Id", "Estado", "FechaEmision", "NumeroFactura", "Total", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Pagada", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FAC-2024-001", 1250.50m, 1 },
                    { 2, "Pendiente", new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "FAC-2024-002", 850.75m, 2 },
                    { 3, "Pagada", new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FAC-2024-003", 2100.00m, 1 }
                });

            migrationBuilder.InsertData(
                table: "DetallesFactura",
                columns: new[] { "Id", "Cantidad", "FacturaId", "PrecioUnitario", "Producto", "Subtotal" },
                values: new object[,]
                {
                    { 1, 1, 1, 1200.00m, "Laptop Dell XPS 15", 1200.00m },
                    { 2, 1, 1, 50.50m, "Mouse Logitech MX Master", 50.50m },
                    { 3, 2, 2, 89.99m, "Teclado Mecánico Keychron K2", 179.98m },
                    { 4, 1, 2, 450.00m, "Monitor LG 27 4K", 450.00m },
                    { 5, 1, 2, 220.77m, "Webcam Logitech C920", 220.77m },
                    { 6, 1, 3, 1299.99m, "iPhone 15 Pro", 1299.99m },
                    { 7, 2, 3, 249.99m, "AirPods Pro", 499.98m },
                    { 8, 1, 3, 45.00m, "Cargador USB-C 65W", 45.00m },
                    { 9, 3, 3, 25.00m, "Cable USB-C a Lightning", 75.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFactura_FacturaId",
                table: "DetallesFactura",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_UsuarioId",
                table: "Facturas",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesFactura");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
