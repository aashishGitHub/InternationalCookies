using ApplicationServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAllCustomers();

        CustomerDto GetCustomer(int? id, long? phone);

        bool AddCustomer(CustomerDto customer);
    }
}
