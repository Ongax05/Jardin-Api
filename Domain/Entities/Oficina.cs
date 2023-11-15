using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Oficina : StringBaseEntity
    {
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Codigo_Postal { get; set; }
        public string Telefono { get; set; }
        public string Linea_Direccion1 { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
        #nullable enable
        public string? Region { get; set; }
        public string? Linea_Direccion2 { get; set; }
    }
}