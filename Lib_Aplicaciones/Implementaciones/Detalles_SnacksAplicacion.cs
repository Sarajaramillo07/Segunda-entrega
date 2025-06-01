using lib_aplicaciones.Interfaces;
using Lib_Dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class Detalles_SnacksAplicacion : IDetalles_SnacksAplicacion
    {
        private IConexion? IConexion = null;

        public Detalles_SnacksAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Detalles_Snacks? Borrar(Detalles_Snacks? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Detalles_Snacks!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Detalles_Snacks? Guardar(Detalles_Snacks? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Detalles_Snacks!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Detalles_Snacks> Listar()
        {
            return this.IConexion!.Detalles_Snacks!.Take(20).ToList();
        }

        public List<Detalles_Snacks> PorCodigo(Detalles_Snacks? entidad)
        {
            return this.IConexion!.Detalles_Snacks!
                .Where(x => x.Id == entidad!.Id)
                .ToList();
        }

        public Detalles_Snacks? Modificar(Detalles_Snacks? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Detalles_Snacks>(entidad);
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
