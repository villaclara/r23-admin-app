namespace AdminApp.WASM.Models
{
	public class CandleOrdered
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int Quantity { get; set; }
		public decimal Price { get; set; }


		public decimal TotalSum { 
			get => Quantity * Price; 
		}  
		public int WaxNeededGramm { get; set; }
		public int WickDiameterCM { get; set; }
	}
}