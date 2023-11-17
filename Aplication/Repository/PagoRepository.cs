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
    public class PagoRepository : GenericStringRepository<Pago>, IPago
    {
        private readonly ApiDbContext context;

        public PagoRepository(ApiDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Pago>> GetCustomersIdWhoPayIn2008()
        {
            var r = await context.Pagos.Where(p => p.Fecha_Pago.Year == 2008).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Pago>> GetPaymentsOrderedIn2008()
        {
            var r = await context.Pagos
                .Where(p => p.Fecha_Pago.Year == 2008 && p.Forma_Pago.ToLower() == "paypal")
                .OrderBy(p => p.Total)
                .ToListAsync();
            return r;
        }
    }
}
