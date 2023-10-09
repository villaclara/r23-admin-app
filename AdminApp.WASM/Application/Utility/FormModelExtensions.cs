using AdminApp.WASM.Pages.FormModels;
using AdminApp.WASM.ViewModels;

namespace AdminApp.WASM.Application.Utility
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


        public static CandleFullVM UpdateValues_FromFormModel(this CandleFullVM model, NewCandleFormModel updatedModel)
        {
            model.Name = updatedModel.Name;
            model.Description = updatedModel.Description;
            model.Category = updatedModel.Category;
            model.PhotoLink = updatedModel.PhotoLink;
            model.RealCost = updatedModel.RealCost ?? model.RealCost;
            model.SellPrice = updatedModel.SellPrice ?? model.SellPrice;
            model.HeightCM = updatedModel.HeightCM ?? model.HeightCM;
            model.BurningTimeMins = updatedModel.BurningTimeMins ?? model.BurningTimeMins;
            model.WickDiameterCM = updatedModel.WickDiameterCM ?? model.WickDiameterCM;
            model.WaxNeededGram = updatedModel.WaxNeededGram ?? model.WaxNeededGram;

            return model;
        }
    }
}
