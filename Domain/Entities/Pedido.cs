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
        public string Estado { get; set; }
        public string Comentarios { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Detalle_Pedido> Detalles_Pedidos { get; set; }
        #nullable enable
        public DateTime? Fecha_Entrega { get; set; }
    }
}