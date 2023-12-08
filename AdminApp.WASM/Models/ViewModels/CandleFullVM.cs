namespace AdminApp.WASM.Models.ViewModels
{
    public class CandleFullVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Category { get; set; } = null!;
        public string? PhotoLink { get; set; }
        public decimal RealCost { get; set; }
        public decimal SellPrice { get; set; }
        public float HeightCM { get; set; }
        public int BurningTimeMins { get; set; }
        public int WaxNeededGram { get; set; }
        public int WickDiameterCM { get; set; }
    }
}
