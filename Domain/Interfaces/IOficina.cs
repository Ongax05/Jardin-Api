using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOficina : IGenericString<Oficina>
    {
        Task<IEnumerable<Oficina>> NotOfficesByIdList(List<string> Ids);
    }
}