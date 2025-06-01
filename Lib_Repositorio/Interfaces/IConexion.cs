using Lib_Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace lib_repositorios.Interfaces
{                //Hicimos las referencias entre librerias, Lib_Repositorio contiene la dependencia de Lib_Dominio  
    public interface IConexion
    {
        string? StringConexion { get; set; }
        DbSet<Boletas>? Boletas{ get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<CodigoCompras>? CodigoCompras { get; set; }
        DbSet<Detalles_Snacks>? Detalles_Snacks { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Peliculas>? Peliculas { get; set; }
        DbSet<Planes>? Planes { get; set; }
        DbSet<Salas_Sedes>? Salas_Sedes { get; set; }
        DbSet<Salas>? Salas { get; set; }
        DbSet<Sedes>? Sedes { get; set; }
        DbSet<Snacks>? Snacks { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}