using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public DateTime Fecha_Esperada { get; set; }
        public string Estado { get; set; }
        public string Comentarios { get; set; }
        public int ClienteId { get; set; }
        #nullable enable
        public DateTime? Fecha_Entrega { get; set; }
    }
}