using Vendor_ProfileManagement.Models.VendorRequest;
using Vendor_ProfileManagement.Entities;
using Vendor_ProfileManagement.Enums;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
namespace Vendor_ProfileManagement.Mapping
{
    public static class VendorRequestMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<VendorRequest, LogModel> FullDataModelToEntity(this VendorRequest? entity, VendorRequestFullDataModel model)
        {
            LogModel logModel = new LogModel();
            VendorRequest? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new VendorRequest();
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
            entity.Email = model.Email;
            entity.Phone = model.Phone;
            entity.Password = model.Password;
            entity.Logo = model.Logo;
            entity.Cover = model.Cover;
            entity.ManagerNationalIdFront = model.ManagerNationalIdFront;
            entity.ManagerNationalIdBack = model.ManagerNationalIdBack;
            entity.BusinessLandLine = model.BusinessLandLine;
            entity.BusinessLogo = model.BusinessLogo;
            entity.BusinessCover = model.BusinessCover;
            entity.CommercialRecord = model.CommercialRecord;
            entity.TaxCard = model.TaxCard;
            entity.ValueAddedCard = model.ValueAddedCard;
            entity.License = model.License;
            entity.PropertyContract = model.PropertyContract;
            entity.PerformancePermission = model.PerformancePermission;
            entity.RequestStatus = model.RequestStatus;
            //entity.RejectionReasonCode = model.RejectionReasonCode;
            entity.RejectionReason = Enum.GetName(typeof(RejectionReasonEnum), model.RejectionReasonCode);
            entity.RejectionFields = model.RejectionFields;
            entity.BusinessTypeCategoryId = model.BusinessTypeCategoryId;
            entity.ManagerFirstNameLocalized = model.ManagerFirstNameLocalized;
            entity.ManagerFirstName = model.ManagerFirstName;
            entity.ManagerLastNameLocalized = model.ManagerLastNameLocalized;
            entity.ManagerLastName = model.ManagerLastName;
            entity.BusinessNameLocalized = model.BusinessNameLocalized;
            entity.BusinessName = model.BusinessName;
            entity.RegionId = model.RegionId;
            entity.Lat= model.Lat;
            entity.Lng= model.Lng;
            entity.Address = model.Address;
            entity.AddressLocalized= model.AddressLocalized;
            entity.LandScreen = model.LandScreen;
            if (currentEntity == null)
            {
                entity.ModifiedDate = DateTime.Now;
                entity.ModifierName = AuthenticationHelper.GetUserName();
                logModel.LogType = (int)LogTypeEnum.Add;
                logModel.UserId = AuthenticationHelper.GetUserId();
                logModel.UserName = AuthenticationHelper.GetUserName();
                entity.RequestStatusCode = (int)RequestStatusEnum.New;
                entity.RequestStatus = RequestStatusEnum.New.ToString();
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
            return new Pair<VendorRequest, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static VendorRequestFullDataModel EntityToFullDataModel(VendorRequest? entity)
        {
            return new VendorRequestFullDataModel
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
                Email = entity?.Email,
                Phone = entity?.Phone,
                Password = entity?.Password,
                Logo = entity?.Logo,
                Cover = entity?.Cover,
                ManagerNationalIdFront = entity?.ManagerNationalIdFront,
                ManagerNationalIdBack = entity?.ManagerNationalIdBack,
                BusinessLandLine = entity?.BusinessLandLine,
                BusinessLogo = entity?.BusinessLogo,
                BusinessCover = entity?.BusinessCover,
                CommercialRecord = entity?.CommercialRecord,
                TaxCard = entity?.TaxCard,
                ValueAddedCard = entity?.ValueAddedCard,
                License = entity?.License,
                PropertyContract = entity?.PropertyContract,
                PerformancePermission = entity?.PerformancePermission,
                RequestStatus = entity?.RequestStatus,
                RejectionReason = entity?.RejectionReason,
                RejectionFields = entity?.RejectionFields,
                BusinessTypeCategoryName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.BusinessTypeCategory?.Name : entity?.BusinessTypeCategory?.NameLocalized,
                BusinessTypeCategoryId = entity?.BusinessTypeCategoryId,
                ManagerFirstNameLocalized = entity?.ManagerFirstNameLocalized,
                ManagerFirstName = entity?.ManagerFirstName,
                ManagerLastNameLocalized = entity?.ManagerLastNameLocalized,
                ManagerLastName = entity?.ManagerLastName,
                BusinessNameLocalized = entity?.BusinessNameLocalized,
                BusinessName = entity?.BusinessName,
                Address= entity?.Address,
                AddressLocalized = entity?.AddressLocalized,
                Lat = entity?.Lat,
                Lng = entity?.Lng,
                RegionId = entity?.RegionId,
                LandScreen = entity?.LandScreen                
            };
        }

        public static VendorAccountDataModel FullDataModelToVendorAccountDataModel(this VendorRequestFullDataModel model)
        {
            VendorAccountDataModel? VendorAccountDataModel =new VendorAccountDataModel { 
            Cover=model.Cover,
            ManagerFirstName= model.ManagerFirstName,
            ManagerFirstNameLocalized = model.ManagerFirstNameLocalized,
            ManagerLastNameLocalized = model.ManagerLastNameLocalized,
            ManagerLastName = model.ManagerLastName,
            ManagerNationalIdBack= model.ManagerNationalIdBack,
            ManagerNationalIdBackFile=   model.ManagerNationalIdBackFile,
            ManagerNationalIdFront  = model.ManagerNationalIdFront,
            ManagerNationalIdFrontFile = model.ManagerNationalIdFrontFile,
            CoverFile=model.CoverFile,
            Email=model.Email,
            Logo= model.Logo,
            Name= model.Name,
            LogoFile= model.LogoFile,
            NameLocalized  = model.NameLocalized,
            Phone = model.Phone,
            Password= model.Password,
            
            };
            
            return VendorAccountDataModel;
        }
        public static BusinessIdentifiactionModel FullDataModelToBusinessIdentifiactionModel(this VendorRequestFullDataModel model)
        {
            BusinessIdentifiactionModel? DataModel =new BusinessIdentifiactionModel
            {
                BusinessNameLocalized=model.BusinessNameLocalized ,
                BusinessName=model.BusinessName ,
                BusinessTypeCategoryId=model.BusinessTypeCategoryId ,
                BusinessCover=model.BusinessCover ,
                BusinessLogo=model.BusinessLogo ,
                BusinessLandLine = model.BusinessLandLine,
                BusinessCoverFile= model.BusinessCoverFile,
                BusinessLogoFile = model.BusinessLogoFile,
                
                
                
                
            
            
            };
            
            return DataModel;
        } 
        public static VendorRequestDocumentationModel FullDataModelToVendorRequestDocumentationModel(this VendorRequestFullDataModel model)
        {
            VendorRequestDocumentationModel? DataModel =new VendorRequestDocumentationModel
            {
                CommercialRecordFile=model.CommercialRecordFile,
                LicenseFile=model.LicenseFile,
                PerformancePermissionFile=model.PerformancePermissionFile,
                PropertyContractFile=model.PropertyContractFile,
                TaxCardFile=model.TaxCardFile,
                ValueAddedCardFile=model.ValueAddedCardFile,
                CommercialRecord= model.CommercialRecord,
                License=model.License,
                PerformancePermission= model.PerformancePermission  ,
                PropertyContract= model.PropertyContract,
                TaxCard= model.TaxCard,
                ValueAddedCard= model.ValueAddedCard,
                
                
            
            
            };
            
            return DataModel;
        }

        public static VendorBusinessLocationModel FullDataModelToVendorBusinessLocationModel(this VendorRequestFullDataModel model)
        {
            VendorBusinessLocationModel? DataModel = new VendorBusinessLocationModel
            {
                Lat = model.Lat,
                Lng = model.Lng,
                Address = model.Address,
                AddressLocalized = model.AddressLocalized,
                RegionId = model.RegionId,
               
                


            };

            return DataModel;
        }


        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(VendorRequest? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(VendorRequest? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(VendorRequest? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? entity?.Name ?? "" : entity?.NameLocalized ?? ""; }
    }
}
