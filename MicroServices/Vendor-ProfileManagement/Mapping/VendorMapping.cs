using Vendor_ProfileManagement.Models.Vendor;
using Vendor_ProfileManagement.Entities;
using Vendor_ProfileManagement.Enums;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
namespace Vendor_ProfileManagement.Mapping
{
    public static class VendorMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<Vendor, LogModel> FullDataModelToEntity(this Vendor? entity, VendorFullDataModel model)
        {
            LogModel logModel = new LogModel();
            Vendor? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new Vendor();
            }
            else
            {
                currentEntityJsonString = JsonConvert.SerializeObject(entity);
            }
            entity.Id = model.Id;
            entity.UserID = model.UserId;
            entity.Name = model.Name;
            entity.NameLocalized = model.NameLocalized;
            entity.DeletedDate = model.DeletedDate;
            entity.DeleterName = model.DeleterName;
            entity.IsDeleted = model.IsDeleted;
            entity.ModifiedDate = model.ModifiedDate;
            entity.ModifierName = model.ModifierName;
            entity.UpdateDate = model.UpdateDate;
            entity.UpdaterName = model.UpdaterName;
            entity.Email = model.Email;
            entity.Phone = model.Phone;
            entity.Logo = model.Logo;
            entity.Cover = model.Cover;
            entity.ManagerNationalIdFront = model.ManagerNationalIdFront;
            entity.ManagerNationalIdBack = model.ManagerNationalIdBack;
            entity.State = model.State;
            entity.SubscriptionPlanId = model.SubscriptionPlanId;
            entity.MarketingPlanId = model.MarketingPlanId;
            entity.DiscountPlanId = model.DiscountPlanId;
            entity.ManagerFirstNameLocalized = model.ManagerFirstNameLocalized;
            entity.ManagerFirstName = model.ManagerFirstName;
            entity.ManagerLastNameLocalized = model.ManagerLastNameLocalized;
            entity.ManagerLastName = model.ManagerLastName;
            if (currentEntity == null)
            {
                entity.ModifiedDate = DateTime.Now;
                entity.ModifierName = AuthenticationHelper.GetUserName();
                logModel.LogType = (int)LogTypeEnum.Add;
                logModel.UserId = AuthenticationHelper.GetUserId();
                logModel.UserName = AuthenticationHelper.GetUserName();
                entity.StateCode = (int)StateEnum.Active;
                entity.State = StateEnum.Active.ToString();
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
            return new Pair<Vendor, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static VendorFullDataModel EntityToFullDataModel(Vendor? entity)
        {
            return new VendorFullDataModel
            {
                Id = entity?.Id ?? 0,
                UserId = entity?.UserID ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                Name = entity?.Name,
                NameLocalized = entity?.NameLocalized,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                Email = entity?.Email,
                Phone = entity?.Phone,
                Logo = entity?.Logo,
                Cover = entity?.Cover,
                ManagerNationalIdFront = entity?.ManagerNationalIdFront,
                ManagerNationalIdBack = entity?.ManagerNationalIdBack,
                State = entity?.State,
                SubscriptionPlanName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.SubscriptionPlan?.Name : entity?.SubscriptionPlan?.NameLocalized,
                SubscriptionPlanId = entity?.SubscriptionPlanId,
                MarketingPlanName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.MarketingPlan?.Name : entity?.MarketingPlan?.NameLocalized,
                MarketingPlanId = entity?.MarketingPlanId,
                DiscountPlanName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.DiscountPlan?.Name : entity?.DiscountPlan?.NameLocalized,
                DiscountPlanId = entity?.DiscountPlanId,
                ManagerFirstNameLocalized = entity?.ManagerFirstNameLocalized,
                ManagerFirstName = entity?.ManagerFirstName,
                ManagerLastNameLocalized = entity?.ManagerLastNameLocalized,
                ManagerLastName = entity?.ManagerLastName,
            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(Vendor? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(Vendor? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(Vendor? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? entity?.Name ?? "" : entity?.NameLocalized ?? ""; }
    }
}
