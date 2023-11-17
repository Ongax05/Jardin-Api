using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteConGamas
    {
        public string Nombre_Cliente { get; set; }
        public List<string> Gamas { get; set; }
    }
}