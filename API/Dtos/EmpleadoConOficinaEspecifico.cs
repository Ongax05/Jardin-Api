using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoConOficinaEspecifico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string OficinaId { get; set; }
        public OficinaDto Oficina { get; set; }
        #nullable enable
        public string? Apellido2 { get; set; }
        public string? Puesto { get; set; }
    }
}