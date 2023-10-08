namespace AdminApp.WASM.Interfaces
{
	public interface IHttpCheckerService
	{
		Task<HttpResponseMessage> CheckCandlesExistAsync();
		Task<HttpResponseMessage> CheckOrdersExistAsync();
	}
}
