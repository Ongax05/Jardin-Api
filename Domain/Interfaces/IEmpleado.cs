using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Domain.Interfaces
{
    public interface IEmpleado : IGenericInt<Empleado>
    {
        Task<IEnumerable<Empleado>> GetEmployeeWithBossWithBoss ();
        Task<IEnumerable<Empleado>> EmployeesWhoHaveNoAssociatedCustomersWithOffice();
        Task<IEnumerable<Empleado>> EmployeesWithoutOfficeNorCustomers();
        Task<IEnumerable<Empleado>> EmployeesWithoutClientsPlusBossName();
        Task<IEnumerable<Empleado>> SalesRepresentativesEmployees();
    }
}