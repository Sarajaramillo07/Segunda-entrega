using Lib_Dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IDetalles_SnacksAplicacion
    {
        void Configurar(string StringConexion);
        List<Detalles_Snacks> PorCodigo(Detalles_Snacks? entidad);
        List<Detalles_Snacks> Listar();
        Detalles_Snacks? Guardar(Detalles_Snacks? entidad);
        Detalles_Snacks? Modificar(Detalles_Snacks? entidad);
        Detalles_Snacks? Borrar(Detalles_Snacks? entidad);
    }
}
