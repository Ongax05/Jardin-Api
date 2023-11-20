using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClientesConTotalDePedidos
    {
        public string Nombre_Cliente { get; set; }
        public int Pedidos_Totales { get; set; }
    }
}