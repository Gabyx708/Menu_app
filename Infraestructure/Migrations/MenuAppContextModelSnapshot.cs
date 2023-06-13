﻿// <auto-generated />
using System;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(MenuAppContext))]
    partial class MenuAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
