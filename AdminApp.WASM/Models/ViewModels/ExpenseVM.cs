using System.ComponentModel.DataAnnotations;

namespace AdminApp.WASM.Models.ViewModels
{
	public class ExpenseVM
	{
		public int Id { get; set; }
		[Required]
		public string Description { get; set; } = null!;
		public DateOnly Date { get; set; }
		[Required]
		[Range(1, double.MaxValue)]
		public decimal Cost { get; set; }
	}
}
