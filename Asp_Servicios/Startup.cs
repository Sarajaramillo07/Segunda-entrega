using Asp_Servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using Lib_Dominio.Entidades;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;
namespace Asp_Servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfiguration? Configuration { set; get; }
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => {
                x.AllowSynchronousIO =
           true;
            });
            services.Configure<IISServerOptions>(x => {
                x.AllowSynchronousIO = true;
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            // Repositorios
            services.AddScoped<IConexion, Conexion>();
            // Aplicaciones
            services.AddScoped<IBoletasAplicacion, BoletasAplicacion>();
            services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
            services.AddScoped<ICodigoComprasAplicacion, CodigoComprasAplicacion>();
            services.AddScoped<IDetalles_SnacksAplicacion, Detalles_SnacksAplicacion>();
            services.AddScoped<IEmpleadosAplicacion, EmpleadosAplicacion>();
            services.AddScoped<IPeliculasAplicacion, PeliculasAplicacion>();
            services.AddScoped<IPlanesAplicacion, PlanesAplicacion>();
            services.AddScoped<ISalas_SedesAplicacion, Salas_SedesAplicacion>();
            services.AddScoped<ISalasAplicacion, SalasAplicacion>();
            services.AddScoped<ISedesAplicacion, SedesAplicacion>();
            services.AddScoped<ISnacksAplicacion, SnacksAplicacion>();
            services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();
            services.AddScoped<IRolesAplicacion, RolesAplicacion>();
            services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();
            services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
            services.AddScoped<IRoles_tiene_permisosAplicacion, Roles_tiene_permisosAplicacion>();



            // Controladores
            services.AddScoped<TokenController, TokenController>();
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}