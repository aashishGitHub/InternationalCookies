using System;
using System.Linq;
using InternationalCookies.DataAccess.DbContext;
using InternationalCookies.Domain.RepositoriesInterfaces;

namespace InternationalCookies.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository, IDisposable
    {
        private readonly CookiesDbContext _cookiesDbContext;
        public ProductsRepository(CookiesDbContext cookiesDbContext)
        {
            _cookiesDbContext = cookiesDbContext;
        }


        public IQueryable<Domain.Model.Product> GetAllProducts()
        {
            var allProductsAndStocks = _cookiesDbContext.Products.Select(x => new Domain.Model.Product()
            {
                ProductId = x.ProductId,
                Price = x.Price,
                ProductName = x.ProductName,
                ProductStocksAvailable = x.Stock.NumberOfItemsAvailable,
                ProductStocksDamage = x.Stock.NumberOfDefectiveItems
            });
            return allProductsAndStocks;
        }

        public bool UpdateProduct(Domain.Model.Product product)
        {
            try
            {
                var productDbOrject = _cookiesDbContext.Products.First(x => x.ProductId.Equals(product.ProductId));

                productDbOrject.Price = product.Price;
                productDbOrject.ProductName = product.ProductName;
                productDbOrject.Stock.NumberOfItemsAvailable = product.ProductStocksAvailable;
                productDbOrject.Stock.NumberOfDefectiveItems = product.ProductStocksDamage;
                return _cookiesDbContext.SaveChanges() > 0;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }

        public bool AddProduct(Domain.Model.Product product)
        {
            try
            {
                var productDbOrject = new Product()
                {
                    ProductName = product.ProductName,
                    Price = product.Price
                };
                var stockDbObject = new Stock()
                {
                    ProductId = productDbOrject.ProductId,
                    NumberOfDefectiveItems = product.ProductStocksDamage,
                    NumberOfItemsAvailable = product.ProductStocksDamage
                };

                _cookiesDbContext.Products.Add(productDbOrject);
                _cookiesDbContext.Stocks.Add(stockDbObject);

              return  _cookiesDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
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
