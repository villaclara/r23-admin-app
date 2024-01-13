using AdminApp.WASM.Application.Interfaces;
using Microsoft.AspNetCore.Components;

namespace AdminApp.WASM.Application.Services;

public class NavManagerNavigationService : INavigation
{
	private readonly NavigationManager _navigationManager;

	public NavManagerNavigationService(NavigationManager navigationManager)
	{
		_navigationManager = navigationManager;
	}

	public void PerformNavigation(string? where)
	{
		_navigationManager.NavigateTo(where ?? "/");
	}

	public async Task PerformNavigationWithDelayAsync(string? toWhere)
	{
		await Task.Delay(1000);
		PerformNavigation(toWhere);
	}
}
