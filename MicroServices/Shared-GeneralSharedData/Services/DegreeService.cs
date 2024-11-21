using Shared_GeneralSharedData.Enums;
using Shared_GeneralSharedData.Interfaces.Repositories;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Models.Degree;
using SharedModels.Helpers;
using SharedModels.Models.Filter;
using SharedModels.Models;

namespace Shared_GeneralSharedData.Services
{
    public class DegreeService : IDegreeService
    {
        private readonly IDegreeRepository _DegreeRepository;
        public DegreeService(IDegreeRepository DegreeRepository)
        {
            _DegreeRepository = DegreeRepository;
        }
        #region CURD
        public async Task<DegreeFullDataModel?> GetById(int? id)
        {
            return await _DegreeRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            DegreeFullDataModel? model = await _DegreeRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _DegreeRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(DegreeFullDataModel model)
        {
            return await _DegreeRepository.Save(model); ;
        }
        public async Task<BaseResponse?> ActiveSetInActive(int id)
        {
            var model = await _DegreeRepository.GetById(id);
            model.ActiveCode = (int)ActiveEnum.InActive;
            model.Active = ActiveEnum.InActive.ToString();
            return await _DegreeRepository.Save(model);
        }

        public async Task<BaseResponse?> ActiveSetActive(int id)
        {
            var model = await _DegreeRepository.GetById(id);
            model.ActiveCode = (int)ActiveEnum.Active;
            model.Active = ActiveEnum.Active.ToString();
            return await _DegreeRepository.Save(model);
        }
        public async Task<PagedList<DegreeFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _DegreeRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _DegreeRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _DegreeRepository.GetIncludeByIdsList(ids);
        }
        public List<BaseDropDown>? GetActiveEnumDropDownList()
        {
            var dropDownList = Enum.GetValues(typeof(ActiveEnum)).Cast<ActiveEnum>().Select(s =>
          new BaseDropDown { Id = (int)s, Name = s.GetDisplayName() }).ToList().GetListDropDownWithAll();
            return dropDownList;
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _DegreeRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _DegreeRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
