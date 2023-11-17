using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ResumenPedidoEsEnDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha_Esperada { get; set; }
        public DateTime? Fecha_Entrega { get; set; }    
    }
}