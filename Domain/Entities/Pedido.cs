using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public DateTime Fecha_Pedido { get; set; }
        public DateTime Fecha_Esperada { get; set; }
        #nullable enable
        public DateTime? Fecha_Entrega { get; set; }
        #nullable disable
        public string Estado { get; set; }
        #nullable enable
        public string? Comentarios { get; set; }
        #nullable disable
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Detalle_Pedido> Detalles_Pedidos { get; set; }
    }
}