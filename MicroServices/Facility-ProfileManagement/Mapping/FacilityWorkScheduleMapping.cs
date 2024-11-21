using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
using Facility_FacilityProfileManagement.Models.FacilityWorkSchedule;
using Facility_FacilityProfileManagement.Entities;
namespace Facility_FacilityProfileManagement.Mapping
{
    public static class FacilityWorkScheduleMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<FacilityWorkSchedule, LogModel> FullDataModelToEntity(this FacilityWorkSchedule? entity, FacilityWorkScheduleFullDataModel model)
        {
            LogModel logModel = new LogModel();
            FacilityWorkSchedule? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new FacilityWorkSchedule();
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
            entity.FacilityId = model.FacilityId;
            entity.WorkDay = model.WorkDay;
            entity.WorkStartTime = model.WorkStartTime;
            entity.WorkEndTime = model.WorkEndTime;
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
            return new Pair<FacilityWorkSchedule, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static FacilityWorkScheduleFullDataModel EntityToFullDataModel(FacilityWorkSchedule? entity)
        {
            return new FacilityWorkScheduleFullDataModel
            {
                Id = entity?.Id ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                FacilityId = entity?.FacilityId ?? 0,
                WorkDay = entity?.WorkDay ?? string.Empty,
                WorkStartTime = entity?.WorkStartTime ?? string.Empty,
                WorkEndTime = entity?.WorkEndTime ?? string.Empty,
            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(FacilityWorkSchedule? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(FacilityWorkSchedule? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(FacilityWorkSchedule? entity) { return AuthenticationHelper.GetLanuage() == 1 ? $"" : $""; }
    }
}
