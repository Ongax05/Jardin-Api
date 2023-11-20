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

        public async Task<IEnumerable<IGrouping<string, Cliente>>> CustomersGruopedByCountry()
        {
            var r = await context.Clientes.GroupBy(p => p.Pais).ToListAsync();
            return r.ToList();
        }

        public async Task<int> CustomersInCitiesWhichStartWithM()
        {
            var r = await context.Clientes
                .Where(c => c.Ciudad.ToLower().StartsWith("m"))
                .CountAsync();
            return r;
        }

        public async Task<int> CustomersInMadridCity()
        {
            var r = await context.Clientes.Where(p => p.Ciudad.ToLower() == "madrid").CountAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> CustomersWhoHaveBeenMadePayments()
        {
            var r = await context.Clientes
                .Include(c => c.Pagos)
                .Where(c => c.Pagos.Count != 0)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> CustomersWhoHaveBoughtIn2008Sorted()
        {
            var ClientIds = await context.Pedidos
                .Where(p => p.Fecha_Pedido.Year == 2008)
                .Select(p => p.ClienteId)
                .Distinct()
                .ToListAsync();
            var r = await context.Clientes
                .Where(c => ClientIds.Contains(c.Id))
                .OrderBy(c => c.Nombre_Cliente)
                .ToListAsync();
            return r;
        }

        public async Task<int> CustomersWhoHaveNoAssignedEmployee()
        {
            var r = await context.Clientes.Where(c => c.EmpleadoId == null).CountAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> CustomersWhoHaveNotMadePayments()
        {
            var r = await context.Clientes.Where(c => c.Pagos.Count == 0).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> CustomersWhoHaveNotMadePaymentsOrPlacedOrders()
        {
            var r = await context.Clientes
                .Where(c => c.Pagos.Count == 0 && c.Pedidos.Count == 0)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> CustomersWithOrders()
        {
            var r = await context.Clientes.Include(p => p.Pedidos).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> CustomersWithOrdersButNotPayments()
        {
            var r = await context.Clientes
                .Where(c => c.Pagos.Count == 0 && c.Pedidos.Count != 0)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> CustomersWithPayments()
        {
            var r = await context.Clientes
                .Where(p => p.Pagos.Count != 0)
                .Include(c => c.Pagos)
                .ToListAsync();
            return r;
        }

        public async Task<
            IEnumerable<Cliente>
        > CustomersWithTheirNameSalesRepresentativeAndOfficeCity()
        {
            var r = await context.Clientes
                .Include(c => c.Empleado)
                .ThenInclude(e => e.Oficina)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> CustomerWithOverPaymentLoan()
        {
            var r = await context.Clientes
                .Include(p => p.Pagos)
                .Where(p => p.Pagos.Sum(x => x.Total) > p.Limite_Credito)
                .ToListAsync();
            return r;
        }

        public async Task<Cliente> CustomerWithTheHighestLoan()
        {
            var r = await context.Clientes
                .OrderByDescending(p => p.Limite_Credito)
                .FirstOrDefaultAsync();
            return r;
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

        public async Task<IEnumerable<Cliente>> GetClientsWhoHaveReceivedABackorder(
            List<int> ClientIds
        )
        {
            var r = await context.Clientes.Where(p => ClientIds.Contains(p.Id)).ToListAsync();
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
                .ThenInclude(c => c.Oficina)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> GetClientsWithRepSalInfoIfHavePayments()
        {
            var r = await context.Clientes
                .Where(p => p.Pagos.Count > 0)
                .Include(c => c.Empleado)
                .ThenInclude(c => c.Oficina)
                .ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> GetSpanishCustomersNames()
        {
            var r = await context.Clientes.Where(c => c.Pais.ToLower() == "spain").ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Cliente>> RangesPurchasedByEachCustomer()
        {
            var r = await context.Clientes
                .Include(p => p.Empleado)
                .Include(p => p.Pedidos)
                .ThenInclude(p => p.Detalles_Pedidos)
                .ThenInclude(p => p.Producto)
                .ToListAsync();
            return r;
        }
    }
}
