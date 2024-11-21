using System_Authentication.Models.User;
using System_Authentication.Entities;
using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
namespace System_Authentication.Mapping
{
    public static class UserMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<User, LogModel> FullDataModelToEntity(this User? entity, UserFullDataModel model)
        {
            LogModel logModel = new LogModel();
            User? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new User();
            }
            else
            {
                currentEntityJsonString = JsonConvert.SerializeObject(entity);
            }
            entity.Id = model.Id;

            entity.Name = model.Name;
            entity.IsDeleted = model.IsDeleted;
            entity.DeleterName = model.DeleterName;
            entity.DeletedDate = model.DeletedDate;
            entity.UpdaterName = model.UpdaterName;
            entity.UpdateDate = model.UpdateDate;
            entity.ModifierName = model.ModifierName;
            entity.ModifiedDate = model.ModifiedDate;
            entity.UserRankId = model.UserRankId;
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
            return new Pair<User, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static UserFullDataModel EntityToFullDataModel(User? entity)
        {
            return new UserFullDataModel
            {
                Id = entity?.Id ?? 0,

                Name = entity?.Name,
                IsDeleted = entity?.IsDeleted,
                DeleterName = entity?.DeleterName,
                DeletedDate = entity?.DeletedDate,
                UpdaterName = entity?.UpdaterName,
                UpdateDate = entity?.UpdateDate,
                ModifierName = entity?.ModifierName,
                ModifiedDate = entity?.ModifiedDate,
                UserRankId = entity?.UserRankId,
                UserRank = (AuthenticationHelper.GetLanuage() == 1)?entity?.UserRank?.Name: entity?.UserRank?.NameLocalized,
                PhoneNumber= entity?.PhoneNumber,
                Email= entity?.Email,
                UserName= entity?.UserName,
            };
        }
        public static UserDataList EntityToListModel(User? entity)
        {
            return new UserDataList
            {
                Id = entity?.Id ?? 0,
                Name = entity?.Name,
                Email = entity?.Email,
                PhoneNumber = entity?.PhoneNumber,
                UserName = entity?.UserName,
                UserRankId = entity?.UserRankId,
                UserRank = entity?.UserRank?.BaseName
            };
        }
    }
}
