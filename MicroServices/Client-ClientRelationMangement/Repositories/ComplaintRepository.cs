﻿using SharedModels.BaseRepository;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models.Filter;
using SharedModels.Models;
using SharedModels.Helpers;
using Client_ClientRelationMangement.Models.Complaint;
using Client_ClientRelationMangement.Context;
using Client_ClientRelationMangement.Entities;
using Client_ClientRelationMangement.Interfaces.Repositories;
using Client_ClientRelationMangement.Entities.Logger;
using Client_ClientRelationMangement.Mapping;

namespace Client_ClientRelationMangement.Repositories
{
    public class ComplaintRepository : BaseRespository<Complaint, ComplaintLogger, ClientRelationMangementContext>, IComplaintRepository
    {
        private readonly DbSet<Complaint> _Set;

        public ComplaintRepository(ClientRelationMangementContext context) : base(context, context.Complaint)
        {
            _Set = context.Complaint;
        }

        #region CURD
        public async Task<ComplaintFullDataModel?> GetById(int? id)
        {
            Complaint? entity = await GetEntityById(id);
            return ComplaintMapping.EntityToFullDataModel(entity);
        }


        public async Task<BaseResponse?> Save(ComplaintFullDataModel model)
        {
            Complaint? enitity = await GetEntityByIdWithTracking(model.Id);
            var entityWithLog = enitity.FullDataModelToEntity(model);
            return await SaveAsync(entityWithLog);
        }

        public async Task<PagedList<ComplaintFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            var query = _Set.AsNoTracking().AsQueryable();
            var pagedList = await PagedList<ComplaintFullDataModel?>.ToPagedList(query.Select(s => ComplaintMapping.EntityToFullDataModel(s)), filter.Page, filter.PageSize);
            return pagedList;
        }
        #endregion

        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await UndoEntity(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            List<LogModel?>? logger = await GetEntityLogByRecordIdOrTranactionsId(recordId, null);
            return logger;
        }
        #endregion

    }
}
