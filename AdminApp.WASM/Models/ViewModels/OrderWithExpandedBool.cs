namespace AdminApp.WASM.Models.ViewModels
{
	public class OrderWithExpandedBool
	{
		public OrderVM OrderVM { get; set; } = null!;
		public bool Expanded { get; set; } = false;

		public OrderWithExpandedBool(OrderVM ordervm, bool value)
		{
			OrderVM = ordervm;
			Expanded = value;
		}
	}
}
