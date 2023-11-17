using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPedido : IGenericInt<Pedido>
    {
        Task<IEnumerable<Pedido>> GetBackOrders();
        Task<IEnumerable<Pedido>> GetOrdersTwoDaysEarlier();
        Task<IEnumerable<Pedido>> GetRejectedOrdersIn2009();
        Task<IEnumerable<Pedido>> GetOrdersInJanuary();
    }
}