using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Dto;

namespace ApplicationServices.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        bool UpdateProduct(ProductDto product);
        bool AddProduct(ProductDto product);
    }
}
