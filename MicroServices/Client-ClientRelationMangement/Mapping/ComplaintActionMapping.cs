﻿using Newtonsoft.Json;
using SharedModels.Models;
using JwtAuthenticationManager;
using Client_ClientRelationMangement.Models.ComplaintAction;
using Client_ClientRelationMangement.Entities;

namespace Client_ClientRelationMangement.Mapping
{
    public static class ComplaintActionMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....

        public static Pair<ComplaintAction, LogModel> FullDataModelToEntity(this ComplaintAction? entity, ComplaintActionFullDataModel model)
        {
            LogModel logModel = new LogModel();
            ComplaintAction? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new ComplaintAction();
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
            entity.ComplaintId = model.ComplaintId;
            entity.ActionId = model.ActionId;
            entity.Action = model.Action;
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
            return new Pair<ComplaintAction, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static ComplaintActionFullDataModel EntityToFullDataModel(ComplaintAction? entity)
        {
            return new ComplaintActionFullDataModel
            {
                Id = entity?.Id ?? 0,
                DeletedDate = entity?.DeletedDate,
                DeleterName = entity?.DeleterName,
                IsDeleted = entity?.IsDeleted,
                ModifiedDate = entity?.ModifiedDate,
                ModifierName = entity?.ModifierName,
                UpdateDate = entity?.UpdateDate,
                UpdaterName = entity?.UpdaterName,
                ComplaintId = entity?.ComplaintId,
                Action = entity?.Action,
                ActionId = entity?.ActionId,
            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(ComplaintAction? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(ComplaintAction? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(ComplaintAction? entity) { return AuthenticationHelper.GetLanuage() == 1 ? $"" : $""; }
    }
}