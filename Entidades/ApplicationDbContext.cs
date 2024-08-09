using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFerreteria.Entidades
{
    public class ApplicationDbContext:DbContext
    {
        /// <summary>
        /// Activar solo este método para que sea implementado desde un Servicio
        /// </summary>
        ///<param name="options"></param>
       public ApplicationDbContext(DbContextOptions options) : base(options)
       {
       }
       

        /// <summary>
        /// Activar solo este método para las migraciones de la BD
        /// </summary>
        /// <param name="optionsBuilder"></param>

       /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             
           optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ferreteriaproyecto;Integrated Security=True;TrustServerCertificate=True;");

        }*/


        public DbSet<Cliente> CLIENTES { get; set; }
        public DbSet<Contactos> CONTACTOS { get; set; }
        public DbSet<SolicitudCompra> SOLICITUDESC { get; set; }
        public DbSet<OrdenCompra>  ORDENESC { get; set; }

    }
}
 