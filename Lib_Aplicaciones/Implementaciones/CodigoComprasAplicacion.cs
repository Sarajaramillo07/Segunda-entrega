using lib_aplicaciones.Interfaces;
using Lib_Dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class CodigoComprasAplicacion : ICodigoComprasAplicacion
    {
        private IConexion? IConexion = null;

        public CodigoComprasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public CodigoCompras? Borrar(CodigoCompras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.CodigoCompras!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public CodigoCompras? Guardar(CodigoCompras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.CodigoCompras!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<CodigoCompras> Listar()
        {
            return this.IConexion!.CodigoCompras!.Take(20).ToList();
        }

        public List<CodigoCompras> PorCodigo(CodigoCompras? entidad)
        {
            return this.IConexion!.CodigoCompras!
            .Where(x => x.Codigo!.Contains(entidad!.Codigo!))
            .ToList();
        }

        public CodigoCompras? Modificar(CodigoCompras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<CodigoCompras>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public void GuardarAuditoria(string? accion)
        {
            var con = this.IConexion.Auditorias;
            var entidad = new Auditorias();
            {
                entidad.Usuario = 1;
                entidad.Accion = accion;
                entidad.FechaHora = DateTime.Now;
            }
            ;
            this.IConexion.Auditorias.Add(entidad);

        }


    }
}
