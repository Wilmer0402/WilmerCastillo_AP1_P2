using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WilmerCastillo_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combo1",
                columns: table => new
                {
                    CombosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Vendido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combo1", x => x.CombosId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductosId);
                });

            migrationBuilder.CreateTable(
                name: "ComboDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CombosId = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_ComboDetalles_Combo1_CombosId",
                        column: x => x.CombosId,
                        principalTable: "Combo1",
                        principalColumn: "CombosId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboDetalles_Product_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Product",
                        principalColumn: "ProductosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductosId", "Costo", "Descripcion", "Existencia", "Precio" },
                values: new object[,]
                {
                    { 1, 1000.0, "Disco Duro", 20, 1500.0 },
                    { 2, 800.0, "Memoria Ram", 30, 2200.0 },
                    { 3, 3000.0, "Procesador", 50, 3810.0 },
                    { 4, 1310.0, "Memoria Grafica", 40, 2530.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComboDetalles_CombosId",
                table: "ComboDetalles",
                column: "CombosId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDetalles_ProductosId",
                table: "ComboDetalles",
                column: "ProductosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboDetalles");

            migrationBuilder.DropTable(
                name: "Combo1");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
