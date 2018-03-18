using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternationalCookies.Domain.Model;

namespace InternationalCookies.Domain.Interfaces
{
    public interface IOrderDomainService
    {
        bool PlaceOrder(Order order);
    }
}
