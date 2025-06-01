using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Dominio.Entidades
{
    public class CodigoCompras
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public int Id_Empleado { get; set; }
        public int? Id_Plan { get; set; }
        public int Id_Cliente { get; set; } //esta seria la FK de la entidad cliente?
        [ForeignKey("Id_Empleado")] public Empleados? _Id_Empleado { get; set; }
        [ForeignKey("Id_Plan")] public Planes? _Id_Plan { get; set; }
        [ForeignKey("Id_Cliente")] public Clientes? _Id_Cliente { get; set; }

    }
}
