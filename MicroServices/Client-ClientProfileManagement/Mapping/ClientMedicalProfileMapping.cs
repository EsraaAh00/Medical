﻿using Client_ClientProfileManagement.Entities;
using Client_ClientProfileManagement.Models.ClientMedicalProfile;
using JwtAuthenticationManager;
using Newtonsoft.Json;
using SharedModels.Models;

namespace Client_ClientProfileManagement.Mapping
{
    public static class ClientMedicalProfileMapping
    {
        //....
        // FullDataModelToEntity Function Map FullDataModel to Entity Used For Save And LogModel Data
        //....

        public static Pair<ClientMedicalProfile, LogModel> FullDataModelToEntity(this ClientMedicalProfile? entity, ClientMedicalProfileFullDataModel model)
        {
            LogModel logModel = new LogModel();
            ClientMedicalProfile? currentEntity = entity;
            string? currentEntityJsonString = null;
            if (entity == null)
            {
                entity = new ClientMedicalProfile();
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
            entity.MedicalConditions = model.MedicalConditions;
            entity.Allergies = model.Allergies;
            entity.CurrentMedications = model.CurrentMedications;
            entity.BloodType = model.BloodType;
            entity.OrganDonor = model.OrganDonor;
            entity.Smoker = model.Smoker;
            entity.Alcoholic = model.Alcoholic;
            entity.Active = model.Active;
            entity.MedicalNotes = model.MedicalNotes;

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
            return new Pair<ClientMedicalProfile, LogModel>(entity, logModel);
        }
        //....
        // EntityToFullDataModel Function Map Entity to FullDataModel Used For Select And GetById
        //....
        public static ClientMedicalProfileFullDataModel EntityToFullDataModel(ClientMedicalProfile? entity)
        {
            return new ClientMedicalProfileFullDataModel
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
                MedicalConditions = entity?.MedicalConditions,
                Allergies = entity?.Allergies,
                CurrentMedications = entity?.CurrentMedications,
                BloodType = entity?.BloodType,
                OrganDonor = entity?.OrganDonor,
                Smoker = entity?.Smoker,
                Alcoholic = entity?.Alcoholic,
                Active = entity?.Active,
                MedicalNotes = entity?.MedicalNotes
            };
        }
        //....
        // EntityToDropDownModel Function Map Entity to BaseDropDownModel Used For GetData as DropDownList
        //....
        public static BaseDropDown EntityToDropDownModel(ClientMedicalProfile? entity)
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
        public static OuterIncludeModel EntityToOuterIncludeModel(ClientMedicalProfile? entity)
        {
            return new OuterIncludeModel
            {
                Id = entity?.Id ?? 0,
                Name = GetName(entity)
            };
        }
        private static string GetName(ClientMedicalProfile? entity) { return AuthenticationHelper.GetLanuage() == 1 ? $"" : $""; }
    }
}
