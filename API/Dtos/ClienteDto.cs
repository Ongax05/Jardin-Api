using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Linea_Direccion1 { get; set; }
        public string Ciudad { get; set; }
        #nullable enable
        public string? Nombre_Contacto { get; set; }
        public string? Apellido_Contacto { get; set; }
        public string? Linea_Direccion2 { get; set; }
        public string? Region { get; set; }
        public string? Pais { get; set; }
        public string? Codigo_Postal { get; set; }
        public int? EmpleadoId { get; set; }
        public decimal? Limite_Credito { get; set; }
    }
}