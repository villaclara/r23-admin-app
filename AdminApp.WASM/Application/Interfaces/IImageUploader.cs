using Microsoft.AspNetCore.Components.Forms;

namespace AdminApp.WASM.Application.Interfaces
{
	public interface IImageUploader
	{
		Task<bool> UploadImageToCandleByIdAsync(int candleId, IBrowserFile? browserFile);
	}
}
