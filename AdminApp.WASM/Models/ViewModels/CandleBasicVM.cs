namespace AdminApp.WASM.Models.ViewModels
{
    public class CandleBasicVM
    {
        public string Name { get; set; } = null!;
        public string? Desciption { get; set; }
        public string Category { get; set; } = null!;
        public decimal Price { get; set; }
        public int Height { get; set; }
        public int? BurningTime { get; set; }

    }
}
