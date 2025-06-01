using lib_aplicaciones.Interfaces;
using Lib_Dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.Implementaciones
{
    public class Salas_SedesAplicacion : ISalas_SedesAplicacion
    {
        private IConexion? IConexion = null;

        public Salas_SedesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Salas_Sedes? Borrar(Salas_Sedes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            this.IConexion!.Salas_Sedes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Salas_Sedes? Guardar(Salas_Sedes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            this.IConexion!.Salas_Sedes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Salas_Sedes> Listar()
        {
            return this.IConexion!.Salas_Sedes!.Take(20).ToList();
        }

        public List<Salas_Sedes> PorCodigo(Salas_Sedes? entidad)
        {
            return this.IConexion!.Salas_Sedes!
                .Where(x => x.Id == entidad!.Id)
                .ToList();
        }

        public Salas_Sedes? Modificar(Salas_Sedes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            var entry = this.IConexion!.Entry<Salas_Sedes>(entidad);
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
