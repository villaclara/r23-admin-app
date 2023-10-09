namespace AdminApp.WASM.Application.Interfaces
{
	public interface IPostItem<T> where T : class
	{
		Task<bool> PostItem<T>(string url, T item);
	}
}
