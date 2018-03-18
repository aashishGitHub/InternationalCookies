using InternationalCookies.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalCookies.Domain.Interfaces
{
    public interface IStockDomainService
    {
        bool UpdateStock(Stock stocks);

        IEnumerable<Stock> GetStocks(List<OrderDetails> orderDetails);
    }
}
