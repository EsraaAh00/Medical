using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
using Client_ClientRelationMangement.Models.Complaint;
using Client_ClientRelationMangement.Entities;

namespace Client_ClientRelationMangement.Mapping
{
    public static class ComplaintMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....

        public static Pair<Complaint, LogModel> FullDataModelToEntity(this Complaint? entity, ComplaintFullDataModel model)
        {
            LogModel logModel = new LogModel();
            Complaint? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new Complaint();
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
            entity.ClientId = model.ClientId;
            entity.VendorBuissnesId = model.VendorBuissnesId;
            entity.OrderId = model.OrderId;
            entity.TicketId = model.TicketId;
            entity.HandledBy = model.HandledBy;
            entity.ComplaintTypeCode = model.ComplaintTypeCode;
            entity.ComplaintTypeCodeId = model.ComplaintTypeCodeId;
            entity.ComplaintDescription = model.ComplaintDescription;
            entity.ComplaintDescriptionLocalized = model.ComplaintDescriptionLocalized;
            entity.Resolved = model.Resolved;
            entity.IssuedIn = model.IssuedIn;
            entity.ClosedIn = model.ClosedIn;
            entity.StatusCodeId = model.StatusCodeId;
            entity.StatusCode = model.StatusCode;
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
            return new Pair<Complaint, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static ComplaintFullDataModel EntityToFullDataModel(Complaint? entity)
        {
            return new ComplaintFullDataModel
            {
                Id = entity?.Id ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                ClientId = entity?.ClientId,
                VendorBuissnesId = entity?.VendorBuissnesId,
                OrderId = entity?.OrderId,
                TicketId = entity?.TicketId,
                HandledBy = entity?.HandledBy,
                ComplaintTypeCode = entity?.ComplaintTypeCode,
                ComplaintTypeCodeId = entity?.ComplaintTypeCodeId,
                ComplaintDescription = entity?.ComplaintDescription,
                ComplaintDescriptionLocalized = entity?.ComplaintDescriptionLocalized,
                Resolved = entity?.Resolved,
                IssuedIn = entity?.IssuedIn,
                ClosedIn = entity?.ClosedIn,
                StatusCodeId = entity?.StatusCodeId,
                StatusCode = entity?.StatusCode,

            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(Complaint? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(Complaint? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(Complaint? entity) { return AuthenticationHelper.GetLanuage() == 1 ? entity?.Name ?? "" : entity?.NameLocalized ?? ""; }
    }
}
