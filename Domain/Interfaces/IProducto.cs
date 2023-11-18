using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProducto : IGenericString<Producto>
    {
        Task<IEnumerable<Producto>> GetProductsOrnamentalsWithMoreThan100Ordered();
        Task<IEnumerable<Producto>> ProductsThatHaveNeverBeenOrdered();
        Task<IEnumerable<Producto>> ProductsThatHaveNeverBeenOrderedNameDescAndImg();
        Task<IEnumerable<Producto>> Top20Products();
    }
}