using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
using Staff_StaffProfileManagement.Models.StaffWorkSchedule;
using Staff_StaffProfileManagement.Entities;
namespace Staff_StaffProfileManagement.Mapping
{
    public static class StaffWorkScheduleMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<StaffWorkSchedule, LogModel> FullDataModelToEntity(this StaffWorkSchedule? entity, StaffWorkScheduleFullDataModel model)
        {
            LogModel logModel = new LogModel();
            StaffWorkSchedule? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new StaffWorkSchedule();
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
            entity.StaffId = model.StaffId;
            entity.WorkDay = model.WorkDay;
            entity.WorkStartTime = model.WorkStartTime;
            entity.WorkEndTime = model.WorkEndTime;
            entity.CoveredArea = model.CoveredArea;
            entity.Latitude = model.Latitude;
            entity.Longitude = model.Longitude;
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
            return new Pair<StaffWorkSchedule, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static StaffWorkScheduleFullDataModel EntityToFullDataModel(StaffWorkSchedule? entity)
        {
            return new StaffWorkScheduleFullDataModel
            {
                Id = entity?.Id ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                StaffId = entity?.StaffId,
                WorkDay = entity?.WorkDay,
                WorkStartTime = entity?.WorkStartTime,
                WorkEndTime = entity?.WorkEndTime,
                CoveredArea = entity?.CoveredArea,
                Latitude = entity?.Latitude,
                Longitude = entity?.Longitude
            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(StaffWorkSchedule? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(StaffWorkSchedule? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(StaffWorkSchedule? entity) { return AuthenticationHelper.GetLanuage() == 1 ? $"" : $""; }
    }
}
