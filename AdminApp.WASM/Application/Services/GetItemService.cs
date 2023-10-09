using AdminApp.WASM.Application.Interfaces;
using AdminApp.WASM.ViewModels;
using System.IO;
using System.Net;
using System.Net.Http.Json;

namespace AdminApp.WASM.Application.Services
{
    public class GetItemService<T> : IGetItem<T> where T : class
    {
        private readonly HttpClient _httpClient;

        public GetItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

		public async Task<IEnumerable<T>> GetListAsync(string url)
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
	}
}
