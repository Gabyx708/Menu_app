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
    [Migration("20230831162525_isAutomatico")]
    partial class isAutomatico
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

                    b.Property<decimal>("Porcentaje")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdDescuento");

                    b.ToTable("Descuento", (string)null);

                    b.HasData(
                        new
                        {
                            IdDescuento = new Guid("b0975168-efaf-4ae1-b8e8-5481c335abf6"),
                            FechaInicioVigencia = new DateTime(2023, 8, 31, 13, 25, 25, 777, DateTimeKind.Local).AddTicks(5414),
                            Porcentaje = 50m
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

                    b.Property<decimal>("PrecioActual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Solicitados")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("IdMenuPlatillo");

                    b.HasIndex("IdMenu");

                    b.HasIndex("IdPlatillo");

                    b.ToTable("MenuPlatillo", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pago", b =>
                {
                    b.Property<long>("NumeroPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsAnulado")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("MontoPagado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("idPersonal")
                        .HasColumnType("char(36)");

                    b.HasKey("NumeroPago");

                    b.HasIndex("idPersonal");

                    b.ToTable("Pagos", (string)null);
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

                    b.Property<bool>("isAutomatico")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("IdPersonal");

                    b.ToTable("Personal", (string)null);

                    b.HasData(
                        new
                        {
                            IdPersonal = new Guid("530e4ba3-9664-4375-bbcc-7c59094d25ae"),
                            Apellido = "Aker",
                            Dni = "administrador",
                            FechaAlta = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaIngreso = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaNac = new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Mail = "sistemas@tecnaingenieria.com",
                            Nombre = "Administrador",
                            Password = "99c1fcf52fc18a9417f60d0e6e7119957fc5638f4ee80ff04fe91bdd5763715d",
                            Privilegio = 1,
                            Telefono = "1234567890",
                            isAutomatico = false
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

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPlatillo");

                    b.ToTable("Platillo", (string)null);

                    b.HasData(
                        new
                        {
                            IdPlatillo = 1,
                            Activado = true,
                            Descripcion = "Ravioli de ricotta y espinacas con salsa de tomate",
                            Precio = 1000m
                        },
                        new
                        {
                            IdPlatillo = 2,
                            Activado = true,
                            Descripcion = "milanesa a la napolitana",
                            Precio = 3000m
                        },
                        new
                        {
                            IdPlatillo = 3,
                            Activado = true,
                            Descripcion = "Ceviche de camarón y pescado",
                            Precio = 2800m
                        },
                        new
                        {
                            IdPlatillo = 4,
                            Activado = true,
                            Descripcion = "Costillas de cerdo a la barbacoa con salsa ahumada",
                            Precio = 357m
                        },
                        new
                        {
                            IdPlatillo = 5,
                            Activado = true,
                            Descripcion = "Paella mixta de mariscos y pollo",
                            Precio = 1890m
                        },
                        new
                        {
                            IdPlatillo = 6,
                            Activado = true,
                            Descripcion = "Salmón con verduras salteadas y arroz jazmín",
                            Precio = 100m
                        },
                        new
                        {
                            IdPlatillo = 7,
                            Activado = true,
                            Descripcion = "Lasaña de carne y verduras con capas de pasta",
                            Precio = 1200m
                        },
                        new
                        {
                            IdPlatillo = 8,
                            Activado = true,
                            Descripcion = "Pechuga de pollo rellena de queso de cabra ",
                            Precio = 1500m
                        });
                });

            modelBuilder.Entity("Domain.Entities.Recibo", b =>
                {
                    b.Property<Guid>("IdRecibo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdDescuento")
                        .HasColumnType("char(36)");

                    b.Property<long?>("NumeroPago")
                        .HasColumnType("bigint");

                    b.Property<decimal>("precioTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdRecibo");

                    b.HasIndex("IdDescuento");

                    b.HasIndex("NumeroPago");

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

            modelBuilder.Entity("Domain.Entities.Pago", b =>
                {
                    b.HasOne("Domain.Entities.Personal", "Personal")
                        .WithMany("pagos")
                        .HasForeignKey("idPersonal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personal");
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

                    b.HasOne("Domain.Entities.Pago", "pago")
                        .WithMany("Recibos")
                        .HasForeignKey("NumeroPago");

                    b.Navigation("descuento");

                    b.Navigation("pago");
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

            modelBuilder.Entity("Domain.Entities.Pago", b =>
                {
                    b.Navigation("Recibos");
                });

            modelBuilder.Entity("Domain.Entities.Pedido", b =>
                {
                    b.Navigation("PedidosPorMenuPlatillo");
                });

            modelBuilder.Entity("Domain.Entities.Personal", b =>
                {
                    b.Navigation("Pedidos");

                    b.Navigation("pagos");
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