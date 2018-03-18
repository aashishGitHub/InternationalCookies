using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternationalCookies.Domain.Model;
using InternationalCookies.Domain.RepositoriesInterfaces;
using InternationalCookies.DataAccess.DbContext;
using Order = InternationalCookies.DataAccess.DbContext.Order;

namespace InternationalCookies.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private readonly CookiesDbContext _cookiesDbContext;

        public OrderRepository(CookiesDbContext cookiesDbContext)
        {
            _cookiesDbContext = cookiesDbContext;
        }


        public bool PlaceOrder(Domain.Model.Order order)
        {
            var newDbOrder = new Order()
            {
                CustomerId = order.CustomerId,
                DateOfOrder = DateTime.UtcNow
            };

            var newDbOrderdetails = order.OrderDetails.Select(od => new OrderDetail()
            {
                ProductId = od.ProductId,
                Quantity = od.Quantity,
                OrderId = newDbOrder.Id
            });

            newDbOrder.TotalCost = order.OrderDetails.Sum(x => (x.Quantity * x.Price));

            _cookiesDbContext.Orders.Add(newDbOrder);
            _cookiesDbContext.OrderDetails.AddRange(newDbOrderdetails);

            return _cookiesDbContext.SaveChanges() > 0;

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state (managed objects).
                    _cookiesDbContext?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CustomerRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
