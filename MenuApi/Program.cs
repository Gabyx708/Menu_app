using Application.Interfaces.IAuthentication;
using Application.Interfaces.IDescuento;
using Application.Interfaces.IMenu;
using Application.Interfaces.IMenuPlatillo;
using Application.Interfaces.IPedido;
using Application.Interfaces.IPedidoPorMenuPlatillo;
using Application.Interfaces.IPersonal;
using Application.Interfaces.IPlatillo;
using Application.UseCase.Descuentos;
using Application.UseCase.Menues;
using Application.UseCase.MenuPlatillos;
using Application.UseCase.PedidoPorMenuPlatillos;
using Application.UseCase.Pedidos;
using Application.UseCase.Personales;
using Application.UseCase.Platillos;
using Infraestructure.Commands;
using Infraestructure.Persistence;
using Infraestructure.Querys;
using Microsoft.EntityFrameworkCore;

namespace MenuApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //custom

            //Database
            var connectionString = builder.Configuration["ConnectionString"];
            builder.Services.AddDbContext<MenuAppContext>(options => options.UseMySQL(connectionString));

            //Personal
            builder.Services.AddScoped<IPersonalCommand, PersonalCommand>();
            builder.Services.AddScoped<IPersonalQuery, PersonalQuery>();
            builder.Services.AddScoped<IPersonalService, PersonalService>();

            //Platillos
            builder.Services.AddScoped<IPlatilloQuery, PlatilloQuery>();
            builder.Services.AddScoped<IPlatilloCommand, PlatilloCommand>();
            builder.Services.AddScoped<IPlatilloService, PlatilloService>();

            //Menu
            builder.Services.AddScoped<IMenuCommand, MenuCommand>();
            builder.Services.AddScoped<IMenuQuery, MenuQuery>();
            builder.Services.AddScoped<IMenuService, MenuService>();

            //MenuPlatillo
            builder.Services.AddScoped<IMenuPlatilloCommand, MenuPlatilloCommand>();
            builder.Services.AddScoped<IMenuPlatilloQuery, MenuPlatilloQuery>();
            builder.Services.AddScoped<IMenuPlatilloService, MenuPlatilloService>();

            //Descuento
            builder.Services.AddScoped<IDescuentoCommand, DescuentoCommand>();
            builder.Services.AddScoped<IDescuentoQuery, DescuentoQuery>();
            builder.Services.AddScoped<IDescuentoService, DescuentoService>();

            //autenticacion
            builder.Services.AddScoped<IAuthenticacionQuery, AutehenticationQuery>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            //Pedido
            builder.Services.AddScoped<IPedidoCommand, PedidoCommand>();
            builder.Services.AddScoped<IPedidoQuery, PedidoQuery>();
            builder.Services.AddScoped<IPedidoService, PedidoService>();

            //PedidoPorMenuPlatillo
            builder.Services.AddScoped<IPedidoPorMenuPlatilloCommand, PedidoPorMenuPlatilloCommand>();
            builder.Services.AddScoped<IPedidoPorMenuPlatilloQuery, PedidoPorMenuPlatilloQuery>();
            builder.Services.AddScoped<IPedidoPorMenuPlatilloService, PedidoPorMenuPlatilloService>();


            //CORS deshabilitar
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}