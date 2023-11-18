using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductoConCuantosVendidosDto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Gama_ProductoId { get; set; }
        public string Dimensiones { get; set; }
        public short Cantidad_Stock { get; set; }
        public decimal Precio_Venta { get; set; }
        #nullable enable
        public string? Proveedor { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio_Proveedor { get; set; }
        public int Unidades_Vendidas { get; set; }
    }
}