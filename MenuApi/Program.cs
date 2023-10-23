using Application.Interfaces.IAuthentication;
using Application.Interfaces.IAutomation;
using Application.Interfaces.IAutorizacionPedido;
using Application.Interfaces.ICostos;
using Application.Interfaces.IDescuento;
using Application.Interfaces.IMenu;
using Application.Interfaces.IMenuPlatillo;
using Application.Interfaces.IPagos;
using Application.Interfaces.IPedido;
using Application.Interfaces.IPedidoPorMenuPlatillo;
using Application.Interfaces.IPersonal;
using Application.Interfaces.IPlatillo;
using Application.Interfaces.IRecibo;
using Application.Tools.Automation;
using Application.UseCase.Automation;
using Application.UseCase.Costos;
using Application.UseCase.Descuentos;
using Application.UseCase.Menues;
using Application.UseCase.MenuPlatillos;
using Application.UseCase.Pagos;
using Application.UseCase.PedidoPorMenuPlatillos;
using Application.UseCase.Pedidos;
using Application.UseCase.Personales;
using Application.UseCase.Platillos;
using Application.UseCase.Recibos;
using Infraestructure.Commands;
using Infraestructure.Persistence;
using Infraestructure.Querys;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Application.Tools.Log;
using System.Text;

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

            //log path file
            string? logPath = builder.Configuration["AppSettings:logPath"];
            Logger.InitializeLogger(logPath);

            //secreto
            string? secret = builder.Configuration.GetSection("AppSettings")["secreto"];

            if (secret == null) { throw new ArgumentNullException(nameof(secret)); }

            //Database
            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            if(connectionString != null)
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
            builder.Services.AddScoped<IAuthenticationService>(
                provider =>
                {
                    return new AuthenticationService(
                        secret,
                        provider.GetRequiredService<IAuthenticacionQuery>(),
                        provider.GetRequiredService<IPersonalService>(),
                        provider.GetRequiredService<IPersonalQuery>(),
                        provider.GetRequiredService<IPersonalCommand>());
                });

            //Pedido
            builder.Services.AddScoped<IPedidoCommand, PedidoCommand>();
            builder.Services.AddScoped<IPedidoQuery, PedidoQuery>();
            builder.Services.AddScoped<IPedidoService, PedidoService>();

            //PedidoPorMenuPlatillo
            builder.Services.AddScoped<IPedidoPorMenuPlatilloCommand, PedidoPorMenuPlatilloCommand>();
            builder.Services.AddScoped<IPedidoPorMenuPlatilloQuery, PedidoPorMenuPlatilloQuery>();
            builder.Services.AddScoped<IPedidoPorMenuPlatilloService, PedidoPorMenuPlatilloService>();

            //Recibo
            builder.Services.AddScoped<IReciboCommand, ReciboCommand>();
            builder.Services.AddScoped<IReciboQuery, ReciboQuery>();
            builder.Services.AddScoped<IReciboService, ReciboService>();

            //autorizaciones pedido
            builder.Services.AddScoped<IRepositoryAutorizacionPedido, RepositoryAutorizacionPedido>();

            //Costos
            builder.Services.AddScoped<ICostoService, CostoService>();

            //Pagos
            builder.Services.AddScoped<IPagoQuery, PagoQuery>();
            builder.Services.AddScoped<IPagoCommand, PagoCommand>();
            builder.Services.AddScoped<IPagoService, PagoService>();

            //Automatizacion de pedidos
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            builder.Services.AddScoped<IAutomation, AutomationDelivery>();

            //Autenticacion
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions =>
             {
                 jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                 {
                     IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(secret)
                 ),
                     ValidIssuer = "menuServ",
                     ValidAudience = "menu",
                     ClockSkew = TimeSpan.FromHours(1)

                 };
             });

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

            //aplica migraciones automaticas
            //using (var scope = app.Services.CreateScope())
            //{ 
            //    var dbContext = scope.ServiceProvider.GetRequiredService<MenuAppContext>();
            //    dbContext.Database.Migrate();
            //}



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            //app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            Logger.LogInformation("app runing...", null);
            app.Run();
        }
    }
}