using System.Linq;
using InternationalCookies.Domain.Interfaces;
using InternationalCookies.Domain.Model;
using InternationalCookies.Domain.RepositoriesInterfaces;
using Microsoft.Practices.Unity.Configuration.ConfigurationHelpers;

namespace InternationalCookies.Domain.Service
{
    public class OrderDomainService : IOrderDomainService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IStockRepository _stockRepository;

        public OrderDomainService(IOrderRepository orderRepository, IStockRepository stockRepository)
        {
            _orderRepository = orderRepository;
            _stockRepository = stockRepository;
        }

        public bool PlaceOrder(Order order)
        {
            //fetch available stocks based on order details
            //Check if order is valid/ do-able, if not break

            var orderDetails = order.OrderDetails.ToList();
            var productIdAndQuantityForOrderPlaced = orderDetails.ToDictionary(o => o.ProductId, o => o.Quantity);

            var relatedStocksInDb = _stockRepository.GetStocksForOrder(orderDetails);
            bool inSufficientProducts = relatedStocksInDb.Any(st =>
                    (productIdAndQuantityForOrderPlaced.ContainsKey(st.ProductId)
                     &&
                     st.NumberOfItemsAvailable < productIdAndQuantityForOrderPlaced.GetOrNull(st.ProductId)
                    )
            );

            if (!inSufficientProducts) return inSufficientProducts;

            _orderRepository.PlaceOrder(order);

            //Get a list of order details and generate updated stock details by substracting the Orders placed items.

            var modifiedStocks = relatedStocksInDb.Where(st => productIdAndQuantityForOrderPlaced.ContainsKey(st.ProductId))
                .Select(st => new Stock()
                {
                    ProductId = st.ProductId,
                    NumberOfDefectiveItems = st.NumberOfDefectiveItems,
                    NumberOfItemsAvailable = st.NumberOfItemsAvailable - productIdAndQuantityForOrderPlaced.GetOrNull(st.ProductId),
                    Id = st.Id
                });

            return _stockRepository.UpdateStock(modifiedStocks);
        }
    }
}
