using Microsoft.EntityFrameworkCore;
using ProyectoFerreteria.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFerreteria.Repositorio
{
    public class RepositorioContactos:IRepositorioContactos
    {
        private readonly ApplicationDbContext context;
        public RepositorioContactos(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Contactos>> ObtenerContactos()
        {
            return await context.CONTACTOS.ToListAsync();
        }

        public async Task<Contactos?> ObtenerContactoPorId(int id)
        {
            return context.CONTACTOS.Where(contacto => contacto.Id == id)
               .ToList()[0];

        }
        public async Task<int> CrearContacto(Contactos contactos)
        {
            context.CONTACTOS.Add(contactos);
            await context.SaveChangesAsync();

            return contactos.Id;
        }

        public async Task<Contactos> ModificarContacto(Contactos contactos)
        {
            //obtener el objeto de la BD
            Contactos contactosMod = await context.CONTACTOS.FindAsync(contactos.Id);
            //cambiar los valores del objeto consultado
            contactosMod.Nombre = contactos.Nombre;
            contactosMod.Apellido = contactos.Apellido;
            contactosMod.telefono = contactos.telefono;
            contactosMod.correo = contactos.correo;
            contactosMod.direccion = contactos.direccion;
            contactosMod.Tipo = contactos.Tipo;

            //Guardar los cambios
            await context.SaveChangesAsync();
            return contactosMod;
        }
        public async Task EliminarContacto(int id)
        {
            Contactos contacto = await context.CONTACTOS.FindAsync(id);
            context.CONTACTOS.Remove(contacto);
            await context.SaveChangesAsync();
        }
    }
}
