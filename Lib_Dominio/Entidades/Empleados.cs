using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Dominio.Entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public string? Carnet { get; set; }
        public string? Nombre { get; set; }
    }
}