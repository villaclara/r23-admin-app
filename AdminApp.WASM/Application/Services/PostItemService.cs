using AdminApp.WASM.Application.Interfaces;
using System.Net.Http.Json;

namespace AdminApp.WASM.Application.Services
{
	public class PostItemService<T> : IPostItem<T> where T : class
	{
		private readonly HttpClient _httpClient;

		public PostItemService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<bool> PostItem<T>(string url, T item)
		{
			var result = await _httpClient.PostAsJsonAsync<T>(url, item);
			return result.IsSuccessStatusCode;
		}
	}
}
