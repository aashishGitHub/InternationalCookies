using System.Web.Http;
using ApplicationServices.Interfaces;
using CookiesBootstrapper;
using Unity;

namespace InternationalCookies.Controllers.Api
{
    public class ProductsApiController : ApiController
    {
        private readonly IProductService _productService;
        public ProductsApiController()
        {
            _productService = CookiesUnityContainer.Current.Resolve<IProductService>();
        }
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var result = _productService.GetAllProducts();
            return Ok(result);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}