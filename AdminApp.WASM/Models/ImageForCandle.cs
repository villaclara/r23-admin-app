namespace AdminApp.WASM.Models;

// used to create a images cache and keep track of it not to download image every time and delete unused
public class ImageForCandle
{
	public ImageForCandle(int candleId, string? remotelink, string localLink, bool isActive)
	{
		CandleId = candleId;
		RemoteLink = remotelink;
		LocalLink = localLink;
		IsActive = isActive;
	}

	public int CandleId { get; set; }
	public string? RemoteLink { get; set; } = null!;
	public string LocalLink { get; set; } = null!;
	public bool IsActive { get; set; }
}
