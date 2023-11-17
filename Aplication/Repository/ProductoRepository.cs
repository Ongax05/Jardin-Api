using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistency;

namespace Aplication.Repository
{
    public class ProductoRepository : GenericStringRepository<Producto>, IProducto
    {
        private readonly ApiDbContext context;
        public ProductoRepository(ApiDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Producto>> GetProductsOrnamentalsWithMoreThan100Ordered()
        {
            var r = await context.Productos.Where(p => p.Gama_ProductoId == "Ornamentales" && p.Cantidad_Stock > 100).OrderByDescending(p=>p.Precio_Venta).ToListAsync();
            return r;
        }
    }
}