using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPago : IGenericString<Pago>
    {
        Task<IEnumerable<Pago>> GetCustomersIdWhoPayIn2008();
        Task<IEnumerable<Pago>> GetPaymentsOrderedIn2008();
        Task<decimal> AveragePaymentIn2009 ();
    }
}