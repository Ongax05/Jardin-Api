using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistency;

namespace Aplication.Repository
{
    public class PedidoRepository : GenericIntRepository<Pedido>, IPedido
    {
        private readonly ApiDbContext context;
        public PedidoRepository(ApiDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Pedido>> GetBackOrders()
        {
            var r = await context.Pedidos.Where(x => x.Estado.ToLower() == "entregado" && x.Fecha_Entrega > x.Fecha_Esperada).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Pedido>> GetOrdersInJanuary()
        {
            var r = await context.Pedidos.Where(x => x.Estado.ToLower() == "entregado" && x.Fecha_Pedido.Month == 1 ).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Pedido>> GetOrdersTwoDaysEarlier()
        {
            var r = await context.Pedidos.Where(x => x.Estado.ToLower() == "entregado" && x.Fecha_Entrega <= x.Fecha_Esperada.AddDays(-2)).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Pedido>> GetRejectedOrdersIn2009()
        {
            var r = await context.Pedidos.Where(x => x.Estado.ToLower() == "rechazado" && x.Fecha_Pedido.Year == 2009).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Pedido>> ProductsDifferentByOrder()
        {
            var r = await context.Pedidos.Include(p=>p.Detalles_Pedidos).ToListAsync();
            return r;
        }
    }
}