using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Dominio.Entidades
{
    public class Salas_Sedes
    {
        public int Id { get; set; }
        public int Id_Sede { get; set; }
        public int Id_Sala { get; set; }
        [ForeignKey("Id_Sede")] public Sedes? Sede { get; set; }
        [ForeignKey("Id_Sala")] public Salas? Sala { get; set; }
    }
}
