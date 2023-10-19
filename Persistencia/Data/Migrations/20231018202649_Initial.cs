using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre Usuario")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Correo Usuario")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, comment: "Telefono")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre Usuario")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Direccion Usuario")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, comment: "Telefono")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoMovimineto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimineto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Correo Usuario")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contraseña = table.Column<string>(type: "Varchar(15)", maxLength: 15, nullable: false, comment: "Contraseña")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Veterinario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especialidad = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Raza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEspecieFK = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raza_Especies_IdEspecieFK",
                        column: x => x.IdEspecieFK,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CantidadDisponible = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IdLaboratorioFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamento_Laboratorios_IdLaboratorioFK",
                        column: x => x.IdLaboratorioFK,
                        principalTable: "Laboratorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RolUsuarios",
                columns: table => new
                {
                    IdUserFK = table.Column<int>(type: "int", nullable: false),
                    IdRolFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuarios", x => new { x.IdUserFK, x.IdRolFK });
                    table.ForeignKey(
                        name: "FK_RolUsuarios_Roles_IdRolFK",
                        column: x => x.IdRolFK,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsuarios_Usuarios_IdUserFK",
                        column: x => x.IdUserFK,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPropietarioFK = table.Column<int>(type: "int", nullable: false),
                    IdEspecieFK = table.Column<int>(type: "int", nullable: false),
                    IdRazaFK = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascotas_Especies_IdEspecieFK",
                        column: x => x.IdEspecieFK,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mascotas_Propietario_IdPropietarioFK",
                        column: x => x.IdPropietarioFK,
                        principalTable: "Propietario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mascotas_Raza_IdRazaFK",
                        column: x => x.IdRazaFK,
                        principalTable: "Raza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicamentoProveedores",
                columns: table => new
                {
                    IdMedicamnetoFK = table.Column<int>(type: "int", nullable: false),
                    IdProveedorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentoProveedores", x => new { x.IdProveedorFK, x.IdMedicamnetoFK });
                    table.ForeignKey(
                        name: "FK_MedicamentoProveedores_Medicamento_IdMedicamnetoFK",
                        column: x => x.IdMedicamnetoFK,
                        principalTable: "Medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentoProveedores_Proveedores_IdProveedorFK",
                        column: x => x.IdProveedorFK,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovimientoMedic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProductoFK = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    IdTipoMovimientoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoMedic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoMedic_Medicamento_IdProductoFK",
                        column: x => x.IdProductoFK,
                        principalTable: "Medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientoMedic_TipoMovimineto_IdTipoMovimientoFK",
                        column: x => x.IdTipoMovimientoFK,
                        principalTable: "TipoMovimineto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMascota = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Hora = table.Column<TimeOnly>(type: "time", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdVeterinariaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cita_Mascotas_IdMascota",
                        column: x => x.IdMascota,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Veterinario_IdVeterinariaFK",
                        column: x => x.IdVeterinariaFK,
                        principalTable: "Veterinario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdProductoFK = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdMovMedicFK = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleMovimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_Medicamento_IdProductoFK",
                        column: x => x.IdProductoFK,
                        principalTable: "Medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_MovimientoMedic_IdMovMedicFK",
                        column: x => x.IdMovMedicFK,
                        principalTable: "MovimientoMedic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TratamientosMedicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    IdCitaFK = table.Column<int>(type: "int", nullable: false),
                    IdMedicamentoFK = table.Column<int>(type: "int", nullable: false),
                    Dosis = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaAdministracion = table.Column<DateOnly>(type: "date", nullable: false),
                    Observacion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamientosMedicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamientosMedicos_Cita_Id",
                        column: x => x.Id,
                        principalTable: "Cita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TratamientosMedicos_Medicamento_IdMedicamentoFK",
                        column: x => x.IdMedicamentoFK,
                        principalTable: "Medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdMascota",
                table: "Cita",
                column: "IdMascota");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_IdVeterinariaFK",
                table: "Cita",
                column: "IdVeterinariaFK");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdMovMedicFK",
                table: "DetalleMovimiento",
                column: "IdMovMedicFK");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdProductoFK",
                table: "DetalleMovimiento",
                column: "IdProductoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_IdEspecieFK",
                table: "Mascotas",
                column: "IdEspecieFK");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_IdPropietarioFK",
                table: "Mascotas",
                column: "IdPropietarioFK");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_IdRazaFK",
                table: "Mascotas",
                column: "IdRazaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_IdLaboratorioFK",
                table: "Medicamento",
                column: "IdLaboratorioFK");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentoProveedores_IdMedicamnetoFK",
                table: "MedicamentoProveedores",
                column: "IdMedicamnetoFK");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoMedic_IdProductoFK",
                table: "MovimientoMedic",
                column: "IdProductoFK");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoMedic_IdTipoMovimientoFK",
                table: "MovimientoMedic",
                column: "IdTipoMovimientoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Raza_IdEspecieFK",
                table: "Raza",
                column: "IdEspecieFK");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuarios_IdRolFK",
                table: "RolUsuarios",
                column: "IdRolFK");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosMedicos_IdMedicamentoFK",
                table: "TratamientosMedicos",
                column: "IdMedicamentoFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleMovimiento");

            migrationBuilder.DropTable(
                name: "MedicamentoProveedores");

            migrationBuilder.DropTable(
                name: "RolUsuarios");

            migrationBuilder.DropTable(
                name: "TratamientosMedicos");

            migrationBuilder.DropTable(
                name: "MovimientoMedic");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "TipoMovimineto");

            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "Veterinario");

            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "Propietario");

            migrationBuilder.DropTable(
                name: "Raza");

            migrationBuilder.DropTable(
                name: "Especies");
        }
    }
}
