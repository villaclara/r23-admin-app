namespace AdminApp.WASM.Application.Interfaces
{
    // get the entity of type T
    public interface IGetItem<T> where T : class
    {
        Task<IEnumerable<T>> GetItemsAsListAsync(string url);

        Task<T?> GetItemAsync(string url);
    }
}
