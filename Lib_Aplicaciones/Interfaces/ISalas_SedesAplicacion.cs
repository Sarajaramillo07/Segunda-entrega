using Lib_Dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ISalas_SedesAplicacion
    {
        void Configurar(string StringConexion);
        List<Salas_Sedes> PorCodigo(Salas_Sedes? entidad);
        List<Salas_Sedes> Listar();
        Salas_Sedes? Guardar(Salas_Sedes? entidad);
        Salas_Sedes? Modificar(Salas_Sedes? entidad);
        Salas_Sedes? Borrar(Salas_Sedes? entidad);
    }
}
