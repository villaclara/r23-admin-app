namespace AdminApp.WASM.Models.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalSum { get; set; }
        public string? Promocode { get; set; }
        public string? Comments { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OrderDetailsVM> OrderDetails { get; set; } = null!;
        public int ReceiverRepeat { get; set; }
        public OrderReceiverVM Receiver { get; set; } = null!;

    }
}
