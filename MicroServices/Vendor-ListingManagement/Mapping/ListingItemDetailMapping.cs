using Vendor_ListingManagement.Models.ListingItemDetail;
using Vendor_ListingManagement.Entities;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
namespace Vendor_ListingManagement.Mapping
{
    public static class ListingItemDetailMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<ListingItemDetail, LogModel> FullDataModelToEntity(this ListingItemDetail? entity, ListingItemDetailFullDataModel model)
        {
            LogModel logModel = new LogModel();
            ListingItemDetail? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new ListingItemDetail();
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
            entity.ListingItemId = model.ListingItemId;
            entity.ListingItemDetailSettingId = model.ListingItemDetailSettingId;
            entity.ValueLocalized = model.ValueLocalized;
            entity.Value = model.Value;
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
            return new Pair<ListingItemDetail, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static ListingItemDetailFullDataModel EntityToFullDataModel(ListingItemDetail? entity)
        {
            return new ListingItemDetailFullDataModel
            {
                Id = entity?.Id ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                ListingItemName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.ListingItem?.Name : entity?.ListingItem?.NameLocalized,
                ListingItemId = entity?.ListingItemId,
                ListingItemDetailSettingName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.ListingItemDetailSetting?.Name : entity?.ListingItemDetailSetting?.NameLocalized,
                ListingItemDetailSettingCode = entity?.ListingItemDetailSetting?.Code,
                ListingItemDetailSettingId = entity?.ListingItemDetailSettingId,
                ValueLocalized = entity?.ValueLocalized,
                Value = entity?.Value,
                Setting = ListingItemDetailSettingMapping.EntityToFullDataModel(entity.ListingItemDetailSetting),

            };
        }

        public static List<ListingItemDetailFullDataModel> EntityToFullDataModelList(List<ListingItemDetail>? entities)
        {
            return entities.Select(s => ListingItemDetailMapping.EntityToFullDataModel(s)).ToList();
        }


        private static string GetName(ListingItemDetail? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? $"" : $""; }
    }
}
