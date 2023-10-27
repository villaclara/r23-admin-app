namespace AdminApp.WASM.Application.Interfaces
{
	public interface IPutItem<T> where T : class
	{
		Task<bool> PutItemAsync(string url, T item);
	}
}
