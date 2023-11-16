using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Detalle_Pedido
    {
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public string ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Unidad { get; set; }
        public short Numero_Linea { get; set; }
    }
}