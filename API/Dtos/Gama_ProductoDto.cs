using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Dtos
{
    public class Gama_ProductoDto
    {
        public string Id { get; set; }
        public string Descripcion_Texto { get; set; }
        public string Descripcion_HTML { get; set; }
        public string Imagen { get; set; }
    }
}