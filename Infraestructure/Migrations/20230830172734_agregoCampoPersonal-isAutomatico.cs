using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class agregoCampoPersonalisAutomatico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Descuento",
                keyColumn: "IdDescuento",
                keyValue: new Guid("9cee74a5-3e88-4769-9bd8-b74b15ad120c"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("61bbfebf-958c-496c-ba6d-c38398afa981"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("67d18743-b657-4289-b756-a238c3f7fe1d"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("6fe91755-1404-42b9-9645-411f4eeaf491"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("7ea258c3-3c61-4c61-a8d7-60013f45196b"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("87f44a40-33af-4a45-96f6-f28f41b72f77"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("892c9951-c571-4402-b8fd-e885d64e2c93"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("9527b880-5fab-4c5b-b1fb-f8d53f803f8e"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("99d70ae9-6506-4e06-ad72-925e65c8b895"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("d01636e5-c6e0-4c4f-ab59-8f8a43d2c07c"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("f8ea11eb-e2a1-47c3-8052-bd031ac7cd9d"));

            migrationBuilder.AddColumn<bool>(
                name: "isAutomatico",
                table: "Personal",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Descuento",
                columns: new[] { "IdDescuento", "FechaInicioVigencia", "Porcentaje" },
                values: new object[] { new Guid("f00e32fc-9609-407b-99a4-3d9669451a23"), new DateTime(2023, 8, 30, 14, 27, 34, 379, DateTimeKind.Local).AddTicks(2524), 50m });

            migrationBuilder.InsertData(
                table: "Personal",
                columns: new[] { "IdPersonal", "Apellido", "Dni", "FechaAlta", "FechaIngreso", "FechaNac", "Mail", "Nombre", "Password", "Privilegio", "Telefono", "isAutomatico" },
                values: new object[,]
                {
                    { new Guid("14976be7-f9f7-416a-a4b2-8aed79659705"), "Martínez", "789456123", new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedromartinez@example.com", "Pedro", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "987654321", false },
                    { new Guid("2a3edb1b-9cfd-4960-b49d-05af0edf3e81"), "López", "456789123", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "carloslopez@example.com", "Carlos", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "678912345", false },
                    { new Guid("512bc6a3-d7f2-4582-917f-31387094f7d2"), "Gómez", "963852741", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "javiergomez@example.com", "Javier", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "159357852", false },
                    { new Guid("5992ca8f-d106-4842-a183-c22dbf6d92a9"), "Hernández", "654123987", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "laurahernandez@example.com", "Laura", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "876543219", false },
                    { new Guid("59cf47fb-7300-4e2c-ac24-fe560a9bbd3e"), "Pérez", "123456789", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "juanperez@example.com", "Juan", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "1234567890", false },
                    { new Guid("6685deb4-5c46-49cb-ac2f-55ba8c130dd6"), "López", "741852963", new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "sofialopez@example.com", "Sofía", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "369258147", false },
                    { new Guid("9ba191cf-51ba-40da-bba8-4fc6f4a28fca"), "Díaz", "159357852", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabelladiaz@example.com", "Isabella", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "852963741", false },
                    { new Guid("a7d90f05-e9a2-488f-8043-45f1df5576f4"), "Ramírez", "321654987", new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "anaramirez@example.com", "Ana", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "543216549", false },
                    { new Guid("a8f2a1a8-19a9-4f6e-b446-317c8f49958a"), "González", "987654321", new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariagonzalez@example.com", "María", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "0987654321", false },
                    { new Guid("d7530b78-86ce-46ad-927f-80b1343f7a88"), "Fernández", "258963147", new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "diegofernandez@example.com", "Diego", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "741852963", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Descuento",
                keyColumn: "IdDescuento",
                keyValue: new Guid("f00e32fc-9609-407b-99a4-3d9669451a23"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("14976be7-f9f7-416a-a4b2-8aed79659705"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("2a3edb1b-9cfd-4960-b49d-05af0edf3e81"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("512bc6a3-d7f2-4582-917f-31387094f7d2"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("5992ca8f-d106-4842-a183-c22dbf6d92a9"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("59cf47fb-7300-4e2c-ac24-fe560a9bbd3e"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("6685deb4-5c46-49cb-ac2f-55ba8c130dd6"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("9ba191cf-51ba-40da-bba8-4fc6f4a28fca"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("a7d90f05-e9a2-488f-8043-45f1df5576f4"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("a8f2a1a8-19a9-4f6e-b446-317c8f49958a"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("d7530b78-86ce-46ad-927f-80b1343f7a88"));

            migrationBuilder.DropColumn(
                name: "isAutomatico",
                table: "Personal");

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
        }
    }
}
