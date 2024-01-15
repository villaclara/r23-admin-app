using AdminApp.WASM.Models;
using AdminApp.WASM.Models.ViewModels;
using System.Net.Http.Json;

namespace AdminApp.WASM.Application.Services;


// creates each time new object
public class CandleImageCacheService
{
	public List<ImageForCandle> ImagesCache;
	private string _path = "api/Candle?view=full";

	public async Task InitializeCache_IfNeeded(CandleHandlerService candleService, HttpClient httpClient)
	{
		//var data = await _httpClient.GetFromJsonAsync<IEnumerable<CandleFullVM>>(_path) ?? Enumerable.Empty<CandleFullVM>();
		var data = await candleService.GetAllCandlesListAsync(_path);
		
		// if the cache already exists
		if(ImagesCache is not null)
		{
			// comparing each element from received list from server to see if the photo link was updated
			foreach(var candle in data)
			{
				// find item in cache
				var cacheItem = ImagesCache.Find(c => c.CandleId == candle.Id);
				if(cacheItem != null)
				{
					// if remote photo link the same = return
					if(cacheItem.RemoteLink == candle.PhotoLink)
					{
						return;
					}

					// else we assing new remote photo link and download new image
					cacheItem.RemoteLink = candle.PhotoLink;
					// here we need to download sting image
					cacheItem.LocalLink = await GetImageAsStringAsync(candle.Id, httpClient);
				}
			}
		}

		// no cache, creating one
		else
		{
			ImagesCache = new List<ImageForCandle>();
			foreach (var c in data)
			{
				// get image as string for each cache
				var response = await httpClient.GetAsync(@$"api/candle/imgForId={c.Id}");
				var imgstr = await response.Content.ReadAsStringAsync();

				var imageAsString = "img/question_mark.png";

				if (!string.IsNullOrEmpty(imgstr))
				{
					imageAsString = string.Format("data:image/jpeg;base64,{0}", imgstr);
				}

				// add cached item in the list
				ImagesCache.Add(new ImageForCandle(c.Id, c.PhotoLink, localLink: imageAsString, true));
			}
		}
	}



	private async Task<string> GetImageAsStringAsync(int id, HttpClient httpClient)
	{
		// get image as string for each cache
		var response = await httpClient.GetAsync(@$"api/candle/imgForId={id}");
		var imgstr = await response.Content.ReadAsStringAsync();

		var imageAsString = "img/question_mark.png";

		if (!string.IsNullOrEmpty(imgstr))
		{
			imageAsString = string.Format("data:image/jpeg;base64,{0}", imgstr);
		}

		return imageAsString;
	}
}



public class CandleImageCacheServiceFactory
{
	private readonly CandleHandlerService _candleService;
	private readonly HttpClient _httpClient;
	private string _path = "api/Candle?view=full";

	public CandleImageCacheServiceFactory(CandleHandlerService candleService, HttpClient client)
	{
		_candleService = candleService;
		_httpClient = client;
	}

	//public async Task<CandleImageCacheService> CreateCacheAsync()
	//{
		
	//	// new object of cacheservice
	//	//var ret = new CandleImageCacheService();
		
	//	// get all candles list from api
	//	var data = await _candleService.GetAllCandlesListAsync(_path);
	//	foreach(var c in data)
	//	{
	//		// get image as string for each cache
	//		var response = await _httpClient.GetAsync(@$"api/candle/imgForId={c.Id}");
	//		var imgstr = await response.Content.ReadAsStringAsync();

	//		var imageAsString = "img/question_mark.png";

	//		if (!string.IsNullOrEmpty(imgstr))
	//		{
	//			imageAsString = string.Format("data:image/jpeg;base64,{0}", imgstr);
	//		}

	//		// add cached item in the list
	//		ret.ImagesCache.Add(new ImageForCandle(c.Id, c.PhotoLink, localLink: imageAsString, true));
	//	}

	//	// return object of cacheService
	//	return ret;
	//}

}
