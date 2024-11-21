using Vendor_ListingManagement.Models.ListingItem;
using Vendor_ListingManagement.Entities;
using Vendor_ListingManagement.Enums;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
namespace Vendor_ListingManagement.Mapping
{
    public static class ListingItemMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<ListingItem, LogModel> FullDataModelToEntity(this ListingItem? entity, ListingItemFullDataModel model)
        {
            LogModel logModel = new LogModel();
            ListingItem? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new ListingItem();
            }
            else
            {
                currentEntityJsonString = JsonConvert.SerializeObject(entity);
            }
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.NameLocalized = model.NameLocalized;
            entity.DeletedDate = model.DeletedDate;
            entity.DeleterName = model.DeleterName;
            entity.IsDeleted = model.IsDeleted;
            entity.ModifiedDate = model.ModifiedDate;
            entity.ModifierName = model.ModifierName;
            entity.UpdateDate = model.UpdateDate;
            entity.UpdaterName = model.UpdaterName;
            entity.State = model.State;
            entity.maxticketnumber = model.maxticketnumber;
            entity.IsOccupied = model.IsOccupied;
            entity.OccupiedFrom = model.OccupiedFrom;
            entity.OccupiedTo = model.OccupiedTo;
            entity.ItemSubCategoriesId = model.ItemSubCategoriesId;
            entity.VendorBusinessId = model.VendorBusinessId;
            entity.DescriptionLocalized = model.DescriptionLocalized;
            entity.Description = model.Description;
            if (currentEntity == null)
            {
                entity.ModifiedDate = DateTime.Now;
                entity.ModifierName = AuthenticationHelper.GetUserName();
                logModel.LogType = (int)LogTypeEnum.Add;
                logModel.UserId = AuthenticationHelper.GetUserId();
                logModel.UserName = AuthenticationHelper.GetUserName();
                entity.StateCode = (int)StateEnum.ItemActivate;
                entity.State = StateEnum.ItemActivate.ToString();
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
            return new Pair<ListingItem, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static ListingItemFullDataModel EntityToFullDataModel(ListingItem? entity)
        {
            return new ListingItemFullDataModel
            {
                Id = entity?.Id ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                Name = entity?.Name,
                NameLocalized = entity?.NameLocalized,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                State = entity?.State,
                maxticketnumber = entity?.maxticketnumber,
                IsOccupied = entity?.IsOccupied,
                OccupiedFrom = entity?.OccupiedFrom,
                OccupiedTo = entity?.OccupiedTo,
                ItemSubCategoriesName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.ItemSubCategories?.Name : entity?.ItemSubCategories?.NameLocalized,
                ItemSubCategoriesId = entity?.ItemSubCategoriesId,
                VendorBusinessId = entity?.VendorBusinessId,
                DescriptionLocalized = entity?.DescriptionLocalized,
                Description = entity?.Description,
                StateCode = entity?.StateCode,
                Details = ListingItemDetailMapping.EntityToFullDataModelList(entity.Details)

            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(ListingItem? entity)
        {
            return new BaseDropDown
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        //....
        // EntityToOuterIncludeModel Function Used For External Relationship To Map Entity To  OuterIncludeModel
        //....
        public static OuterIncludeModel EntityToOuterIncludeModel(ListingItem? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(ListingItem? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? entity?.Name ?? "" : entity?.NameLocalized ?? ""; }
    }
}
