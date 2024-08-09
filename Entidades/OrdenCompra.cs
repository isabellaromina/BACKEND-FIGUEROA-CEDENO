using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFerreteria.Entidades
{
    public class OrdenCompra
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        public int SolicitudCompraId { get; set; }

        public SolicitudCompra? SolicitudCompra { get; set; }

        public string descripcion { get; set; } = null!;



    }
}
