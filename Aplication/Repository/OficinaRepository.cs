using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
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
    }
}