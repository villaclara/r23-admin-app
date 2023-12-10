using AdminApp.WASM.Application.Utility;
using System.ComponentModel.DataAnnotations;

namespace AdminApp.WASM.Models.FormModels
{
    public class NewCandleFormModel
    {
        [Required(ErrorMessage = "Має бути назва")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Має бути категорія")]
        public string Category { get; set; } = null!;

        public string? PhotoLink { get; set; }

        [Required(ErrorMessage = "Собівартість не встановлена")]
        [Range(1, int.MaxValue, ErrorMessage = "Мінімальне значення - 1")]
        public decimal? RealCost { get; set; }

        [Required(ErrorMessage = "Ціна продажу не встановлена")]
        [Range(1, int.MaxValue, ErrorMessage = "Мінімальне значення - 1")]
        public decimal? SellPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Мінімальне значення - 1")]
        public float? HeightCM { get; set; } = 1;

        [Range(1, int.MaxValue, ErrorMessage = "Мінімальне значення - 1")]
        public int? BurningTimeMins { get; set; } = 1;

        [Required(ErrorMessage = "Грам воску не встановлено")]
        [Range(1, int.MaxValue, ErrorMessage = "Мінімальне значення - 1")]
        public int? WaxNeededGram { get; set; }

        [Required(ErrorMessage = "Гніт не встановлений")]
        [Range(1, int.MaxValue, ErrorMessage = "Мінімальне значення - 1")]
        public int? WickDiameterCM { get; set; }
    }
}
