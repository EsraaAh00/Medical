using Operation_FinanceManagement.Entities;
using Operation_FinanceManagement.Models.Transaction;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;

namespace Operation_FinanceManagement.Mapping
{
    public static class TransactionMapping
    {
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        public static Pair<Transaction, LogModel> FullDataModelToEntity(this Transaction? entity, TransactionFullDataModel model)
        {
            LogModel logModel = new LogModel();
            Transaction? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new Transaction();
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
            entity.ProviderId = model.ProviderId;
            entity.TransactionId = model.TransactionId;
            entity.TicketId = model.TicketId;
            entity.CaseId = model.CaseId;
            entity.DebitAmount = model.DebitAmount;
            entity.CreditAmount = model.CreditAmount;
            entity.TypeCode = model.TypeCode;
            entity.Type = model.Type;

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
            return new Pair<Transaction, LogModel>(entity, logModel);
        }

        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        public static TransactionFullDataModel EntityToFullDataModel(Transaction? entity)
        {
            return new TransactionFullDataModel
            {
                Id = entity?.Id ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                ClientId = entity?.ClientId ?? 0,
                ProviderId = entity?.ProviderId ?? 0,
                TicketId = entity?.TicketId,
                CaseId = entity?.CaseId,
                DebitAmount = entity?.DebitAmount,
                CreditAmount = entity?.CreditAmount,
                TypeCode = entity?.TypeCode,
                Type = entity?.Type,
            };
        }

        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        public static BaseDropDown EntityToDropDownModel(Transaction? entity)
        {
            return new BaseDropDown
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }

        // EntityToOuterIncludeModel Function Used For External Relationship To Map Entity To OuterIncludeModel
        public static OuterIncludeModel EntityToOuterIncludeModel(Transaction? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }

        private static string GetName(Transaction? entity)
        {
            return (AuthenticationHelper.GetLanuage() == 1) ? "" : "";
        }
    }
}
