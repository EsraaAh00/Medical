using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
using Staff_StaffProfileManagement.Models.Staff;
using Staff_StaffProfileManagement.Entities;
using Staff_StaffProfileManagement.Enums;
namespace Staff_StaffProfileManagement.Mapping
{
    public static class StaffMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<Staff, LogModel> FullDataModelToEntity(this Staff? entity, StaffFullDataModel model)
        {
            LogModel logModel = new LogModel();
            Staff? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new Staff();
            }
            else
            {
                currentEntityJsonString = JsonConvert.SerializeObject(entity);
            }
            entity.UserId = model.UserId;
            entity.Email = model.Email;
            entity.Phone = model.Phone;
            entity.Name = model.Name;
            entity.NameLocalized = model.NameLocalized;
            entity.Password = model.Password;
            entity.Logo = model.Logo;
            entity.Gender = model.Gender;
            entity.Nationality = model.Nationality;
            entity.NationalId = model.NationalId;
            entity.About = model.About;
            entity.AboutLocalized = model.AboutLocalized;
            entity.MedicallicenseNumber = model.MedicallicenseNumber;
            entity.MedicallicenseAttachment = model.MedicallicenseAttachment;
            entity.MedicallicenseExpiryDate = model.MedicallicenseExpiryDate;
            entity.SatffType = model.SatffType;
            entity.Speciality = model.Speciality;
            entity.Classification = model.Classification;
            entity.SubSpeciality = model.SubSpeciality;
            entity.Degree = model.Degree;
            entity.OfflineSessionFair = model.OfflineSessionFair;
            entity.OnlineSessionFair = model.OnlineSessionFair;
            entity.State = model.State;
            entity.StateCode = model.StateCode;
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
            return new Pair<Staff, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static StaffFullDataModel EntityToFullDataModel(Staff? entity)
        {
            return new StaffFullDataModel
            {
                Id = entity?.Id ?? 0,
                UserId = entity?.UserId ?? 0,
                Email = entity?.Email ?? string.Empty,
                Phone = entity?.Phone ?? string.Empty,
                Name = entity?.Name ?? string.Empty,
                NameLocalized = entity?.NameLocalized ?? string.Empty,
                Password = entity?.Password ?? string.Empty,
                Logo = entity?.Logo ?? string.Empty,
                Gender = entity?.Gender ?? string.Empty,
                Nationality = entity?.Nationality ?? string.Empty,
                NationalId = entity?.NationalId ?? string.Empty,
                About = entity?.About ?? string.Empty,
                AboutLocalized = entity?.AboutLocalized ?? string.Empty,
                MedicallicenseNumber = entity?.MedicallicenseNumber ?? string.Empty,
                MedicallicenseAttachment = entity?.MedicallicenseAttachment ?? string.Empty,
                MedicallicenseExpiryDate = entity?.MedicallicenseExpiryDate ?? default,
                SatffType = entity?.SatffType ?? string.Empty,
                Speciality = entity?.Speciality ?? string.Empty,
                Classification = entity?.Classification ?? string.Empty,
                SubSpeciality = entity?.SubSpeciality ?? string.Empty,
                Degree = entity?.Degree ?? string.Empty,
                OfflineSessionFair = entity?.OfflineSessionFair ?? 0.0,
                OnlineSessionFair = entity?.OnlineSessionFair ?? 0.0,
                State = entity?.State ?? string.Empty,
                StateCode = entity?.StateCode ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName
            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(Staff? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(Staff? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(Staff? entity) { return AuthenticationHelper.GetLanuage() == 1 ? entity?.Name ?? "" : entity?.NameLocalized ?? ""; }
    }
}
