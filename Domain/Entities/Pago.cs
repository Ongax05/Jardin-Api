using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pago : StringBaseEntity
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string Forma_Pago { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public byte Total { get; set; }
    }
}