using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto : StringBaseEntity
    {
        public string Nombre { get; set; }
        public string Gama_ProductoId { get; set; }
        public Gama_Producto Gama_Producto { get; set; }
        public string Dimensiones { get; set; }
        #nullable enable
        public string? Proveedor { get; set; }
        public string? Descripcion { get; set; }
        #nullable disable
        public short Cantidad_Stock { get; set; }
        public decimal Precio_Venta { get; set; }
        public decimal? Precio_Proveedor { get; set; }
        public ICollection<Detalle_Pedido> Detalles_Pedidos { get; set; }
    }
}