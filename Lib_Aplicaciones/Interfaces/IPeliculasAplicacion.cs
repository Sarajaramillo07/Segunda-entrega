using Lib_Dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IPeliculasAplicacion
    {
        void Configurar(string StringConexion);
        List<Peliculas> PorCodigo(Peliculas? entidad);
        List<Peliculas> Listar();
        Peliculas? Guardar(Peliculas? entidad);
        Peliculas? Modificar(Peliculas? entidad);
        Peliculas? Borrar(Peliculas? entidad);
    }
}
