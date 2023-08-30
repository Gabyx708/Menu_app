using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class MenuAppContextForBoot : DbContext
    {
        public MenuAppContextForBoot(DbContextOptions<MenuAppContextForBoot> options)
        : base(options)
        {

        }


        public DbSet<Personal> Personales { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Recibo> Recibos { get; set; }
        public DbSet<Descuento> Descuentos { get; set; }
        public DbSet<PedidoPorMenuPlatillo> PedidosPorMenuPlatillo { get; set; }
        public DbSet<MenuPlatillo> MenuPlatillos { get; set; }
        public DbSet<Platillo> Platillos { get; set; }
        public DbSet<Menu> Menues { get; set; }

    }
}
