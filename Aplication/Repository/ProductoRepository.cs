using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistency;

namespace Aplication.Repository
{
    public class ProductoRepository : GenericStringRepository<Producto>, IProducto
    {
        public ProductoRepository(ApiDbContext context) : base(context)
        {
        }
    }
}