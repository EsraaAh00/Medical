using Vendor_ProfileManagement.Models.VendorBusinessPolicy;
using Vendor_ProfileManagement.Entities;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
namespace Vendor_ProfileManagement.Mapping
{
    public static class VendorBusinessPolicyMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<VendorBusinessPolicy, LogModel> FullDataModelToEntity(this VendorBusinessPolicy? entity, VendorBusinessPolicyFullDataModel model)
        {
            LogModel logModel = new LogModel();
            VendorBusinessPolicy? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new VendorBusinessPolicy();
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
            entity.TotalGuestCount = model.TotalGuestCount;
            entity.AcceptedGuestType = model.AcceptedGuestType;
            entity.MinGuestAge = model.MinGuestAge;
            entity.NoShowPenalty = model.NoShowPenalty;
            entity.PetsAllowedFee = model.PetsAllowedFee;
            entity.PetsAllowed = model.PetsAllowed;
            entity.CancelPolicy = model.CancelPolicy;
            entity.Policy = model.Policy;
            entity.CheckOut = model.CheckOut;
            entity.CheckIn = model.CheckIn;
            entity.VendorBusinessId = model.VendorBusinessId;
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
            return new Pair<VendorBusinessPolicy, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static VendorBusinessPolicyFullDataModel EntityToFullDataModel(VendorBusinessPolicy? entity)
        {
            return new VendorBusinessPolicyFullDataModel
            {
                Id = entity?.Id ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                TotalGuestCount = entity?.TotalGuestCount,
                AcceptedGuestType = entity?.AcceptedGuestType,
                MinGuestAge = entity?.MinGuestAge,
                NoShowPenalty = entity?.NoShowPenalty,
                PetsAllowedFee = entity?.PetsAllowedFee,
                PetsAllowed = entity?.PetsAllowed,
                CancelPolicy = entity?.CancelPolicy,
                Policy = entity?.Policy,
                CheckOut = entity?.CheckOut,
                CheckIn = entity?.CheckIn,
                VendorBusinessName = (AuthenticationHelper.GetLanuage() == 1) ? entity?.VendorBusiness?.Name : entity?.VendorBusiness?.NameLocalized,
                VendorBusinessId = entity?.VendorBusinessId,
            };
        }
        private static string GetName(VendorBusinessPolicy? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? $"" : $""; }
    }
}
