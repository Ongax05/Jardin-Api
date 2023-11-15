using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Persistency;

namespace Aplication.Repository;

public class RolRepository : GenericRepository<Rol>, IRolRepository
{
    private readonly ApiDbContext _context;

    public RolRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
