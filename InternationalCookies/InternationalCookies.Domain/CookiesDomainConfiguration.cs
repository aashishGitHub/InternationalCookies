using CookiesBootstrapper;
using InternationalCookies.Domain.Interfaces;
using InternationalCookies.Domain.RepositoriesInterfaces;
using InternationalCookies.Domain.Service;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Resolution;

namespace InternationalCookies.Domain
{
    public static class CookiesDomainConfiguration
    {
        private static bool _initialised;
        public static void Initialise()
        {
            if (_initialised) return;
            
            CookiesUnityContainer.Current.RegisterType<ICustomerDomainService, CustomerService>()
                .RegisterType<IOrderDomainService, OrderDomainService>()
                .RegisterType<IProductDomainService, ProductDomainService>()
                .RegisterType<IStockDomainService, StockDomainService>();

            _initialised = true;
        }
    }
}
