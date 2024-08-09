using Microsoft.EntityFrameworkCore;
using ProyectoFerreteria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFerreteria.Repositorio
{
    public class RepositorioSolicitudCompra : IRepositorioSolicitudCompra
    {
        private readonly ApplicationDbContext context;
        public RepositorioSolicitudCompra(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<List<SolicitudCompra>> ObtenerSolicitud()
        {
            return await context.SOLICITUDESC.ToListAsync();
        }

        public async Task<SolicitudCompra?> ObtenerSolicitudPorId(int id)
        {
            return context.SOLICITUDESC.Where(solicitud => solicitud.Id == id)
                .ToList()[0];

        }

        public async Task<int> CrearSolicitud(SolicitudCompra solicitud)
        {
            context.SOLICITUDESC.Add(solicitud);
            await context.SaveChangesAsync();

            return solicitud.Id;
        }
        public async Task<SolicitudCompra> ModificarSolicitud(SolicitudCompra solicitud)
        {
            //obtener el objeto de la BD
            SolicitudCompra clienteMod = await context.SOLICITUDESC.FindAsync(solicitud.Id);
            //cambiar los valores del objeto consultado
            clienteMod.FechaEmision = solicitud.FechaEmision;
            clienteMod.descripcion = solicitud.descripcion;
            clienteMod.estado = solicitud.estado;

            //Guardar los cambios
            await context.SaveChangesAsync();
            return clienteMod;
        }

        public async Task EliminarSolicitud(int id)
        {
            SolicitudCompra solicitud = await context.SOLICITUDESC.FindAsync(id);
            context.SOLICITUDESC.Remove(solicitud);
            await context.SaveChangesAsync();
        }
    }
}
