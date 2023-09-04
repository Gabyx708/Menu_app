using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class versionv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Descuento",
                columns: table => new
                {
                    IdDescuento = table.Column<Guid>(type: "char(36)", nullable: false),
                    FechaInicioVigencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuento", x => x.IdDescuento);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    IdMenu = table.Column<Guid>(type: "char(36)", nullable: false),
                    FechaConsumo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaCarga = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.IdMenu);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    IdPersonal = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Dni = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    FechaNac = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Mail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Privilegio = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    isAutomatico = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.IdPersonal);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Platillo",
                columns: table => new
                {
                    IdPlatillo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Activado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platillo", x => x.IdPlatillo);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    NumeroPago = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idPersonal = table.Column<Guid>(type: "char(36)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MontoPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAnulado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.NumeroPago);
                    table.ForeignKey(
                        name: "FK_Pagos_Personal_idPersonal",
                        column: x => x.idPersonal,
                        principalTable: "Personal",
                        principalColumn: "IdPersonal",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuPlatillo",
                columns: table => new
                {
                    IdMenuPlatillo = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdMenu = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdPlatillo = table.Column<int>(type: "int", nullable: false),
                    PrecioActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Solicitados = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPlatillo", x => x.IdMenuPlatillo);
                    table.ForeignKey(
                        name: "FK_MenuPlatillo_Menu_IdMenu",
                        column: x => x.IdMenu,
                        principalTable: "Menu",
                        principalColumn: "IdMenu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuPlatillo_Platillo_IdPlatillo",
                        column: x => x.IdPlatillo,
                        principalTable: "Platillo",
                        principalColumn: "IdPlatillo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Recibo",
                columns: table => new
                {
                    IdRecibo = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdDescuento = table.Column<Guid>(type: "char(36)", nullable: false),
                    precioTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumeroPago = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibo", x => x.IdRecibo);
                    table.ForeignKey(
                        name: "FK_Recibo_Descuento_IdDescuento",
                        column: x => x.IdDescuento,
                        principalTable: "Descuento",
                        principalColumn: "IdDescuento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recibo_Pagos_NumeroPago",
                        column: x => x.NumeroPago,
                        principalTable: "Pagos",
                        principalColumn: "NumeroPago");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IdPedido = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdPersonal = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdRecibo = table.Column<Guid>(type: "char(36)", nullable: false),
                    FechaDePedido = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Personal_IdPersonal",
                        column: x => x.IdPersonal,
                        principalTable: "Personal",
                        principalColumn: "IdPersonal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Recibo_IdRecibo",
                        column: x => x.IdRecibo,
                        principalTable: "Recibo",
                        principalColumn: "IdRecibo",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PedidoPorMenuPlatillo",
                columns: table => new
                {
                    IdPedido = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdMenuPlatillo = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoPorMenuPlatillo", x => new { x.IdPedido, x.IdMenuPlatillo });
                    table.ForeignKey(
                        name: "FK_PedidoPorMenuPlatillo_MenuPlatillo_IdMenuPlatillo",
                        column: x => x.IdMenuPlatillo,
                        principalTable: "MenuPlatillo",
                        principalColumn: "IdMenuPlatillo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoPorMenuPlatillo_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPlatillo_IdMenu",
                table: "MenuPlatillo",
                column: "IdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPlatillo_IdPlatillo",
                table: "MenuPlatillo",
                column: "IdPlatillo");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_idPersonal",
                table: "Pagos",
                column: "idPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdPersonal",
                table: "Pedido",
                column: "IdPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdRecibo",
                table: "Pedido",
                column: "IdRecibo");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoPorMenuPlatillo_IdMenuPlatillo",
                table: "PedidoPorMenuPlatillo",
                column: "IdMenuPlatillo");

            migrationBuilder.CreateIndex(
                name: "IX_Recibo_IdDescuento",
                table: "Recibo",
                column: "IdDescuento");

            migrationBuilder.CreateIndex(
                name: "IX_Recibo_NumeroPago",
                table: "Recibo",
                column: "NumeroPago");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoPorMenuPlatillo");

            migrationBuilder.DropTable(
                name: "MenuPlatillo");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Platillo");

            migrationBuilder.DropTable(
                name: "Recibo");

            migrationBuilder.DropTable(
                name: "Descuento");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Personal");
        }
    }
}
