using AdminApp.WASM.Interfaces;

namespace AdminApp.WASM.Services
{
	public class HttpCheckerService : IHttpCheckerService
	{
		private HttpClient _httpClient;

		public HttpCheckerService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<bool> CheckItemExistsByPathAsync(string path)
		{
			var result = await _httpClient.GetAsync(path);
			return result.IsSuccessStatusCode;
		}	
	}
}
