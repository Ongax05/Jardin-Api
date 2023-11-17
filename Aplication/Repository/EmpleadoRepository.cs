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
    public class EmpleadoRepository : GenericIntRepository<Empleado>, IEmpleado
    {
        private readonly ApiDbContext context;
        public EmpleadoRepository(ApiDbContext context) : base(context)
        {
            this.context = context; 
        }

        public async Task<IEnumerable<Empleado>> EmployeesWhoHaveNoAssociatedCustomersWithOffice()
        {
            var EmployeesWithClientsIds = await context.Clientes.Select(c=>c.EmpleadoId).ToListAsync();
            var r = await context.Empleados.Where(c => !EmployeesWithClientsIds.Contains(c.Id)).Include(c=>c.Oficina).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Empleado>> EmployeesWithoutClientsPlusBossName()
        {
            var r = await context.Empleados.Where(e=>e.Clientes.Count == 0).Include(e=>e.Jefe).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Empleado>> EmployeesWithoutOfficeNorCustomers()
        {
            var EmployeesWithClientsIds = await context.Clientes.Select(c=>c.EmpleadoId).ToListAsync();
            var r = await context.Empleados.Where(c => !EmployeesWithClientsIds.Contains(c.Id) && c.Oficina == null).ToListAsync();
            return r;
        }

        public async Task<IEnumerable<Empleado>> GetEmployeeWithBossWithBoss()
        {
            var r = await context.Empleados.Include(m=>m.Jefe).ThenInclude(m=>m.Jefe).ToListAsync();
            return r;
        }
    }
}