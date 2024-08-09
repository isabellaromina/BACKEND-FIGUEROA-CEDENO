using ProyectoFerreteria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFerreteria.Repositorio
{
    public interface IRepositorioCliente
    {
        Task<List<Cliente>> ObtenerClientes();
        Task<Cliente?> ObtenerClientePorId(int id);
        Task<int> CrearCliente(Cliente cliente);
        Task<int> ModificarCliente(Cliente cliente);
        Task EliminarCliente(int id);
    }
}
