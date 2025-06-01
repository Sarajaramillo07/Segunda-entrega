using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Dominio.Entidades
{
    public class Detalles_Snacks
    {
        public int Id { get; set; }
        public int Id_CodigoCompra { get; set; }
        public int? Id_Snack { get; set; }
        [ForeignKey("Id_CodigoCompra")] public CodigoCompras? CodigoCompra { get; set; }
        [ForeignKey("Id_Snack")] public Snacks? Snack { get; set; }
    }
}

