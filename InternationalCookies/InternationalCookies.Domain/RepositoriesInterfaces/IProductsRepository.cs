using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternationalCookies.Domain.Model;

namespace InternationalCookies.Domain.RepositoriesInterfaces
{
    public interface IProductsRepository
    {
        IQueryable<Product> GetAllProducts();

        bool UpdateProduct(Product product);

        bool AddProduct(Product product);


    }
}
