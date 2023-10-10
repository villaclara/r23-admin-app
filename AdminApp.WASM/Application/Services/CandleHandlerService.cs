using AdminApp.WASM.Application.Interfaces;
using AdminApp.WASM.Application.Utility;
using AdminApp.WASM.ViewModels;

namespace AdminApp.WASM.Application.Services
{
    public class CandleHandlerService
    {
        private readonly ICRUDService<CandleFullVM> _candleService;

        public CandleHandlerService(ICRUDService<CandleFullVM> candleService)
        {
            _candleService = candleService;
        }

        public async Task<IEnumerable<CandleFullVM>> GetAllCandlesListAsync(string url)
        {
            return await _candleService.GetItemsAsListAsync(url);
        }

        public async Task<CandleFullVM?> GetCanlde(string url)
        {
            return await _candleService.GetItemAsync(url);
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
            return await _candleService.PostItem(url, newCandle);
        }

        public async Task<bool> UpdateCandleAsync(string url, CandleFullVM candleToUpd)
        {
            return await _candleService.PutItem(url, candleToUpd);
        }

        public async Task<bool> DeleteCandleAsync(string url)
        {
            return await _candleService.DeleteItemFromURL(url);
        }

    }
}
