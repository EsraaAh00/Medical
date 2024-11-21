using Vendor_ProfileManagement.Models.BusinessTypeFeature;
using Vendor_ProfileManagement.Entities;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
namespace Vendor_ProfileManagement.Mapping
{
    public static class BusinessTypeFeatureMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<BusinessTypeFeature, LogModel> FullDataModelToEntity(this BusinessTypeFeature? entity, BusinessTypeFeatureFullDataModel model)
        {
            LogModel logModel = new LogModel();
            BusinessTypeFeature? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new BusinessTypeFeature();
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
            entity.BusinessTypeId = model.BusinessTypeId;
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
            return new Pair<BusinessTypeFeature, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static BusinessTypeFeatureFullDataModel EntityToFullDataModel(BusinessTypeFeature? entity)
        {
            return new BusinessTypeFeatureFullDataModel
            {
                Id = entity?.Id ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                BusinessTypeName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.BusinessType?.Name : entity?.BusinessType?.NameLocalized,
                BusinessTypeId = entity?.BusinessTypeId,
                FeatureName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.Feature?.Name : entity?.Feature?.NameLocalized,
                FeatureId = entity?.FeatureId,
            };
        }
        private static string GetName(BusinessTypeFeature? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? $"" : $""; }
    }
}
