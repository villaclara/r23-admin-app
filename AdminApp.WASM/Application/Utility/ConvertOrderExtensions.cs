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
				OrderDate = model.DateOrdered,
				Comments = model.Comment,
				Promocode = model.Promocode,
				TotalSum = model.Price,
				IsPaid = model.IsPaid,
				PaymentType = model.PaymentType,
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

		public static NewOrderFormModel ConvertToOrderModel_FromFullVM(this OrderVM ordervm)
		{
			var ordermodel = new NewOrderFormModel()
			{
				Id = ordervm.Id,
				Name = ordervm.Receiver.FullName,
				DateOrdered = ordervm.OrderDate,
				PhoneNumber = ordervm.Receiver.PhoneNumber,
				City = ordervm.Receiver.City,
				Adress = ordervm.Receiver.DeliveryAdress,
				Comment = ordervm.Comments,
				PaymentType = ordervm.PaymentType,
				IsPaid = ordervm.IsPaid,
				Promocode = ordervm.Promocode,
				Price = ordervm.TotalSum,
				CandleIdAndQuantity = new Dictionary<int, int>()
			};

			foreach(var orderdetail in ordervm.OrderDetails)
			{
				ordermodel.CandleIdAndQuantity.Add(orderdetail.CandleId, orderdetail.CandleQuantity);
			}

			return ordermodel;
		}
	}
}
