using Lib_Dominio.Entidades;
using ut_presentacion;
namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo //Datos que se ven modificados en el SQL 
    {
        public static Boletas? Boletas()
        {
            var entidad = new Boletas();
            entidad.FechayHora = new DateTime(2025, 4, 1, 17, 0, 0);
            entidad.Precio = 100000;
            entidad.Id_CodigoCompra = 6;
            entidad.Id_Salas_Sede = 7;
            entidad.Id_Pelicula = 5;
            return entidad;
        }
        public static Clientes? Clientes()
        {
            var entidad = new Clientes();
            entidad.DNI = "PruebaDNI";
            entidad.Nombre = "PruebaNombre";
            return entidad;
        }
        public static CodigoCompras? CodigoCompras()
        {
            var entidad = new CodigoCompras();
            entidad.Codigo = "Prueba";
            entidad.Id_Empleado = 6;
            entidad.Id_Plan = 3;
            entidad.Id_Cliente = 6;
            return entidad;
        }
        public static Detalles_Snacks? Detalles_Snacks()  
        {
            var entidad = new Detalles_Snacks();
            entidad.Id_CodigoCompra = 6;
            entidad.Id_Snack = 6;
            return entidad;
        }
        public static Empleados? Empleados()
        {
            var entidad = new Empleados();
            entidad.Carnet = "PruebaCarnet";
            entidad.Nombre = "PruebaNombre";
            return entidad;
        }
        public static Peliculas? Peliculas()
        {
            var entidad = new Peliculas();
            entidad.Nombre = "PruebaNombre"; 
            entidad.Tipo = "PruebaTipo";
            return entidad;
        }
        public static Planes? Planes()
        {
            var entidad = new Planes();
            entidad.Nombre = "Prueba";
            entidad.Detalles = 30;
            return entidad;
        }
        public static Salas? Salas()
        {
            var entidad = new Salas();
            entidad.Numero = 40;
            entidad.Asiento = "L";
            return entidad;
        }
        public static Salas_Sedes? Salas_Sedes()
        {
            var entidad = new Salas_Sedes();
            entidad.Id_Sede = 5;
            entidad.Id_Sala = 7;
            return entidad;
        }
        public static Sedes? Sedes()
        {
            var entidad = new Sedes();
            entidad.Nombre = "Prueba";
            return entidad;
        }
        public static Snacks? Snacks()
        {
            var entidad = new Snacks();
            entidad.Nombre_Snacks = "Prueba";
            entidad.Precio = 15000;
            return entidad;
        }


    }
}
