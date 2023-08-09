using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
            migrationBuilder.DeleteData(
                table: "Descuento",
                keyColumn: "IdDescuento",
                keyValue: new Guid("07e2ee68-b443-4216-a6cd-e3d6b9f93265"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("01d88d77-d1b0-4c16-8061-80ac9959f889"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("0be94c57-f974-40d2-a15d-8793d4e5c58e"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("3e62d58b-ac75-464c-9036-008fd793ebd2"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("3ee08e55-1b09-4de3-9a9c-553fa9e71a46"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("48541ff8-b4f7-44d9-b5c6-1f6e0a1d4020"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("4f0fda4d-fdbf-4a2e-a90f-62bb38ed51c3"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("78217475-9569-445e-b683-d6eaa9da1621"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("b53364b3-32b2-4a03-8e68-aa89b182b4d6"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("b8d5d970-846c-4a77-a898-bc00b5515db6"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("ef23aeea-9661-4cb9-9719-7cea90ca2be9"));

            migrationBuilder.AlterColumn<decimal>(
                name: "precioTotal",
                table: "Recibo",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Platillo",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecioActual",
                table: "MenuPlatillo",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<decimal>(
                name: "Porcentaje",
                table: "Descuento",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Descuento",
                columns: new[] { "IdDescuento", "FechaInicioVigencia", "Porcentaje" },
                values: new object[] { new Guid("8d832d28-e1b2-46af-bc4b-c4937431a01d"), new DateTime(2023, 8, 9, 13, 42, 51, 176, DateTimeKind.Local).AddTicks(3128), 50m });

            migrationBuilder.InsertData(
                table: "Personal",
                columns: new[] { "IdPersonal", "Apellido", "Dni", "FechaAlta", "FechaIngreso", "FechaNac", "Mail", "Nombre", "Password", "Privilegio", "Telefono" },
                values: new object[,]
                {
                    { new Guid("11160e3a-dda3-4a4f-82b0-c8d1fcb55ffc"), "López", "456789123", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "carloslopez@example.com", "Carlos", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "678912345" },
                    { new Guid("58f5f2e5-8bf3-4f18-afd6-8b4462077821"), "Ramírez", "321654987", new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "anaramirez@example.com", "Ana", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "543216549" },
                    { new Guid("62398b7a-6a43-4167-a488-4d916db65b78"), "Pérez", "123456789", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "juanperez@example.com", "Juan", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "1234567890" },
                    { new Guid("6243ed47-44d7-485c-9dec-1907df78d8c5"), "Hernández", "654123987", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "laurahernandez@example.com", "Laura", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "876543219" },
                    { new Guid("9ab05c2b-6348-4637-845b-db58a4ccf414"), "Díaz", "159357852", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabelladiaz@example.com", "Isabella", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "852963741" },
                    { new Guid("acb21e8f-faca-4eab-9165-1a2bca318bee"), "Martínez", "789456123", new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedromartinez@example.com", "Pedro", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "987654321" },
                    { new Guid("ae2db51f-ecc3-457e-92d8-13ae5ba9009c"), "González", "987654321", new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariagonzalez@example.com", "María", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "0987654321" },
                    { new Guid("c224a669-f744-4833-b65c-60d5ed78f2fc"), "Gómez", "963852741", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "javiergomez@example.com", "Javier", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "159357852" },
                    { new Guid("d4d7aea3-ec46-46a1-8300-5bc3dca56170"), "López", "741852963", new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "sofialopez@example.com", "Sofía", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "369258147" },
                    { new Guid("f79bfeb8-add2-4e29-83e8-22f3ba81deae"), "Fernández", "258963147", new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "diegofernandez@example.com", "Diego", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "741852963" }
                });

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 1,
                column: "Precio",
                value: 1000m);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 2,
                column: "Precio",
                value: 3000m);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 3,
                column: "Precio",
                value: 2800m);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 4,
                column: "Precio",
                value: 357m);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 5,
                column: "Precio",
                value: 1890m);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 6,
                column: "Precio",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 7,
                column: "Precio",
                value: 1200m);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 8,
                column: "Precio",
                value: 1500m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Descuento",
                keyColumn: "IdDescuento",
                keyValue: new Guid("8d832d28-e1b2-46af-bc4b-c4937431a01d"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("11160e3a-dda3-4a4f-82b0-c8d1fcb55ffc"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("58f5f2e5-8bf3-4f18-afd6-8b4462077821"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("62398b7a-6a43-4167-a488-4d916db65b78"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("6243ed47-44d7-485c-9dec-1907df78d8c5"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("9ab05c2b-6348-4637-845b-db58a4ccf414"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("acb21e8f-faca-4eab-9165-1a2bca318bee"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("ae2db51f-ecc3-457e-92d8-13ae5ba9009c"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("c224a669-f744-4833-b65c-60d5ed78f2fc"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("d4d7aea3-ec46-46a1-8300-5bc3dca56170"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("f79bfeb8-add2-4e29-83e8-22f3ba81deae"));

            migrationBuilder.AlterColumn<double>(
                name: "precioTotal",
                table: "Recibo",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "Platillo",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioActual",
                table: "MenuPlatillo",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Porcentaje",
                table: "Descuento",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Descuento",
                columns: new[] { "IdDescuento", "FechaInicioVigencia", "Porcentaje" },
                values: new object[] { new Guid("07e2ee68-b443-4216-a6cd-e3d6b9f93265"), new DateTime(2023, 6, 28, 0, 26, 50, 65, DateTimeKind.Local).AddTicks(2131), 50 });

            migrationBuilder.InsertData(
                table: "Personal",
                columns: new[] { "IdPersonal", "Apellido", "Dni", "FechaAlta", "FechaIngreso", "FechaNac", "Mail", "Nombre", "Password", "Privilegio", "Telefono" },
                values: new object[,]
                {
                    { new Guid("01d88d77-d1b0-4c16-8061-80ac9959f889"), "López", "741852963", new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "sofialopez@example.com", "Sofía", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "369258147" },
                    { new Guid("0be94c57-f974-40d2-a15d-8793d4e5c58e"), "Pérez", "123456789", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "juanperez@example.com", "Juan", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "1234567890" },
                    { new Guid("3e62d58b-ac75-464c-9036-008fd793ebd2"), "Martínez", "789456123", new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedromartinez@example.com", "Pedro", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "987654321" },
                    { new Guid("3ee08e55-1b09-4de3-9a9c-553fa9e71a46"), "Fernández", "258963147", new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "diegofernandez@example.com", "Diego", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "741852963" },
                    { new Guid("48541ff8-b4f7-44d9-b5c6-1f6e0a1d4020"), "Ramírez", "321654987", new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "anaramirez@example.com", "Ana", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "543216549" },
                    { new Guid("4f0fda4d-fdbf-4a2e-a90f-62bb38ed51c3"), "Hernández", "654123987", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "laurahernandez@example.com", "Laura", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "876543219" },
                    { new Guid("78217475-9569-445e-b683-d6eaa9da1621"), "Díaz", "159357852", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabelladiaz@example.com", "Isabella", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "852963741" },
                    { new Guid("b53364b3-32b2-4a03-8e68-aa89b182b4d6"), "López", "456789123", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "carloslopez@example.com", "Carlos", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "678912345" },
                    { new Guid("b8d5d970-846c-4a77-a898-bc00b5515db6"), "González", "987654321", new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariagonzalez@example.com", "María", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "0987654321" },
                    { new Guid("ef23aeea-9661-4cb9-9719-7cea90ca2be9"), "Gómez", "963852741", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "javiergomez@example.com", "Javier", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "159357852" }
                });

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 1,
                column: "Precio",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 2,
                column: "Precio",
                value: 3000.0);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 3,
                column: "Precio",
                value: 2800.0);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 4,
                column: "Precio",
                value: 357.0);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 5,
                column: "Precio",
                value: 1890.0);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 6,
                column: "Precio",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 7,
                column: "Precio",
                value: 1200.0);

            migrationBuilder.UpdateData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 8,
                column: "Precio",
                value: 1500.0);
        }
    }
}
