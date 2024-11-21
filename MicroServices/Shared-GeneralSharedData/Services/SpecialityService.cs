using Shared_GeneralSharedData.Enums;
using Shared_GeneralSharedData.Interfaces.Repositories;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Models.Speciality;
using SharedModels.Helpers;
using SharedModels.Models.Filter;
using SharedModels.Models;

namespace Shared_GeneralSharedData.Services
{
    public class SpecialityService : ISpecialityService
    {
        private readonly ISpecialityRepository _SpecialityRepository;
        public SpecialityService(ISpecialityRepository SpecialityRepository)
        {
            _SpecialityRepository = SpecialityRepository;
        }
        #region CURD
        public async Task<SpecialityFullDataModel?> GetById(int? id)
        {
            return await _SpecialityRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            SpecialityFullDataModel? model = await _SpecialityRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _SpecialityRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(SpecialityFullDataModel model)
        {
            return await _SpecialityRepository.Save(model); ;
        }
        public async Task<BaseResponse?> ActiveSetInActive(int id)
        {
            var model = await _SpecialityRepository.GetById(id);
            model.ActiveCode = (int)ActiveEnum.InActive;
            model.Active = ActiveEnum.InActive.ToString();
            return await _SpecialityRepository.Save(model);
        }

        public async Task<BaseResponse?> ActiveSetActive(int id)
        {
            var model = await _SpecialityRepository.GetById(id);
            model.ActiveCode = (int)ActiveEnum.Active;
            model.Active = ActiveEnum.Active.ToString();
            return await _SpecialityRepository.Save(model);
        }
        public async Task<PagedList<SpecialityFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _SpecialityRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _SpecialityRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _SpecialityRepository.GetIncludeByIdsList(ids);
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
            return await _SpecialityRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _SpecialityRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
