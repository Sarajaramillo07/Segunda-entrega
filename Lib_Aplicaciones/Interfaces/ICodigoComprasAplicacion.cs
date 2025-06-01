using Lib_Dominio.Entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface ICodigoComprasAplicacion
    {
        void Configurar(string StringConexion);
        List<CodigoCompras> PorCodigo(CodigoCompras? entidad);
        List<CodigoCompras> Listar();
        CodigoCompras? Guardar(CodigoCompras? entidad);
        CodigoCompras? Modificar(CodigoCompras? entidad);
        CodigoCompras? Borrar(CodigoCompras? entidad);
    }
}