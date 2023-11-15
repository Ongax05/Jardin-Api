using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.Repository
{
    public class Gama_ProductoRepository : GenericStringRepository<Gama_Producto>, IGama_Producto
    {
        public Gama_ProductoRepository(ApiDbContext context) : base(context)
        {
        }
    }
}