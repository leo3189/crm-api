using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(Guid customerId);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer dbCustomer, Customer customer);
        void DeleteCustomer(Customer customer);
    }

    
}
