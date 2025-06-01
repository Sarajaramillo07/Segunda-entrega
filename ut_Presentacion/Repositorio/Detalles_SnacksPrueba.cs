using Lib_Dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class Detalles_SnacksPrueba
    {
        private readonly IConexion? iConexion;
        private List<Detalles_Snacks>? lista;
        private Detalles_Snacks? entidad;

        public Detalles_SnacksPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Detalles_Snacks!.ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Detalles_Snacks()!;
            this.iConexion!.Detalles_Snacks!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Id_CodigoCompra = 6;

            var entry = this.iConexion!.Entry<Detalles_Snacks>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Detalles_Snacks!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
