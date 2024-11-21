﻿using Vendor_ListingManagement.Models.ItemSubCategories;
using Vendor_ListingManagement.Entities;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
namespace Vendor_ListingManagement.Mapping
{
    public static class ItemSubCategoriesMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<ItemSubCategories, LogModel> FullDataModelToEntity(this ItemSubCategories? entity, ItemSubCategoriesFullDataModel model)
        {
            LogModel logModel = new LogModel();
            ItemSubCategories? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new ItemSubCategories();
            }
            else
            {
                currentEntityJsonString = JsonConvert.SerializeObject(entity);
            }
            entity.Id = model.Id;
            entity.ItemCategoriesId = model.ItemCategoriesId;
            entity.Name = model.Name;
            entity.NameLocalized = model.NameLocalized;
            entity.DeletedDate = model.DeletedDate;
            entity.DeleterName = model.DeleterName;
            entity.IsDeleted = model.IsDeleted;
            entity.ModifiedDate = model.ModifiedDate;
            entity.ModifierName = model.ModifierName;
            entity.UpdateDate = model.UpdateDate;
            entity.UpdaterName = model.UpdaterName;
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
            return new Pair<ItemSubCategories, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static ItemSubCategoriesFullDataModel EntityToFullDataModel(ItemSubCategories? entity)
        {
            return new ItemSubCategoriesFullDataModel
            {
                Id = entity?.Id ?? 0,
                ItemCategoriesId = entity?.ItemCategoriesId,
                ItemCategoriesName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.ItemCategories?.Name : entity?.ItemCategories?.NameLocalized,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                Name = entity?.Name,
                NameLocalized = entity?.NameLocalized,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(ItemSubCategories? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(ItemSubCategories? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(ItemSubCategories? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? entity?.Name ?? "" : entity?.NameLocalized ?? ""; }
    }
}