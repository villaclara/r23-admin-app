using System.ComponentModel.DataAnnotations;

namespace AdminApp.WASM.Models.FormModels
{
    public class NewCandleFormModel
    {
        [Required(ErrorMessage = "Має бути назва")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Має бути опис")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Має бути категорія")]
        public string Category { get; set; } = null!;

        [Required]
        public string? PhotoLink { get; set; }

        [Required(ErrorMessage = "Собівартість не встановлена")]
        [Range(1, int.MaxValue, ErrorMessage = "Мінімальне значення - 1")]
        public decimal? RealCost { get; set; }

        [Required(ErrorMessage = "Ціна продажу не встановлена")]
        [Range(1, int.MaxValue, ErrorMessage = "Мінімальне значення - 1")]
        public decimal? SellPrice { get; set; }

        [Required(ErrorMessage = "Висота не встановлена")]
        [Range(1, int.MaxValue, ErrorMessage = "Мінімальне значення - 1")]
        public int? HeightCM { get; set; }

        [Required(ErrorMessage = "Час горіння не встановлено")]
        [Range(1, int.MaxValue, ErrorMessage = "Мінімальне значення - 1")]
        public int? BurningTimeMins { get; set; }

        [Required(ErrorMessage = "Грам воску не встановлено")]
        [Range(1, int.MaxValue, ErrorMessage = "Мінімальне значення - 1")]
        public int? WaxNeededGram { get; set; }

        [Required(ErrorMessage = "Гніт не встановлений")]
        [Range(1, int.MaxValue, ErrorMessage = "Мінімальне значення - 1")]
        public int? WickDiameterCM { get; set; }
    }
}
