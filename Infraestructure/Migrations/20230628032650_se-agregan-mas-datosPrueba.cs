using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class seagreganmasdatosPrueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("34b500e4-67dd-4a97-8b6b-0c71805b91e0"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("361d4854-d063-4295-bf29-6f2228d8bee5"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("3d0842eb-a90e-4e8a-a2a3-6813753715e6"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("43a22ea3-ae69-42ed-98a9-dcf1536906af"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("7951fc17-1b43-4a08-8643-af09445ae8b2"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("824a4151-f41d-41ef-8705-c4167cf0df8f"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("8dc213b9-4990-4c93-8237-c45a975725ad"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("a1a24b38-75c6-475c-a699-28717db4b931"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("b928beeb-1e74-41d4-9c4e-bb7ca33a5f41"));

            migrationBuilder.DeleteData(
                table: "Personal",
                keyColumn: "IdPersonal",
                keyValue: new Guid("f2488ffb-81fa-4db9-9460-ad33fdbea6a8"));

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

            migrationBuilder.InsertData(
                table: "Platillo",
                columns: new[] { "IdPlatillo", "Activado", "Descripcion", "Precio" },
                values: new object[,]
                {
                    { 1, true, "Ravioli de ricotta y espinacas con salsa de tomate", 1000.0 },
                    { 2, true, "milanesa a la napolitana", 3000.0 },
                    { 3, true, "Ceviche de camarón y pescado", 2800.0 },
                    { 4, true, "Costillas de cerdo a la barbacoa con salsa ahumada", 357.0 },
                    { 5, true, "Paella mixta de mariscos y pollo", 1890.0 },
                    { 6, true, "Salmón con verduras salteadas y arroz jazmín", 100.0 },
                    { 7, true, "Lasaña de carne y verduras con capas de pasta", 1200.0 },
                    { 8, true, "Pechuga de pollo rellena de queso de cabra ", 1500.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Platillo",
                keyColumn: "IdPlatillo",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "Personal",
                columns: new[] { "IdPersonal", "Apellido", "Dni", "FechaAlta", "FechaIngreso", "FechaNac", "Mail", "Nombre", "Password", "Privilegio", "Telefono" },
                values: new object[,]
                {
                    { new Guid("34b500e4-67dd-4a97-8b6b-0c71805b91e0"), "Fernández", "258963147", new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "diegofernandez@example.com", "Diego", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "741852963" },
                    { new Guid("361d4854-d063-4295-bf29-6f2228d8bee5"), "Pérez", "123456789", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "juanperez@example.com", "Juan", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "1234567890" },
                    { new Guid("3d0842eb-a90e-4e8a-a2a3-6813753715e6"), "Ramírez", "321654987", new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "anaramirez@example.com", "Ana", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "543216549" },
                    { new Guid("43a22ea3-ae69-42ed-98a9-dcf1536906af"), "López", "456789123", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "carloslopez@example.com", "Carlos", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "678912345" },
                    { new Guid("7951fc17-1b43-4a08-8643-af09445ae8b2"), "Gómez", "963852741", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "javiergomez@example.com", "Javier", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "159357852" },
                    { new Guid("824a4151-f41d-41ef-8705-c4167cf0df8f"), "Díaz", "159357852", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabelladiaz@example.com", "Isabella", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "852963741" },
                    { new Guid("8dc213b9-4990-4c93-8237-c45a975725ad"), "Hernández", "654123987", new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "laurahernandez@example.com", "Laura", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "876543219" },
                    { new Guid("a1a24b38-75c6-475c-a699-28717db4b931"), "Martínez", "789456123", new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedromartinez@example.com", "Pedro", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "987654321" },
                    { new Guid("b928beeb-1e74-41d4-9c4e-bb7ca33a5f41"), "González", "987654321", new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariagonzalez@example.com", "María", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "0987654321" },
                    { new Guid("f2488ffb-81fa-4db9-9460-ad33fdbea6a8"), "López", "741852963", new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "sofialopez@example.com", "Sofía", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5", 2, "369258147" }
                });
        }
    }
}
