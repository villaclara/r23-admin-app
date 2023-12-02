using AdminApp.WASM.Application.Interfaces;
using Microsoft.AspNetCore.Components.Forms;

namespace AdminApp.WASM.Application.Services
{
	public class MultipartDataContent_ImageUploader : IImageUploader
	{

		private readonly HttpClient _httpClient;

		//public IBrowserFile? BrowserFile { get; set; }
		
		public MultipartDataContent_ImageUploader(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}


		public async Task<bool> UploadImageToCandleByIdAsync(int candleId, IBrowserFile? browserFile)
		{
			if (browserFile is null)
				return true;

			try
			{
				// SENDING IMAGE TO WEB API TO SAVE ON SERVER
				// candleId = should be actual candle id
				using var content = new MultipartFormDataContent();
				var fileContent = new StreamContent(browserFile.OpenReadStream(browserFile.Size));
				fileContent.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("multipart/form-data");

				content.Add(content: fileContent, name: "file", browserFile.Name);
				var result = await _httpClient.PostAsync($"api/candle/upload?candleId={candleId}", content);
				if (!result.IsSuccessStatusCode)
				{
					throw new Exception();
				}

				return true;
			}

			catch (Exception)
			{
				return false;
			}
		}
	}
}
