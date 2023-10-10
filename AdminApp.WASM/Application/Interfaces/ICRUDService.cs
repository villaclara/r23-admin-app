namespace AdminApp.WASM.Application.Interfaces
{
	public interface ICRUDService<T> : IGetItem<T>, IPostItem<T>, IDeleteItem<T>, IPutItem<T> where T : class
	{

	}
}
