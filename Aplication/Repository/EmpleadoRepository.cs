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

        public async Task<IEnumerable<Empleado>> GetEmployeeWithBossWithBoss()
        {
            var r = await context.Empleados.Include(m=>m.Jefe).ThenInclude(m=>m.Jefe).ToListAsync();
            return r;
        }
    }
}