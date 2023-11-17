using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductoNombreDescImg
    {
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        #nullable enable
        public string? Descripcion { get; set; }
    }
}