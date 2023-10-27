using AdminApp.WASM.Application.Interfaces;
using AdminApp.WASM.Models.ViewModels;

namespace AdminApp.WASM.Application.Services
{
	public class CategoryHandlerService 
	{
		private readonly ICRUDService<CategoryVM> _categoryService;

		public CategoryHandlerService(ICRUDService<CategoryVM> categoryService)
		{
			_categoryService = categoryService;
		}


		public Task<bool> DeleteCategoryAsync(string url)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<CategoryVM>> GetCategoryListAsync(string url)
		{
			return await _categoryService.GetItemsAsListAsync(url);

		}
		public async Task<bool> AddCategoryAsync(string url, CategoryVM item)
		{
			return await _categoryService.PostItemAsync(url, item);
		}

		public Task<bool> UpdateCategoryAsync(string url, CategoryVM item)
		{
			throw new NotImplementedException();
		}
	}
}
