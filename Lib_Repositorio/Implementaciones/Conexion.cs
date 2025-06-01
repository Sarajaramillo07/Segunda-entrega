using Lib_Dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_repositorios.Implementaciones
    // esta clase es para controlar la conexión de la base de datos 
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
      
        public DbSet<Boletas>? Boletas { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<CodigoCompras>? CodigoCompras { get; set; }
        public DbSet<Detalles_Snacks>? Detalles_Snacks { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Peliculas>? Peliculas { get; set; }
        public DbSet<Planes>? Planes { get; set; }
        public DbSet<Salas_Sedes>? Salas_Sedes { get; set; }
        public DbSet<Salas>? Salas { get; set; }
        public DbSet<Sedes>? Sedes { get; set; }
        public DbSet<Snacks>? Snacks { get; set; }
    }
}