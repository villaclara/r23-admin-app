using AdminApp.WASM.Models.FormModels;
using AdminApp.WASM.Models.ViewModels;

namespace AdminApp.WASM.Application.Utility
{
    public static class ConvertOrderExtensions
	{
		public static OrderVM ConvertToFullVM_FromFormModel(this NewOrderFormModel model)
		{
			var order = new OrderVM()
			{
				
				Id = 1,		// do not care
				CustomerId = 1,		// care
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
				OrderDetails = new List<OrderDetailsVM>(),
				ReceiverRepeat = 1 // do not care
			};


			// converting all ordered candles form Dictionary to OrderDetailsVM
			foreach(var candleordered in model.CandleIdAndQuantity)
			{
				order.OrderDetails.Add(
					new OrderDetailsVM()
					{
						CandleId = candleordered.Key,
						CandleQuantity = candleordered.Value
					});
			}

			return order;
		}
	}
}
