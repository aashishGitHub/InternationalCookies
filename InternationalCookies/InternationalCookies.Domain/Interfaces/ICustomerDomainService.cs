using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternationalCookies.Domain.Model;

namespace InternationalCookies.Domain.Interfaces
{
    public interface ICustomerDomainService
    {
        IQueryable<Customer> GetAllCustomers();

        Customer GetCustomer(int? id, long? phone);

        bool AddCustomer(Customer customer);
    }
}
