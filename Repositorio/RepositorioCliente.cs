using Microsoft.EntityFrameworkCore;
using ProyectoFerreteria.Entidades;
namespace ProyectoFerreteria.Repositorio
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly ApplicationDbContext context;
        public RepositorioCliente(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Cliente>> ObtenerClientes()
        {
            return await context.CLIENTES.ToListAsync();
        }

        public async Task<Cliente?> ObtenerClientePorId(int id)
        {
            return context.CLIENTES.Where(cliente => cliente.Id == id)
                .ToList()[0];

        }

        public async Task<int> CrearCliente(Cliente cliente)
        {
            context.CLIENTES.Add(cliente);
            await context.SaveChangesAsync();

            return cliente.Id;
        }
        public async Task<int> ModificarCliente(Cliente cliente)
        {
            //obtener el objeto de la BD
            Cliente clienteMod = await context.CLIENTES.FindAsync(cliente.Id);
            //cambiar los valores del objeto consultado
            clienteMod.Nombre = cliente.Nombre;
            clienteMod.apellido = cliente.apellido;
            clienteMod.telefono = cliente.telefono;
            clienteMod.correo = cliente.correo;
            clienteMod.direccion = cliente.direccion;
            clienteMod.genero = cliente.genero;

            //Guardar los cambios
            await context.SaveChangesAsync();
            return clienteMod.Id;
        }

        public async Task EliminarCliente(int id)
        {
            Cliente cliente = await context.CLIENTES.FindAsync(id);
            context.CLIENTES.Remove(cliente);
            await context.SaveChangesAsync();
        }
    }
}
