using System.Text.Json.Serialization;

namespace ProyectoFerreteria.Entidades
{
    public class SolicitudCompra
    {
        public int Id { get; set; }

        public DateOnly FechaEmision { get; set; }
        [JsonIgnore]
        public string descripcion { get; set; } = null!;

        public string estado { get; set; } = null!;
    }
}

