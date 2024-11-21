using Vendor_ProfileManagement.Models.VendorBusinessFeature;
using Vendor_ProfileManagement.Entities;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
namespace Vendor_ProfileManagement.Mapping
{
    public static class VendorBusinessFeatureMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<VendorBusinessFeature, LogModel> FullDataModelToEntity(this VendorBusinessFeature? entity, VendorBusinessFeatureFullDataModel model)
        {
            LogModel logModel = new LogModel();
            VendorBusinessFeature? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new VendorBusinessFeature();
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
            entity.VendorBusinessId = model.VendorBusinessId;
            entity.FeatureId = model.FeatureId;
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
            return new Pair<VendorBusinessFeature, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static VendorBusinessFeatureFullDataModel EntityToFullDataModel(VendorBusinessFeature? entity)
        {
            return new VendorBusinessFeatureFullDataModel
            {
                Id = entity?.Id ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                VendorBusinessName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.VendorBusiness?.Name : entity?.VendorBusiness?.NameLocalized,
                VendorBusinessId = entity?.VendorBusinessId,
                FeatureName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.Feature?.Name : entity?.Feature?.NameLocalized,
                FeatureId = entity?.FeatureId,
            };
        }
        private static string GetName(VendorBusinessFeature? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? $"" : $""; }
    }
}
