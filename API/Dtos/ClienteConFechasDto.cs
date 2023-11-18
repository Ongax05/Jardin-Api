using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteConFechasDto
    {
        public string Nombre_Cliente { get; set; }
        #nullable enable
        public string? Nombre_Contacto { get; set; }
        public string? Apellido_Contacto { get; set; }
        public DateTime Pago_Mas_Reciente { get; set; }
        public DateTime Pago_Mas_Antiguo { get; set; }
    }
}