﻿using JwtAuthenticationManager;
using Newtonsoft.Json;
using Shared_GeneralSharedData.Entities;
using Shared_GeneralSharedData.Enums;
using Shared_GeneralSharedData.Models.Degree;
using SharedModels.Models;

namespace Shared_GeneralSharedData.Mapping
{
    public static class DegreeMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....
        public static Pair<Degree, LogModel> FullDataModelToEntity(this Degree? entity, DegreeFullDataModel model)
        {
            LogModel logModel = new LogModel();
            Degree? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new Degree();
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
            entity.Active = model.Active;
            entity.ActiveCode = model.ActiveCode;
            if (currentEntity == null)
            {
                entity.ModifiedDate = DateTime.Now;
                entity.ModifierName = AuthenticationHelper.GetUserName();
                logModel.LogType = (int)LogTypeEnum.Add;
                logModel.UserId = AuthenticationHelper.GetUserId();
                logModel.UserName = AuthenticationHelper.GetUserName();
                entity.ActiveCode = (int)ActiveEnum.Active;
                entity.Active = ActiveEnum.Active.ToString();
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
            return new Pair<Degree, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static DegreeFullDataModel EntityToFullDataModel(Degree? entity)
        {
            return new DegreeFullDataModel
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
                Active = entity?.Active,
                ActiveCode = entity?.ActiveCode
            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(Degree? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(Degree? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(Degree? entity) { return (AuthenticationHelper.GetLanuage() == 1) ? entity?.Name ?? "" : entity?.NameLocalized ?? ""; }
    }
}