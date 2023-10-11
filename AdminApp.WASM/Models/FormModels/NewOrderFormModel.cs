using System.ComponentModel.DataAnnotations;

namespace AdminApp.WASM.Models.FormModels
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

        public int Candle { get; set; }

        public int Quantity { get; set; }

        public Dictionary<int, int> CandleIdAndQuantity { get; set; } = new();
        public decimal Price { get; set; }

        public string Comment { get; set; } = null!;

        public string Promocode { get; set; } = null!;
    }
}
