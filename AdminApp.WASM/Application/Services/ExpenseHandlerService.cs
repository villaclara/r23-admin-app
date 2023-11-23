using AdminApp.WASM.Application.Interfaces;
using AdminApp.WASM.Models.ViewModels;

namespace AdminApp.WASM.Application.Services
{
	public class ExpenseHandlerService
	{
		private readonly ICRUDService<ExpenseVM> _expenseService;
		public ExpenseHandlerService(ICRUDService<ExpenseVM> expenseService)
		{
			_expenseService = expenseService;
		}

		public async Task<ICollection<ExpenseVM>> GetExpensesAsync(string url)
		{
			return (ICollection<ExpenseVM>)await _expenseService.GetItemsAsListAsync(url) ?? new List<ExpenseVM>();
		}

		public async Task<bool> AddExpenseAsync(string url, ExpenseVM newExpense)
		{
			return await _expenseService.PostItemAsync(url, newExpense);
		}

		public async Task<bool> UpdateExpenseAsync(string url, ExpenseVM newExpense)
		{
			return await _expenseService.PutItemAsync(url, newExpense);
		}

		public async Task<bool> DeleteExpenseAsync(string url)
		{
			return await _expenseService.DeleteItemFromURLAsync(url);
		}
	}
}
