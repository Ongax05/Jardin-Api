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
    public class OficinaRepository : GenericStringRepository<Oficina>, IOficina
    {
        private readonly ApiDbContext context;
        public OficinaRepository(ApiDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Oficina>> NotOfficesByIdList(List<string> Ids)
        {
            var r = await context.Oficinas.Where(x => !Ids.Contains(x.Id)).ToListAsync();
            return r;
        }
    }
}