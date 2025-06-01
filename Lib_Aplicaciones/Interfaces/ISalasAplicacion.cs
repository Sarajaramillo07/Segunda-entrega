using Lib_Dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ISalasAplicacion
    {
        void Configurar(string StringConexion);
        List<Salas> PorCodigo(Salas? entidad);
        List<Salas> Listar();
        Salas? Guardar(Salas? entidad);
        Salas? Modificar(Salas? entidad);
        Salas? Borrar(Salas? entidad);
    }
}
