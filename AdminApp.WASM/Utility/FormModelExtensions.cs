using AdminApp.WASM.Pages.FormModels;
using AdminApp.WASM.ViewModels;

namespace AdminApp.WASM.Utility
{
	public static class FormModelExtensions
	{
		public static CandleFullVM ConvertToFullVM_FromFormModel(this NewCandleFormModel model) =>
			new()
			{
				Id = 1,
				Name = model.Name,
				Description = model.Description,
				Category = model.Category,
				PhotoLink = model.PhotoLink,
				RealCost = (decimal)model.RealCost!,
				SellPrice = (decimal)model.SellPrice!,
				HeightCM = (int)model.HeightCM!,
				BurningTimeMins = (int)model.BurningTimeMins!,
				WickDiameterCM = (int)model.WickDiameterCM!,
				WaxNeededGram = (int)model.WaxNeededGram!
			};

		public static NewCandleFormModel ConvertToFormModel_FromFullVM(this CandleFullVM model) =>
			new()
			{
				Name = model.Name,
				Description = model.Description,
				Category = model.Category,
				PhotoLink = model.PhotoLink,
				RealCost = model.RealCost,
				SellPrice = model.SellPrice,
				HeightCM = model.HeightCM,
				BurningTimeMins = model.BurningTimeMins,
				WickDiameterCM = model.WickDiameterCM,
				WaxNeededGram = model.WaxNeededGram
			};
	}
}
