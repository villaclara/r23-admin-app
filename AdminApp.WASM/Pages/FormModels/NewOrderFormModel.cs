using System.ComponentModel.DataAnnotations;

namespace AdminApp.WASM.Pages.FormModels
{
	public class NewOrderFormModel
	{
        [Required(ErrorMessage = "PIB")]
		public string Name { get; set; } = null!;
		
		[Required(ErrorMessage = "Phonenumber")]
		public string PhoneNumber { get; set; } = null!;

		public string City { get; set; } = null!;

		[Required]
		public string Adress { get; set; } = null!;

		public string Candle { get; set; } = null!;

 		public string Quantity { get; set; } = null!;

		public string Price { get; set; } = null!;

		public string Comment { get; set; } = null!;

		public string Promocode { get; set; } = null!;
	}
}
