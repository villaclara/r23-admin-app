using AdminApp.WASM.Application.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;

namespace AdminApp.WASM.Application.Services
{
	public class CRUDService<T> : ICRUDService<T> where T : class
	{
		private readonly HttpClient _httpClient;
		public CRUDService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<bool> DeleteItemFromURLAsync(string url)
		{
			var result = await _httpClient.DeleteAsync(url);
			return result.IsSuccessStatusCode;
		}

		public async Task<T?> GetItemAsync(string url)
		{
			try
			{
				return await _httpClient.GetFromJsonAsync<T>(url);
			}
			catch(Exception)
			{
				return default;
			}
		}

		public async Task<IEnumerable<T>> GetItemsAsListAsync(string url)
		{
			try
			{
				return await _httpClient.GetFromJsonAsync<IEnumerable<T>>(url) ?? Enumerable.Empty<T>();
			}
			catch (Exception)
			{
				return Enumerable.Empty<T>();
			}
		}

		public async Task<bool> PostItemAsync(string url, T item)
		{
			var result = await _httpClient.PostAsJsonAsync(url, item);
			return result.IsSuccessStatusCode;
		}

		public async Task<bool> PutItemAsync(string url, T item)
		{
			var result = await _httpClient.PutAsJsonAsync(url, item);
			return result.IsSuccessStatusCode;
		}
	}
}
