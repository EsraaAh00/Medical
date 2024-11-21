using SharedModels.Models;
using SharedModels.Helpers;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Models;
using Vendor_ProfileManagement.Models.Option;
using SharedModels.Models.Filter;
using Vendor_ProfileManagement.Repositories;
using Vendor_ProfileManagement.Validation;
namespace Vendor_ProfileManagement.Services
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _OptionRepository;
        public OptionService(IOptionRepository OptionRepository)
        {
            _OptionRepository = OptionRepository;
        }
        #region CURD
        public async Task<OptionFullDataModel?> GetById(int? id)
        {
            return await _OptionRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            OptionFullDataModel? model = await _OptionRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _OptionRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(OptionFullDataModel model)
        {
            BaseResponse Response = model.Validate();
            if (Response.IsError)
            {
                return Response;
            }
            return await _OptionRepository.Save(model);
        }
        public async Task<PagedList<OptionFullDataModel?>> GetPagedList(ParentPagedFilterModel filter)
        {
            return await _OptionRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _OptionRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _OptionRepository.GetIncludeByIdsList(ids);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _OptionRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _OptionRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
