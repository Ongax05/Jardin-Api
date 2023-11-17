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
    public class ClienteRepository : GenericIntRepository<Cliente>, ICliente
    {
        private readonly ApiDbContext context;

        public ClienteRepository(ApiDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientsFromMadridWithEmployeeRepresentant30Or11()
        {
            var r = await context.Clientes
                .Where(
                    c =>
                        c.Ciudad.ToLower() == "madrid" && (c.EmpleadoId == 11 || c.EmpleadoId == 30)
                )
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> GetClientsWhoHaveReceivedABackorder(List<int> ClientIds)
        {
            var r = await context.Clientes.Where(p=> ClientIds.Contains(p.Id)).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> GetClientsWithEmployee()
        {
            var r = await context.Clientes.Include(c => c.Empleado).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> GetClientsWithRepSalInfoIfDontHavePayments()
        {
            var r = await context.Clientes
                .Where(p => p.Pagos.Count == 0)
                .Include(c => c.Empleado)
                .ThenInclude(c=>c.Oficina)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> GetClientsWithRepSalInfoIfHavePayments()
        {
            var r = await context.Clientes
                .Where(p => p.Pagos.Count > 0)
                .Include(c => c.Empleado)
                .ThenInclude(c=>c.Oficina)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> GetSpanishCustomersNames()
        {
            var r = await context.Clientes.Where(c => c.Pais.ToLower() == "spain").ToListAsync();
            return r;
        }
    }
}
