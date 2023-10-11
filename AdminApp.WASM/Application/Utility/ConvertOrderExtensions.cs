using AdminApp.WASM.Models.FormModels;
using AdminApp.WASM.Models.ViewModels;

namespace AdminApp.WASM.Application.Utility
{
    public static class ConvertOrderExtensions
	{
		public static OrderVM ConvertToFullVM_FromFormModel(this NewOrderFormModel model) =>
			new()
			{
				Id = 1,
				CustomerId = 1,
				OrderDate = DateTime.Now,
				Comments = model.Comment,
				Promocode = model.Promocode,
				TotalSum = model.Price,
				Receiver = new OrderReceiverVM
				{
					FullName = model.Name,
					PhoneNumber = model.PhoneNumber,
					City = model.City,
					DeliveryAdress = model.Adress
				},
				OrderDetails = new List<OrderDetailsVM>()
				{
					new OrderDetailsVM()
					{
						CandleQuantity = model.Quantity,
						CandleId = model.Candle
					}
				},
				ReceiverRepeat = 1
			};
	}
}
