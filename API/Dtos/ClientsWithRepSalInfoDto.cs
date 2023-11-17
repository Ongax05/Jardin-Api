using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClientsWithRepSalInfoDto
    {
        public string Nombre_Cliente { get; set; }
        public string Nombre_RepSal { get; set; }
        public string Apellido_RepSal { get; set; }
    }
}