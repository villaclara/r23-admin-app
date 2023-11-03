namespace AdminApp.WASM.Models.ViewModels
{
	public class ExpenseVM
	{
		public int Id { get; set; }
		public string Description { get; set; } = null!;
		public DateOnly Date { get; set; }
		public decimal Cost { get; set; }
	}
}
