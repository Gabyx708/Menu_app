﻿// <auto-generated />
using System;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(MenuAppContext))]
    [Migration("20230628032650_se-agregan-mas-datosPrueba")]
    partial class seagreganmasdatosPrueba
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Descuento", b =>
                {
                    b.Property<Guid>("IdDescuento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("FechaInicioVigencia")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Porcentaje")
                        .HasColumnType("int");

                    b.HasKey("IdDescuento");

                    b.ToTable("Descuento", (string)null);

                    b.HasData(
                        new
                        {
                            IdDescuento = new Guid("07e2ee68-b443-4216-a6cd-e3d6b9f93265"),
                            FechaInicioVigencia = new DateTime(2023, 6, 28, 0, 26, 50, 65, DateTimeKind.Local).AddTicks(2131),
                            Porcentaje = 50
                        });
                });

            modelBuilder.Entity("Domain.Entities.Menu", b =>
                {
                    b.Property<Guid>("IdMenu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("FechaCarga")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaCierre")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaConsumo")
                        .HasColumnType("datetime(6)");

                    b.HasKey("IdMenu");

                    b.ToTable("Menu", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MenuPlatillo", b =>
                {
                    b.Property<Guid>("IdMenuPlatillo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdMenu")
                        .HasColumnType("char(36)");

                    b.Property<int>("IdPlatillo")
                        .HasColumnType("int");

                    b.Property<double>("PrecioActual")
                        .HasColumnType("double");

                    b.Property<int>("Solicitados")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("IdMenuPlatillo");

                    b.HasIndex("IdMenu");

                    b.HasIndex("IdPlatillo");

                    b.ToTable("MenuPlatillo", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.Property<Guid>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("FechaDePedido")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("IdPersonal")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdRecibo")
                        .HasColumnType("char(36)");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdPersonal");

                    b.HasIndex("IdRecibo");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.PedidoPorMenuPlatillo", b =>
                {
                    b.Property<Guid>("IdPedido")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdMenuPlatillo")
                        .HasColumnType("char(36)");

                    b.HasKey("IdPedido", "IdMenuPlatillo");

                    b.HasIndex("IdMenuPlatillo");

                    b.ToTable("PedidoPorMenuPlatillo", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Personal", b =>
                {
                    b.Property<Guid>("IdPersonal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaNac")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Privilegio")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("IdPersonal");

                    b.ToTable("Personal", (string)null);

                    b.HasData(
                        new
                        {
                            IdPersonal = new Guid("0be94c57-f974-40d2-a15d-8793d4e5c58e"),
                            Apellido = "Pérez",
                            Dni = "123456789",
                            FechaAlta = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaIngreso = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaNac = new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mail = "juanperez@example.com",
                            Nombre = "Juan",
                            Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                            Privilegio = 2,
                            Telefono = "1234567890"
                        },
                        new
                        {
                            IdPersonal = new Guid("b8d5d970-846c-4a77-a898-bc00b5515db6"),
                            Apellido = "González",
                            Dni = "987654321",
                            FechaAlta = new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaIngreso = new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaNac = new DateTime(1988, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mail = "mariagonzalez@example.com",
                            Nombre = "María",
                            Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                            Privilegio = 2,
                            Telefono = "0987654321"
                        },
                        new
                        {
                            IdPersonal = new Guid("b53364b3-32b2-4a03-8e68-aa89b182b4d6"),
                            Apellido = "López",
                            Dni = "456789123",
                            FechaAlta = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaIngreso = new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaNac = new DateTime(1995, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mail = "carloslopez@example.com",
                            Nombre = "Carlos",
                            Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                            Privilegio = 2,
                            Telefono = "678912345"
                        },
                        new
                        {
                            IdPersonal = new Guid("48541ff8-b4f7-44d9-b5c6-1f6e0a1d4020"),
                            Apellido = "Ramírez",
                            Dni = "321654987",
                            FechaAlta = new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaIngreso = new DateTime(2020, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaNac = new DateTime(1992, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mail = "anaramirez@example.com",
                            Nombre = "Ana",
                            Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                            Privilegio = 2,
                            Telefono = "543216549"
                        },
                        new
                        {
                            IdPersonal = new Guid("3e62d58b-ac75-464c-9036-008fd793ebd2"),
                            Apellido = "Martínez",
                            Dni = "789456123",
                            FechaAlta = new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaIngreso = new DateTime(2021, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaNac = new DateTime(1985, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mail = "pedromartinez@example.com",
                            Nombre = "Pedro",
                            Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                            Privilegio = 2,
                            Telefono = "987654321"
                        },
                        new
                        {
                            IdPersonal = new Guid("4f0fda4d-fdbf-4a2e-a90f-62bb38ed51c3"),
                            Apellido = "Hernández",
                            Dni = "654123987",
                            FechaAlta = new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaIngreso = new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaNac = new DateTime(1991, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mail = "laurahernandez@example.com",
                            Nombre = "Laura",
                            Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                            Privilegio = 2,
                            Telefono = "876543219"
                        },
                        new
                        {
                            IdPersonal = new Guid("3ee08e55-1b09-4de3-9a9c-553fa9e71a46"),
                            Apellido = "Fernández",
                            Dni = "258963147",
                            FechaAlta = new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaIngreso = new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaNac = new DateTime(1987, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mail = "diegofernandez@example.com",
                            Nombre = "Diego",
                            Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                            Privilegio = 2,
                            Telefono = "741852963"
                        },
                        new
                        {
                            IdPersonal = new Guid("01d88d77-d1b0-4c16-8061-80ac9959f889"),
                            Apellido = "López",
                            Dni = "741852963",
                            FechaAlta = new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaIngreso = new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaNac = new DateTime(1993, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mail = "sofialopez@example.com",
                            Nombre = "Sofía",
                            Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                            Privilegio = 2,
                            Telefono = "369258147"
                        },
                        new
                        {
                            IdPersonal = new Guid("ef23aeea-9661-4cb9-9719-7cea90ca2be9"),
                            Apellido = "Gómez",
                            Dni = "963852741",
                            FechaAlta = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaIngreso = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaNac = new DateTime(1986, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mail = "javiergomez@example.com",
                            Nombre = "Javier",
                            Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                            Privilegio = 2,
                            Telefono = "159357852"
                        },
                        new
                        {
                            IdPersonal = new Guid("78217475-9569-445e-b683-d6eaa9da1621"),
                            Apellido = "Díaz",
                            Dni = "159357852",
                            FechaAlta = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaIngreso = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaNac = new DateTime(1994, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mail = "isabelladiaz@example.com",
                            Nombre = "Isabella",
                            Password = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5",
                            Privilegio = 2,
                            Telefono = "852963741"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Platillo", b =>
                {
                    b.Property<int>("IdPlatillo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Activado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Precio")
                        .HasColumnType("double");

                    b.HasKey("IdPlatillo");

                    b.ToTable("Platillo", (string)null);

                    b.HasData(
                        new
                        {
                            IdPlatillo = 1,
                            Activado = true,
                            Descripcion = "Ravioli de ricotta y espinacas con salsa de tomate",
                            Precio = 1000.0
                        },
                        new
                        {
                            IdPlatillo = 2,
                            Activado = true,
                            Descripcion = "milanesa a la napolitana",
                            Precio = 3000.0
                        },
                        new
                        {
                            IdPlatillo = 3,
                            Activado = true,
                            Descripcion = "Ceviche de camarón y pescado",
                            Precio = 2800.0
                        },
                        new
                        {
                            IdPlatillo = 4,
                            Activado = true,
                            Descripcion = "Costillas de cerdo a la barbacoa con salsa ahumada",
                            Precio = 357.0
                        },
                        new
                        {
                            IdPlatillo = 5,
                            Activado = true,
                            Descripcion = "Paella mixta de mariscos y pollo",
                            Precio = 1890.0
                        },
                        new
                        {
                            IdPlatillo = 6,
                            Activado = true,
                            Descripcion = "Salmón con verduras salteadas y arroz jazmín",
                            Precio = 100.0
                        },
                        new
                        {
                            IdPlatillo = 7,
                            Activado = true,
                            Descripcion = "Lasaña de carne y verduras con capas de pasta",
                            Precio = 1200.0
                        },
                        new
                        {
                            IdPlatillo = 8,
                            Activado = true,
                            Descripcion = "Pechuga de pollo rellena de queso de cabra ",
                            Precio = 1500.0
                        });
                });

            modelBuilder.Entity("Domain.Entities.Recibo", b =>
                {
                    b.Property<Guid>("IdRecibo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdDescuento")
                        .HasColumnType("char(36)");

                    b.Property<double>("precioTotal")
                        .HasColumnType("double");

                    b.HasKey("IdRecibo");

                    b.HasIndex("IdDescuento");

                    b.ToTable("Recibo", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MenuPlatillo", b =>
                {
                    b.HasOne("Domain.Entities.Menu", "Menu")
                        .WithMany("MenuPlatillos")
                        .HasForeignKey("IdMenu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Platillo", "Platillo")
                        .WithMany("MenuPlatillos")
                        .HasForeignKey("IdPlatillo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Platillo");
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.HasOne("Domain.Entities.Personal", "Personal")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdPersonal")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Recibo", "Recibo")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdRecibo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Personal");

                    b.Navigation("Recibo");
                });

            modelBuilder.Entity("Domain.Entities.PedidoPorMenuPlatillo", b =>
                {
                    b.HasOne("Domain.Entities.MenuPlatillo", "MenuPlatillo")
                        .WithMany("PedidosPorMenuPlatillo")
                        .HasForeignKey("IdMenuPlatillo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Pedido", "Pedido")
                        .WithMany("PedidosPorMenuPlatillo")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuPlatillo");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Domain.Entities.Recibo", b =>
                {
                    b.HasOne("Domain.Entities.Descuento", "descuento")
                        .WithMany("Recibos")
                        .HasForeignKey("IdDescuento")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("descuento");
                });

            modelBuilder.Entity("Domain.Entities.Descuento", b =>
                {
                    b.Navigation("Recibos");
                });

            modelBuilder.Entity("Domain.Entities.Menu", b =>
                {
                    b.Navigation("MenuPlatillos");
                });

            modelBuilder.Entity("Domain.Entities.MenuPlatillo", b =>
                {
                    b.Navigation("PedidosPorMenuPlatillo");
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.Navigation("PedidosPorMenuPlatillo");
                });

            modelBuilder.Entity("Domain.Entities.Personal", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Domain.Entities.Platillo", b =>
                {
                    b.Navigation("MenuPlatillos");
                });

            modelBuilder.Entity("Domain.Entities.Recibo", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}