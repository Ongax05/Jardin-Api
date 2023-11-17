using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICliente : IGenericInt<Cliente>
    {
        Task <IEnumerable<Cliente>> GetSpanishCustomersNames ();
        Task <IEnumerable<Cliente>> GetClientsFromMadridWithEmployeeRepresentant30Or11 ();
        Task <IEnumerable<Cliente>> GetClientsWithEmployee ();
        Task<IEnumerable<Cliente>> GetClientsWithRepSalInfoIfHavePayments ();
        Task<IEnumerable<Cliente>> GetClientsWithRepSalInfoIfDontHavePayments ();
        Task<IEnumerable<Cliente>> GetClientsWhoHaveReceivedABackorder (List<int> ClientIds);
        Task<IEnumerable<Cliente>> RangesPurchasedByEachCustomer ();
    }
}