using AdminApp.WASM.Application.Interfaces;
using AdminApp.WASM.Application.Utility;
using AdminApp.WASM.ViewModels;

namespace AdminApp.WASM.Application.Order
{
	public class OrderInteractor
	{
		private readonly IGetItem<OrderVM> _getOrders;

		public OrderInteractor(IGetItem<OrderVM> getOrders)
		{
			_getOrders = getOrders;
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
			var orders = await _getOrders.GetListAsync(url);
			return orders;
		}



	}
}
