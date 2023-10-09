namespace AdminApp.WASM.Application.Interfaces
{
    public interface IGetItem<T> where T : class
    {
        Task<IEnumerable<T>> GetListAsync(string url);
    }
}
