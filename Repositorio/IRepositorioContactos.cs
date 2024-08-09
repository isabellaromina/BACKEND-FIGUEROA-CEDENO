using ProyectoFerreteria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFerreteria.Repositorio
{
    public interface IRepositorioContactos
    {
        Task<List<Contactos>> ObtenerContactos();
        Task<Contactos?> ObtenerContactoPorId(int id);
        Task<int> CrearContacto(Contactos contactos);
        Task<Contactos> ModificarContacto(Contactos contactos);
        Task EliminarContacto(int id);

    }
}
