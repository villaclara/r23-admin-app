using AdminApp.WASM.Application.Interfaces;
using AdminApp.WASM.Application.Utility;
using AdminApp.WASM.Models.ViewModels;

namespace AdminApp.WASM.Application.Services
{
    public class OrderHandlerService
    {
        private readonly ICRUDService<OrderVM> _orderService;

        public OrderHandlerService(ICRUDService<OrderVM> orderService)
        {
            _orderService = orderService;
        }


        public async Task<IEnumerable<OrderVM>> GetLastOrdersAsync(string url)
        {
            var orders = await GetAllOrdesListAsync(url);
            return orders.Count() switch
            {
                >= Constants.AMOUNT_ITEMS_DISPLAYED_INDEXPAGE => orders.OrderByDescending(o => o.OrderDate).Take(Constants.AMOUNT_ITEMS_DISPLAYED_INDEXPAGE),
                > 0 and < Constants.AMOUNT_ITEMS_DISPLAYED_INDEXPAGE => orders.OrderByDescending(o => o.OrderDate),
                _ => Enumerable.Empty<OrderVM>()
            };
        }

        public async Task<IEnumerable<OrderVM>> GetAllOrdesListAsync(string url)
        {
            var orders = await _orderService.GetItemsAsListAsync(url);
            return orders;
        }

        public async Task<OrderVM?> GetOrderAsync(string url)
        {
            return await _orderService.GetItemAsync(url);
        }

        public async Task<bool> CreateOrder(string url, OrderVM orderVM)
        {
            return await _orderService.PostItemAsync(url, orderVM);
        }

		public async Task<bool> UpdateOrderAsync(string url, OrderVM orderToUpd)
		{
			return await _orderService.PutItemAsync(url, orderToUpd);
		}

		public async Task<bool> DeleteOrderAsync(string url)
		{
			return await _orderService.DeleteItemFromURLAsync(url);
		}
	}
}
