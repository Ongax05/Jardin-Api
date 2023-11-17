using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoConJefesDto
    {

        public string Nombre { get; set; }
        #nullable enable
        public string? Nombre_Jefe { get; set; }
        public string? Nombre_Jefe_del_Jefe { get; set; }
    }
}