using AdminApp.WASM.Application.Interfaces;
using AdminApp.WASM.Application.Utility;
using AdminApp.WASM.Pages.FormModels;
using AdminApp.WASM.ViewModels;

namespace AdminApp.WASM.Application.Candle
{
	public class CandleInteractor
	{
		private readonly IGetItem<CandleFullVM> _getCandles;
		private readonly IPostItem<CandleFullVM> _postItems;

		public CandleInteractor(IGetItem<CandleFullVM> getCandles, IPostItem<CandleFullVM> postItems)
		{
			_getCandles = getCandles;
			_postItems = postItems;
		}

		public async Task<IEnumerable<CandleFullVM>> GetAllCandlesListAsync(string url)
		{
			return await _getCandles.GetListAsync(url);
		}

		public async Task<IEnumerable<CandleFullVM>> GetLastCandlesListAsync(string url)
		{
			var candles = await GetAllCandlesListAsync(url);
			return candles.Count() switch
			{
				>= Constants.AMOUNT_ITEMS_DISPLAYED_INDEXPAGE => candles.OrderByDescending(c => c.Id).Take(Constants.AMOUNT_ITEMS_DISPLAYED_INDEXPAGE),
				> 0 and < Constants.AMOUNT_ITEMS_DISPLAYED_INDEXPAGE => candles.OrderByDescending(c => c.Id),
				_ => Enumerable.Empty<CandleFullVM>()
			};
		}


		public async Task<bool> CreateCandleAsync(string url, CandleFullVM newCandle)
		{
			return await _postItems.PostItem(url, newCandle);
		}
	}
}
