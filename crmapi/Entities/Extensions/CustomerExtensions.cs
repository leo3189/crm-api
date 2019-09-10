using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class CustomerExtensions
    {
        public static void Map(this Customer dbCustomer, Customer customer)
        {
            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.Address = customer.Address;
            dbCustomer.Address2 = customer.Address2;
            dbCustomer.City = customer.City;
            dbCustomer.State = customer.State;
            dbCustomer.Zip = customer.Zip;
            dbCustomer.WorkPhone = customer.WorkPhone;
            dbCustomer.MainPhone = customer.MainPhone;
            dbCustomer.Email = customer.Email;
            dbCustomer.Active = customer.Active;
            dbCustomer.CompanyName = customer.CompanyName;
        }
    }
}
