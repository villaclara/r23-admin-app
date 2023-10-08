namespace AdminApp.WASM.Interfaces
{
	public interface IHttpCheckerService
	{
		Task<bool> CheckItemExistsByPathAsync(string path);
	}
}
