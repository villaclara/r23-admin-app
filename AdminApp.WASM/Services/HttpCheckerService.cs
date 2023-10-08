using AdminApp.WASM.Interfaces;

namespace AdminApp.WASM.Services
{
	public class HttpCheckerService : IHttpCheckerService
	{
		private string _candlesPath;
		private string _ordersPath;
		private HttpClient _httpClient;
		//public HttpCheckerService(string candlesPath, string ordersPath, HttpClient httpClient)
		//{
		//	_candlesPath = candlesPath;
		//	_ordersPath = ordersPath;
		//	_httpClient = httpClient;
		//}

		public HttpCheckerService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_candlesPath = "api/candle?view=full";
			_ordersPath = "api/order";
		}
		public async Task<HttpResponseMessage> CheckCandlesExistAsync() =>
			await _httpClient.GetAsync(_candlesPath);

		public async Task<HttpResponseMessage> CheckOrdersExistAsync() =>
			await _httpClient.GetAsync(_ordersPath);
	}
}
