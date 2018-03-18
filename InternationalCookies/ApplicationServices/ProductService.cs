using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Dto;
using ApplicationServices.Interfaces;
using ApplicationServices.Mapper;
using InternationalCookies.Domain.Interfaces;

namespace ApplicationServices
{
    public class ProductService : IProductService
    {
        private readonly IProductDomainService _productDomainService;

        public ProductService(IProductDomainService productDomainService)
        {
            _productDomainService = productDomainService;
        }

        public bool AddProduct(ProductDto product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
           return _productDomainService.GetAllProducts().Select(p=>p.ToProductDto());
            
        }

        public bool UpdateProduct(ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
