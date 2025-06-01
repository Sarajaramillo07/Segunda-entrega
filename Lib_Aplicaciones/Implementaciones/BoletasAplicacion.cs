using lib_aplicaciones.Interfaces;
using Lib_Dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class BoletasAplicacion : IBoletasAplicacion
    {
        private IConexion? IConexion = null;

        public BoletasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Boletas? Borrar(Boletas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Boletas!.Remove(entidad);
            GuardarAuditoria("Borrar Boletas");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Boletas? Guardar(Boletas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Boletas!.Add(entidad);
            GuardarAuditoria("Guardar Boletas");
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Boletas> Listar()
        {
            return this.IConexion!.Boletas!.Take(20).ToList();
        }

        public List<Boletas> PorCodigo(Boletas? entidad)
        {
            return this.IConexion!.Boletas!
                .Where(x => x.Id == entidad!.Id)
                .ToList();
        }

        public Boletas? Modificar(Boletas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            GuardarAuditoria("Modificar Boletas");

            var entry = this.IConexion!.Entry<Boletas>(entidad);
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
            };
            this.IConexion.Auditorias.Add(entidad);
        
        }
    }
}
