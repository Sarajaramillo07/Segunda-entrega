using Lib_Dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ISnacksAplicacion
    {
        void Configurar(string StringConexion);
        List<Snacks> PorCodigo(Snacks? entidad);
        List<Snacks> Listar();
        Snacks? Guardar(Snacks? entidad);
        Snacks? Modificar(Snacks? entidad);
        Snacks? Borrar(Snacks? entidad);
    }
}
