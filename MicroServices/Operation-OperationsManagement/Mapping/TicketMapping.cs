using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
using Operation_OperationsManagement.Entities;
using Operation_OperationsManagement.Models.Ticket;

namespace Vendor_ListingManagement.Mapping
{
    public static class TicketMapping
    {
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        public static Pair<Ticket, LogModel> FullDataModelToEntity(this Ticket? entity, TicketFullDataModel model)
        {
            LogModel logModel = new LogModel();
            Ticket? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new Ticket();
            }
            else
            {
                currentEntityJsonString = JsonConvert.SerializeObject(entity);
            }
            entity.ClientId = model.ClientId;
            entity.ClientName = model.ClientName;
            entity.ClientNameLocalized = model.ClientNameLocalized;
            entity.ServiceProviderId = model.ServiceProviderId;
            entity.ServiceProviderName = model.ServiceProviderName;
            entity.ServiceProviderNameLocalized = model.ServiceProviderNameLocalized;
            entity.ServiceName = model.ServiceName;
            entity.ServiceNameLocalized = model.ServiceNameLocalized;
            entity.MeetingEnviroment = model.MeetingEnviroment;
            entity.ProviderFair = model.ProviderFair;
            entity.SubTotal = model.SubTotal;
            entity.Tax = model.Tax;
            entity.SystemFair = model.SystemFair;
            entity.NetTotal = model.NetTotal;
            entity.FromTime = model.FromTime;
            entity.ToTime = model.ToTime;
            entity.TransactionId = model.TransactionId;
            entity.StatusCode = model.StatusCode;
            entity.StatusCodeId = model.StatusCodeId;
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
            return new Pair<Ticket, LogModel>(entity, logModel);
        }

        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        public static TicketFullDataModel EntityToFullDataModel(Ticket? entity)
        {
            return new TicketFullDataModel
            {
                Id = entity?.Id ?? 0,
                ClientId = entity?.ClientId ?? 0,
                ClientName = entity?.ClientName ?? string.Empty,
                ClientNameLocalized = entity?.ClientNameLocalized ?? string.Empty,
                ServiceProviderId = entity?.ServiceProviderId ?? 0,
                ServiceProviderName = entity?.ServiceProviderName ?? string.Empty,
                ServiceProviderNameLocalized = entity?.ServiceProviderNameLocalized ?? string.Empty,
                ServiceName = entity?.ServiceName ?? string.Empty,
                ServiceNameLocalized = entity?.ServiceNameLocalized ?? string.Empty,
                MeetingEnviroment = entity?.MeetingEnviroment ?? string.Empty,
                ProviderFair = entity?.ProviderFair ?? 0.0,
                SubTotal = entity?.SubTotal ?? 0.0,
                Tax = entity?.Tax ?? 0.0,
                SystemFair = entity?.SystemFair ?? 0.0,
                NetTotal = entity?.NetTotal ?? 0.0,
                FromTime = entity?.FromTime,
                ToTime = entity?.ToTime,
                TransactionId = entity?.TransactionId ?? 0,
                StatusCode = entity?.StatusCode ?? string.Empty,
                StatusCodeId = entity?.StatusCodeId ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName ?? string.Empty,
                IsDeleted = entity?.IsDeleted ?? false,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName ?? string.Empty,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName ?? string.Empty
            };
        }

        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(Ticket? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(Ticket? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(Ticket? entity) { return AuthenticationHelper.GetLanuage() == 1 ? $"" : $""; }
    }
}
