using System.ComponentModel.DataAnnotations;

namespace AdminApp.WASM.Models.FormModels
{
	public class NewExpenseFormModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "Відсутня покупка")]
		public string Description { get; set; } = null!;
		
		[Required(ErrorMessage = "Дата невірна")]
		public DateOnly Date { get; set; }
		
		[Required(ErrorMessage = "Гроші непраивльно введені")]
		[Range(1, double.MaxValue)]
		public decimal Cost { get; set; }
	}
}
