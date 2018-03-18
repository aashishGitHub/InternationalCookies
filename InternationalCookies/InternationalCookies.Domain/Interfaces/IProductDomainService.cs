using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalCookies.Domain.Interfaces
{
    public interface IProductDomainService
    {
        IQueryable<Model.Product> GetAllProducts();
        bool UpdateProduct(Domain.Model.Product product);
        bool AddProduct(Domain.Model.Product product);
    }
}
