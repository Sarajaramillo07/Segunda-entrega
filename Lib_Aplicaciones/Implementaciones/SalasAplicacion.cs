using lib_aplicaciones.Interfaces;
using Lib_Dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class SalasAplicacion : ISalasAplicacion
    {
        private IConexion? IConexion = null;

        public SalasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Salas? Borrar(Salas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Salas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Salas? Guardar(Salas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Salas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Salas> Listar()
        {
            return this.IConexion!.Salas!.Take(20).ToList();
        }

        public List<Salas> PorCodigo(Salas? entidad)
        {
            return this.IConexion!.Salas!
                .Where(x => x.Numero == entidad!.Numero)
                .ToList();
        }

        public Salas? Modificar(Salas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Salas>(entidad);
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
