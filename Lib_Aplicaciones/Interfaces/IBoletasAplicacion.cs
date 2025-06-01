using Lib_Dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface IBoletasAplicacion
    {
        void Configurar(string StringConexion);
        List<Boletas> PorCodigo(Boletas? entidad);
        List<Boletas> Listar();
        Boletas? Guardar(Boletas? entidad);
        Boletas? Modificar(Boletas? entidad);
        Boletas? Borrar(Boletas? entidad);
    }
}
