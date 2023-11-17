using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nombre_Cliente { get; set; }
        #nullable enable
        public string? Nombre_Contacto { get; set; }
        public string? Apellido_Contacto { get; set; }
        #nullable disable
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Linea_Direccion1 { get; set; }
        #nullable enable
        public string? Linea_Direccion2 { get; set; }
        #nullable disable
        public string Ciudad { get; set; }
        #nullable enable
        public string? Region { get; set; }
        public string? Pais { get; set; }
        public string? Codigo_Postal { get; set; }
        public int? EmpleadoId { get; set; }
        public Empleado? Empleado { get; set; }
        public decimal? Limite_Credito { get; set; }
        #nullable disable
        public ICollection<Pedido> Pedidos { get; set; }
        public ICollection<Pago> Pagos { get; set; }
    }
}
