namespace AdminApp.WASM.Application.Interfaces;

public interface INavigation
{
	void PerformNavigation(string? where);
	Task PerformNavigationWithDelayAsync(string? toWhere);

}
