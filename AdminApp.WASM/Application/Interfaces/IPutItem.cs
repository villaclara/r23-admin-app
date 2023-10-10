namespace AdminApp.WASM.Application.Interfaces
{
	public interface IPutItem<T> where T : class
	{
		Task<bool> PutItem(string url, T item);
	}
}
