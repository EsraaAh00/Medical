using SharedModels.Models;
using SharedModels.Helpers;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Interfaces.Repositories;
using Shared_GeneralSharedData.Models;
using Shared_GeneralSharedData.Models.Country;
using SharedModels.Models.Filter;
using Shared_GeneralSharedData.Enums;
namespace Shared_GeneralSharedData.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _CountryRepository;
        public CountryService(ICountryRepository CountryRepository)
        {
            _CountryRepository = CountryRepository;
        }
        #region CURD
        public async Task<CountryFullDataModel?> GetById(int? id)
        {
            return await _CountryRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            CountryFullDataModel? model = await _CountryRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _CountryRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(CountryFullDataModel model)
        {
            if (model.ImageFile != null)
            {
                model.Image = await UploadFilesHelper.UploadFile(model.ImageFile, "Shared-GeneralSharedData/Image", model.Image);
            }
            return await _CountryRepository.Save(model); ;
        }
        public async Task<BaseResponse?> ActiveSetInActive(int id)
        {
            var model = await _CountryRepository.GetById(id);
            model.ActiveCode = (int)ActiveEnum.InActive;
            model.Active = ActiveEnum.InActive.ToString();
            return await _CountryRepository.Save(model);
        }

        public async Task<BaseResponse?> ActiveSetActive(int id)
        {
            var model = await _CountryRepository.GetById(id);
            model.ActiveCode = (int)ActiveEnum.Active;
            model.Active = ActiveEnum.Active.ToString();
            return await _CountryRepository.Save(model);
        }
        public async Task<PagedList<CountryFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _CountryRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _CountryRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _CountryRepository.GetIncludeByIdsList(ids);
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
            return await _CountryRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _CountryRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
