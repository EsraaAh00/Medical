using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
using Facility_FacilityProfileManagement.Models.FacilityListing;
using Facility_FacilityProfileManagement.Entities;
namespace Facility_FacilityProfileManagement.Mapping
{
    public static class FacilityListingMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<FacilityListing, LogModel> FullDataModelToEntity(this FacilityListing? entity, FacilityListingFullDataModel model)
        {
            LogModel logModel = new LogModel();
            FacilityListing? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new FacilityListing();
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
            entity.FacilityId = model.FacilityId;
            entity.Speciality = model.Speciality;
            entity.OfflineFair = model.OfflineFair;
            entity.OnlineFair = model.OnlineFair;
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
            return new Pair<FacilityListing, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static FacilityListingFullDataModel EntityToFullDataModel(FacilityListing? entity)
        {
            return new FacilityListingFullDataModel
            {
                Id = entity?.Id ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                Name = entity?.Name ?? string.Empty,
                NameLocalized = entity?.NameLocalized ?? string.Empty,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                FacilityId = entity?.FacilityId ?? 0 ,
                Speciality = entity?.Speciality ?? string.Empty,
                OfflineFair = entity?.OfflineFair ?? 0.0,
                OnlineFair = entity?.OnlineFair ?? 0.0
            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(FacilityListing? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(FacilityListing? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(FacilityListing? entity) { return AuthenticationHelper.GetLanuage() == 1 ? entity?.Name ?? "" : entity?.NameLocalized ?? ""; }
    }
}
