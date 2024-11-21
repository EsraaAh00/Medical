using SharedModels.Models;
using SharedModels.Helpers;
using System_Authentication.Interfaces.Services;
using System_Authentication.Interfaces.Repositories;
using System_Authentication.Models;
using System_Authentication.Models.Rank;
using SharedModels.Models.Filter;
using System_Authentication.Validation;
namespace System_Authentication.Services
{
    public class RankService : IRankService
    {
        private readonly IRankRepository _RankRepository;
        public RankService(IRankRepository RankRepository)
        {
            _RankRepository = RankRepository;
        }
        #region CURD
        public async Task<RankFullDataModel?> GetById(int? id)
        {
            return await _RankRepository.GetById(id);
        }

        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            RankFullDataModel ?model= await _RankRepository.GetById(id);
            if (model != null) {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _RankRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(RankFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            return await _RankRepository.Save(model); ;
        }
        public async Task<PagedList<RankFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _RankRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _RankRepository.GetDropDownList();
        }
        public async Task<List<RankDataList>?> GetDataList()
        {
            return await _RankRepository.GetDataList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _RankRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _RankRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _RankRepository.GetRecordLogger(recordId);
        }

        
        #endregion
    }
}
