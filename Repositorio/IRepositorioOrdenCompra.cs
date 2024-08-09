using ProyectoFerreteria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFerreteria.Repositorio
{
    public interface IRepositorioOrdenCompra
    {
        Task<List<OrdenCompra>> ObtenerOrden();
        Task<OrdenCompra?> ObtenerOrdenPorId(int id);
        Task<int> CrearOrden(OrdenCompra ordenCompra);
        Task<OrdenCompra> ModificarOrden(OrdenCompra ordenCompra);
        Task EliminarOrden(int id);
    }
}
