
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_Dominio.Entidades
{
    public class Boletas
    {

        public int Id { get; set; }
        public DateTime FechayHora { get; set; }
        public decimal Precio { get; set; }

        //foreing key
        public int Id_CodigoCompra {get; set;}
        public int Id_Salas_Sede {get; set;}
        public int Id_Pelicula{ get; set; }
        [ForeignKey("Id_CodigoCompra")] public CodigoCompras? Codigocompra { get; set; }
        [ForeignKey("Id_Salas_Sede")] public Salas_Sedes? Salas_Sede { get; set; }
        [ForeignKey("Id_Pelicula")] public CodigoCompras? Pelicula { get; set; }
    }
}