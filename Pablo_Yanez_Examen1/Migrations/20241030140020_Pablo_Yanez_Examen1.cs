using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pablo_Yanez_Examen1.Migrations
{
    /// <inheritdoc />
    public partial class Pablo_Yanez_Examen1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PYanez",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Sueldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Registro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PYanez", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Celular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Año = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PYanezId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Celular_PYanez_PYanezId",
                        column: x => x.PYanezId,
                        principalTable: "PYanez",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Celular_PYanezId",
                table: "Celular",
                column: "PYanezId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Celular");

            migrationBuilder.DropTable(
                name: "PYanez");
        }
    }
}
