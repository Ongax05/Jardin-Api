using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
        public string OficinaId { get; set; }
        public Oficina Oficina { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
        #nullable enable
        public string? Apellido2 { get; set; }
        public int? Codigo_Jefe { get; set; }
        public Empleado? Jefe { get; set; }
        public ICollection<Empleado>? Empleados { get; set; }
        public string? Puesto { get; set; }
    }
}