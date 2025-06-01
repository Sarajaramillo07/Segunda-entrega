using lib_aplicaciones.Interfaces;
using Lib_Dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class PlanesAplicacion : IPlanesAplicacion
    {
        private IConexion? IConexion = null;

        public PlanesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Planes? Borrar(Planes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Planes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Planes? Guardar(Planes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Planes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Planes> Listar()
        {
            return this.IConexion!.Planes!.Take(20).ToList();
        }

        public List<Planes> PorCodigo(Planes? entidad)
        {
            return this.IConexion!.Planes!
            .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
            .ToList();
        }

        public Planes? Modificar(Planes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Planes>(entidad);
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
