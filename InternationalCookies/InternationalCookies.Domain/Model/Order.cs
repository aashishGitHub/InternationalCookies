using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalCookies.Domain.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public IEnumerable<OrderDetails> OrderDetails { get; set; }

        public DateTime DateOfOrder { get; set; }

        public decimal TotalCost { get; set; }

        public int CustomerId { get; set; }


    }
}
