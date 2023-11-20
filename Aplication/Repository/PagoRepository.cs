using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persistency;

namespace Aplication.Repository
{
    public class PagoRepository : GenericStringRepository<Pago>, IPago
    {
        private readonly ApiDbContext context;

        public PagoRepository(ApiDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<decimal> AveragePaymentIn2009()
        {
            decimal average = await context
                .Pagos
                .Where(p => p.Fecha_Pago.Year == 2009)
                .Select(p => p.Total)
                .AverageAsync();
            return average;
        }

        public async Task<IEnumerable<Pago>> GetCustomersIdWhoPayIn2008()
        {
            var r = await context.Pagos.Where(p => p.Fecha_Pago.Year == 2008).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Pago>> GetPaymentsOrderedIn2008()
        {
            var r = await context
                .Pagos
                .Where(p => p.Fecha_Pago.Year == 2008 && p.Forma_Pago.ToLower() == "paypal")
                .OrderBy(p => p.Total)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<object>> TotalPaymentsPerYear()
        {
            var r = await context
                .Pagos
                .GroupBy(p => p.Fecha_Pago.Year)
                .Select(x => new { Año = x.Key, TotalPagos = x.Sum(p => p.Total) })
                .ToListAsync();
            return r;
        }
    }
}
