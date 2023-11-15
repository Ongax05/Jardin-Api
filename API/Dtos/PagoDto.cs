using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PagoDto
    {
        public string Id { get; set; }
        public int ClienteId { get; set; }
        public string Forma_Pago { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public byte Total { get; set; }
    }
}