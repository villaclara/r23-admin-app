using System.ComponentModel.DataAnnotations;

namespace AdminApp.WASM.Models.FormModels
{
    public class NewOrderFormModel
    {
        [Required(ErrorMessage = "ПІБ")]
        public string Name { get; set; } = null!;

        public DateTime DateOrdered { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Некоректний номер телефону")]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Місто не вказане.")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Адреса доставки некоректна.")]
        public string Adress { get; set; } = null!;

        public Dictionary<int, int> CandleIdAndQuantity { get; set; } = new();

        [Required(ErrorMessage = "Сума не вказана.")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public string? Comment { get; set; }

        public string? Promocode { get; set; }
    }
}
