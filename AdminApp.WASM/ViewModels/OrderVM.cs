namespace AdminApp.WASM.ViewModels
{
	public class OrderVM
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal TotalSum { get; set; }
		public string? Promocode { get; set; }
		public string? Comments { get; set; }
		public string? Receiver { get; set; }
		public int CustomerId { get; set; }
		public ICollection<OrderDetailsVM> OrderDetails { get; set; } = null!;

	}
}
