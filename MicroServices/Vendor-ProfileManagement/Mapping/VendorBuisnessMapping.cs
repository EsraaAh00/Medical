using Vendor_ProfileManagement.Models.VendorBusiness;
using Vendor_ProfileManagement.Entities;
using Vendor_ProfileManagement.Enums;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
namespace Vendor_ProfileManagement.Mapping
{
    public static class VendorBusinessMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<VendorBusiness, LogModel> FullDataModelToEntity(this VendorBusiness? entity, VendorBusinessFullDataModel model)
        {
            LogModel logModel = new LogModel();
            VendorBusiness? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new VendorBusiness();
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
            entity.LandLine = model.LandLine;
            entity.LoactionLatitude = model.LoactionLatitude;
            entity.LoactionLongitude = model.LoactionLongitude;
            entity.Logo = model.Logo;
            entity.Cover = model.Cover;
            entity.BusinessStatus = model.BusinessStatus;
            entity.VendorId = model.VendorId;
            entity.BusinessTypeCategoryId = model.BusinessTypeCategoryId;
            if (currentEntity == null)
            {
                entity.ModifiedDate = DateTime.Now;
                entity.ModifierName = AuthenticationHelper.GetUserName();
                logModel.LogType = (int)LogTypeEnum.Add;
                logModel.UserId = AuthenticationHelper.GetUserId();
                logModel.UserName = AuthenticationHelper.GetUserName();
                entity.BusinessStatusCode = (int)BusinessStatusEnum.Active;
                entity.BusinessStatus = BusinessStatusEnum.Active.ToString();
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
            return new Pair<VendorBusiness, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static VendorBusinessFullDataModel EntityToFullDataModel(VendorBusiness? entity)
        {
            return new VendorBusinessFullDataModel
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
                LandLine = entity?.LandLine,
                LoactionLatitude = entity?.LoactionLatitude,
                LoactionLongitude = entity?.LoactionLongitude,
                Logo = entity?.Logo,
                Cover = entity?.Cover,
                BusinessStatus = entity?.BusinessStatus,
                VendorName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.Vendor?.Name : entity?.Vendor?.NameLocalized,
                VendorId = entity?.VendorId,
                BusinessTypeCategoryName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.BusinessTypeCategory?.Name : entity?.BusinessTypeCategory?.NameLocalized,
                BusinessTypeCategoryId = entity?.BusinessTypeCategoryId,
            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(VendorBusiness? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(VendorBusiness? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(VendorBusiness? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? entity?.Name ?? "" : entity?.NameLocalized ?? ""; }
    }
}
