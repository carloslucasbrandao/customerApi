using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repository
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        IEnumerable<Customer> GetCustomers();
        void UpdateCustomer(Customer entityObj);
    }
}
