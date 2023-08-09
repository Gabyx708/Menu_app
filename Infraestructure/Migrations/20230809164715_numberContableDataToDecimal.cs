using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class numberContableDataToDecimal : Migration
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
                    Password = table.Column<string>(type: "longtext", nullable: false)
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
                name: "Recibo",
                columns: table => new
                {
                    IdRecibo = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdDescuento = table.Column<Guid>(type: "char(36)", nullable: false),
                    precioTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Descuento",
                columns: new[] { "IdDescuento", "FechaInicioVigencia", "Porcentaje" },
                values: new object[] { new Guid("9cee74a5-3e88-4769-9bd8-b74b15ad120c"), new DateTime(2023, 8, 9, 13, 47, 14, 904, DateTimeKind.Local).AddTicks(3722), 50m });

            migrationBuilder.InsertData(
                table: "Personal",
                columns: new[] { "IdPersonal", "Apellido", "Dni", "FechaAlta", "FechaIngreso", "FechaNac", "Mail", "Nombre", "Password", "Privilegio", "Telefono" },
                values: new object[,]
                {
                    { new Guid("61bbfebf-958c-496c-ba6d-c38398afa981"), "Díaz", "159357852", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabelladiaz@example.com", "Isabella", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "852963741" },
                    { new Guid("67d18743-b657-4289-b756-a238c3f7fe1d"), "Gómez", "963852741", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "javiergomez@example.com", "Javier", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "159357852" },
                    { new Guid("6fe91755-1404-42b9-9645-411f4eeaf491"), "Fernández", "258963147", new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "diegofernandez@example.com", "Diego", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "741852963" },
                    { new Guid("7ea258c3-3c61-4c61-a8d7-60013f45196b"), "Ramírez", "321654987", new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "anaramirez@example.com", "Ana", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "543216549" },
                    { new Guid("87f44a40-33af-4a45-96f6-f28f41b72f77"), "López", "456789123", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "carloslopez@example.com", "Carlos", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "678912345" },
                    { new Guid("892c9951-c571-4402-b8fd-e885d64e2c93"), "Martínez", "789456123", new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedromartinez@example.com", "Pedro", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "987654321" },
                    { new Guid("9527b880-5fab-4c5b-b1fb-f8d53f803f8e"), "López", "741852963", new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "sofialopez@example.com", "Sofía", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "369258147" },
                    { new Guid("99d70ae9-6506-4e06-ad72-925e65c8b895"), "Hernández", "654123987", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "laurahernandez@example.com", "Laura", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "876543219" },
                    { new Guid("d01636e5-c6e0-4c4f-ab59-8f8a43d2c07c"), "Pérez", "123456789", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "juanperez@example.com", "Juan", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "1234567890" },
                    { new Guid("f8ea11eb-e2a1-47c3-8052-bd031ac7cd9d"), "González", "987654321", new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariagonzalez@example.com", "María", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "0987654321" }
                });

            migrationBuilder.InsertData(
                table: "Platillo",
                columns: new[] { "IdPlatillo", "Activado", "Descripcion", "Precio" },
                values: new object[,]
                {
                    { 1, true, "Ravioli de ricotta y espinacas con salsa de tomate", 1000m },
                    { 2, true, "milanesa a la napolitana", 3000m },
                    { 3, true, "Ceviche de camarón y pescado", 2800m },
                    { 4, true, "Costillas de cerdo a la barbacoa con salsa ahumada", 357m },
                    { 5, true, "Paella mixta de mariscos y pollo", 1890m },
                    { 6, true, "Salmón con verduras salteadas y arroz jazmín", 100m },
                    { 7, true, "Lasaña de carne y verduras con capas de pasta", 1200m },
                    { 8, true, "Pechuga de pollo rellena de queso de cabra ", 1500m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuPlatillo_IdMenu",
                table: "MenuPlatillo",
                column: "IdMenu");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPlatillo_IdPlatillo",
                table: "MenuPlatillo",
                column: "IdPlatillo");

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
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Recibo");

            migrationBuilder.DropTable(
                name: "Descuento");
        }
    }
}
