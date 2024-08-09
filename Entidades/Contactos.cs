using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFerreteria.Entidades
{
    public class Contactos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string telefono { get; set; } = null!;
        public string correo { get; set; } = null!;
        public string direccion { get; set; } = null!;
        public string Tipo { get; set; } = null!;

      
    }
}
