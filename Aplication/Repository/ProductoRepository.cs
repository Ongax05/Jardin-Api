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

        public ProductoRepository(ApiDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Producto>> GetProductsOrnamentalsWithMoreThan100Ordered()
        {
            var r = await context
                .Productos
                .Where(p => p.Gama_ProductoId == "Ornamentales" && p.Cantidad_Stock > 100)
                .OrderByDescending(p => p.Precio_Venta)
                .ToListAsync();
            return r;
        }

        public async Task<Producto> MostExpensiveProduct()
        {
            var r = await context
                .Productos
                .OrderByDescending(p => p.Precio_Venta)
                .FirstOrDefaultAsync();
            return r;
        }

        public async Task<Producto> NameBestSoldProduct()
        {
            var r = await context
                .Detalles_Pedidos
                .Include(p => p.Producto)
                .GroupBy(p => p.Producto)
                .OrderByDescending(x => x.Sum(p => p.Cantidad))
                .Select(x=>x.Key)
                .FirstOrDefaultAsync();
            return r;
        }

        public async Task<IEnumerable<object>> Products3000EandIVA()
        {
            var r = await context
                .Detalles_Pedidos
                .Include(p => p.Pedido)
                .Where(p => p.Pedido.Estado.ToLower() == "entregado")
                .Include(p => p.Producto)
                .GroupBy(p => p.Producto.Nombre)
                .Where(x => x.Sum(p => p.Cantidad * p.Precio_Unidad) > 3000)
                .Select(
                    x =>
                        new
                        {
                            Producto = x.Key,
                            Unidades_Vendidas = x.Sum(p => p.Cantidad),
                            Facturado = x.Sum(p => p.Cantidad * p.Precio_Unidad),
                            FacturadoMasIVA = x.Sum(p => p.Cantidad * p.Precio_Unidad)
                                * (decimal)1.21
                        }
                )
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Producto>> ProductsHaveBeenBought()
        {
            var p = await ProductsThatHaveNeverBeenOrdered();
            var ids = p.Select(p=>p.Id).ToList();
            var r = await context.Productos.Where(p=> !ids.Contains(p.Id)).ToListAsync();
            return r;

        }

        public async Task<IEnumerable<Producto>> ProductsThatHaveNeverBeenOrdered()
        {
            var ProductsThatHaveBeenOrderedIds = await context
                .Detalles_Pedidos
                .Select(p => p.ProductoId)
                .ToListAsync();
            var r = await context
                .Productos
                .Where(p => !ProductsThatHaveBeenOrderedIds.Contains(p.Id))
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Producto>> ProductsThatHaveNeverBeenOrderedNameDescAndImg()
        {
            var ProductsThatHaveBeenOrderedIds = await context
                .Detalles_Pedidos
                .Select(p => p.ProductoId)
                .ToListAsync();
            var r = await context
                .Productos
                .Where(p => !ProductsThatHaveBeenOrderedIds.Contains(p.Id))
                .Include(p => p.Gama_Producto)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Producto>> Top20Products()
        {
            var r = await context
                .Productos
                .Include(p => p.Detalles_Pedidos)
                .OrderByDescending(p => p.Detalles_Pedidos.Count)
                .Take(20)
                .ToListAsync();
            return r;
        }
    }
}
