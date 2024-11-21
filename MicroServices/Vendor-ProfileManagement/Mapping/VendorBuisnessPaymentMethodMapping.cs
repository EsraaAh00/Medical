using Vendor_ProfileManagement.Models.VendorBusinessPaymentMethod;
using Vendor_ProfileManagement.Entities;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
namespace Vendor_ProfileManagement.Mapping
{
    public static class VendorBusinessPaymentMethodMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<VendorBusinessPaymentMethod, LogModel> FullDataModelToEntity(this VendorBusinessPaymentMethod? entity, VendorBusinessPaymentMethodFullDataModel model)
        {
            LogModel logModel = new LogModel();
            VendorBusinessPaymentMethod? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new VendorBusinessPaymentMethod();
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
            entity.VendorBusinessId = model.VendorBusinessId;
            entity.PaymentMethodId = model.PaymentMethodId;
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
            return new Pair<VendorBusinessPaymentMethod, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static VendorBusinessPaymentMethodFullDataModel EntityToFullDataModel(VendorBusinessPaymentMethod? entity)
        {
            return new VendorBusinessPaymentMethodFullDataModel
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
                VendorBusinessName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.VendorBusiness?.Name : entity?.VendorBusiness?.NameLocalized,
                VendorBusinessId = entity?.VendorBusinessId,
                PaymentMethodName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.PaymentMethod?.Name : entity?.PaymentMethod?.NameLocalized,
                PaymentMethodId = entity?.PaymentMethodId,
            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(VendorBusinessPaymentMethod? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(VendorBusinessPaymentMethod? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(VendorBusinessPaymentMethod? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? entity?.Name ?? "" : entity?.NameLocalized ?? ""; }
    }
}