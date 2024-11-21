using Client_ClientProfileManagement.Entities;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
using System.Numerics;
using Client_ClientProfileManagement.Models.Client;
namespace Client_ClientProfileManagement.Mapping
{
    public static class ClientMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<Client, LogModel> FullDataModelToEntity(this Client? entity, ClientFullDataModel model)
        {
            LogModel logModel = new LogModel();
            Client? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new Client();
            }
            else
            {
                currentEntityJsonString = JsonConvert.SerializeObject(entity);
            }
            entity.Id = model.Id;
            entity.UserId = model.UserId;
            entity.Name = model.Name;
            entity.NameLocalized = model.NameLocalized;
            entity.Email = model.Email;
            entity.Phone = model.Phone;
            entity.BirthDate = model.BirthDate;
            entity.ProfilePhoto = model.ProfilePhoto;
            entity.Password = model.Password;
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
            return new Pair<Client, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static ClientFullDataModel EntityToFullDataModel(Client? entity)
        {
            return new ClientFullDataModel
            {
                UserId = entity?.UserId ,
                Email  = entity?.Email ,
                Phone  = entity?.Phone ,
                Name = entity?.Name,
                NameLocalized = entity?.NameLocalized,
                BirthDate =  entity?.BirthDate ,
                ProfilePhoto = entity?.ProfilePhoto,
                Password = entity?.Password ,
                Id = entity?.Id ?? 0,
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
        public static BaseDropDown EntityToDropDownModel(Client? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(Client? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(Client? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? entity?.Name ?? "" : entity?.NameLocalized ?? ""; }
    }
}
