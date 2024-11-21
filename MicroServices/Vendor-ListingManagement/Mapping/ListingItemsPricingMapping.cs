using Vendor_ListingManagement.Models.ListingItemsPricing;
using Vendor_ListingManagement.Entities;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
namespace Vendor_ListingManagement.Mapping
{
    public static class ListingItemsPricingMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<ListingItemsPricing, LogModel> FullDataModelToEntity(this ListingItemsPricing? entity, ListingItemsPricingFullDataModel model)
        {
            LogModel logModel = new LogModel();
            ListingItemsPricing? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new ListingItemsPricing();
            }
            else
            {
                currentEntityJsonString = JsonConvert.SerializeObject(entity);
            }
            entity.Id = model.Id;
            entity.DeletedDate = model.DeletedDate;
            entity.DeleterName = model.DeleterName;
            entity.IsDeleted = model.IsDeleted;
            entity.ModifiedDate = model.ModifiedDate;
            entity.ModifierName = model.ModifierName;
            entity.UpdateDate = model.UpdateDate;
            entity.UpdaterName = model.UpdaterName;
            entity.IsPackage = model.IsPackage;
            entity.DestinationId = model.DestinationId;
            entity.Destination = model.Destination;
            entity.DestinationLocalized = model.DestinationLocalized;
            entity.BaseAmount = model.BaseAmount;
            entity.BaseAppliedNumber = model.BaseAppliedNumber;
            entity.PricePerextraPerson = model.PricePerextraPerson;
            entity.ChargeFrequency = model.ChargeFrequency;
            entity.ChargeFrequencyType = model.ChargeFrequencyType;
            entity.ChargeFrequencyTypeCode = model.ChargeFrequencyTypeCode;
            entity.ApplicableType = model.ApplicableType;
            entity.ApplicableTypeCode = model.ApplicableTypeCode;
            entity.ListingItemId = model.ListingItemId;
            entity.ApplicableTypeNumber = model.ApplicableTypeNumber;
            if (currentEntity == null)
            {
                entity.ModifiedDate = DateTime.Now;
                entity.ModifierName = AuthenticationHelper.GetUserName();
                logModel.LogType = (int)LogTypeEnum.Add;
                logModel.UserId = AuthenticationHelper.GetUserId();
                logModel.UserName = AuthenticationHelper.GetUserName();
            }
            else if (currentEntity.IsDeleted == true && entity.IsDeleted == false)
            {
                entity.UpdateDate = DateTime.Now;
                entity.UpdaterName = AuthenticationHelper.GetUserName();
                logModel.LogType = (int)LogTypeEnum.Activate;
                logModel.UserId = AuthenticationHelper.GetUserId();
                logModel.UserName = AuthenticationHelper.GetUserName();
            }
            else if (currentEntity.IsDeleted == false && entity.IsDeleted == true)
            {
                entity.DeletedDate = DateTime.Now;
                entity.DeleterName = AuthenticationHelper.GetUserName();
                logModel.LogType = (int)LogTypeEnum.Delete;
                logModel.UserId = AuthenticationHelper.GetUserId();
                logModel.UserName = AuthenticationHelper.GetUserName();
            }
            else
            {
                entity.UpdateDate = DateTime.Now;
                entity.UpdaterName = AuthenticationHelper.GetUserName();
                logModel.LogType = (int)LogTypeEnum.Edit;
                logModel.UserId = AuthenticationHelper.GetUserId();
                logModel.UserName = AuthenticationHelper.GetUserName();
            }
            logModel.JsonBefore = currentEntityJsonString;
            return new Pair<ListingItemsPricing, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static ListingItemsPricingFullDataModel EntityToFullDataModel(ListingItemsPricing? entity)
        {
            return new ListingItemsPricingFullDataModel
            {
                Id = entity?.Id ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                IsPackage = entity?.IsPackage,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                BaseAmount = entity?.BaseAmount,
                ChargeFrequencyType = entity?.ChargeFrequencyType,
                ChargeFrequencyTypeCode = entity?.ChargeFrequencyTypeCode,
                ChargeFrequency = entity?.ChargeFrequency,
                ApplicableType = entity?.ApplicableType,
                ApplicableTypeCode = entity?.ApplicableTypeCode,
                ApplicableTypeNumber = entity?.ApplicableTypeNumber,
                ListingItemName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.ListingItem?.Name : entity?.ListingItem?.NameLocalized,
                ListingItemId = entity?.ListingItemId
            };
        }
        private static string GetName(ListingItemsPricing? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? $"" : $""; }
    }
}
