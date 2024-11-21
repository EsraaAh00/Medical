using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
using Facility_FacilityProfileManagement.Models.FacilityRequest;
using Facility_FacilityProfileManagement.Entities;
namespace Facility_FacilityProfileManagement.Mapping
{
    public static class FacilityRequestMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<FacilityRequest, LogModel> FullDataModelToEntity(this FacilityRequest? entity, FacilityRequestFullDataModel model)
        {
            LogModel logModel = new LogModel();
            FacilityRequest? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new FacilityRequest();
            }
            else
            {
                currentEntityJsonString = JsonConvert.SerializeObject(entity);
            }
            entity.Email = model.Email;
            entity.Phone = model.Phone;
            entity.Password = model.Password;
            entity.Name = model.Name;
            entity.NameLocalized = model.NameLocalized;
            entity.Logo = model.Logo;
            entity.About = model.About;
            entity.AboutLocalized = model.AboutLocalized;
            entity.LandLine = model.LandLine;
            entity.Address = model.Address;
            entity.AddressLocalized = model.AddressLocalized;
            entity.FacilityType = model.FacilityType;
            entity.CommercialRecordNumber = model.CommercialRecordNumber;
            entity.CommercialRecordAttachment = model.CommercialRecordAttachment;
            entity.MinistryOfHealthlicenseNumber = model.MinistryOfHealthlicenseNumber;
            entity.MinistryOfHealthlicenseAttachment = model.MinistryOfHealthlicenseAttachment;
            entity.CountryId = model.CountryId;
            entity.Country = model.Country;
            entity.CoveredArea = model.CoveredArea;
            entity.Latitude = model.Latitude;
            entity.Longitude = model.Longitude;
            entity.FacilityType = model.FacilityType;
            entity.RequestStatus = model.RequestStatus;
            entity.RequestStatusCode = model.RequestStatusCode;
            entity.RejectionReason = model.RejectionReason;

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
            return new Pair<FacilityRequest, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static FacilityRequestFullDataModel EntityToFullDataModel(FacilityRequest? entity)
        {
            return new FacilityRequestFullDataModel
            {
                Id = entity?.Id ?? 0,
                Email = entity?.Email ?? string.Empty,
                Phone = entity?.Phone ?? string.Empty,
                Password = entity?.Password ?? string.Empty,
                Logo = entity?.Logo ?? string.Empty,
                Name = entity?.Name ?? string.Empty,
                NameLocalized = entity?.NameLocalized ?? string.Empty,
                LandLine = entity?.LandLine ?? string.Empty,
                Address = entity?.Address ?? string.Empty,
                AddressLocalized = entity?.AddressLocalized ?? string.Empty,
                About = entity?.About ?? string.Empty,
                AboutLocalized = entity?.AboutLocalized ?? string.Empty,
                FacilityType = entity?.FacilityType ?? string.Empty,
                CommercialRecordNumber = entity?.CommercialRecordNumber ?? string.Empty,
                CommercialRecordAttachment = entity?.CommercialRecordAttachment ?? string.Empty,
                MinistryOfHealthlicenseNumber = entity?.MinistryOfHealthlicenseNumber ?? string.Empty,
                MinistryOfHealthlicenseAttachment = entity?.MinistryOfHealthlicenseAttachment ?? string.Empty,
                CountryId = entity?.CountryId ?? 0,
                Country = entity?.Country ?? string.Empty,
                CoveredArea = entity?.CoveredArea ?? 0.0,
                Latitude = entity?.Latitude ?? 0.0,
                Longitude = entity?.Longitude ?? 0.0,
                RequestStatus = entity?.RequestStatus ?? string.Empty,
                RequestStatusCode = entity?.RequestStatusCode ?? 0,
                RejectionReason = entity?.RejectionReason ?? string.Empty,
            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(FacilityRequest? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(FacilityRequest? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(FacilityRequest? entity) { return AuthenticationHelper.GetLanuage() == 1 ? entity?.Name ?? "" : entity?.NameLocalized ?? ""; }
    }
}
