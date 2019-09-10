using Contracts;
using Entities;
using Entities.Extensions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return FindAll()
                .OrderBy(ow => ow.CompanyName)
                .ToList();
        }

        public Customer GetCustomerById(Guid customerId)
        {
            return FindByCondition(customer => customer.Id.Equals(customerId))
                .DefaultIfEmpty(new Customer())
                .FirstOrDefault();
        }

        public void CreateCustomer(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            Create(customer);
        }

        public void UpdateCustomer(Customer dbCustomer, Customer customer)
        {
            dbCustomer.Map(customer);
            Update(dbCustomer);
        }

        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
        }
    }
}
