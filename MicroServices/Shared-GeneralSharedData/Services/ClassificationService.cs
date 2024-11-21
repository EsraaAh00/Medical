using Shared_GeneralSharedData.Enums;
using Shared_GeneralSharedData.Interfaces.Repositories;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Models.Classification;
using SharedModels.Helpers;
using SharedModels.Models.Filter;
using SharedModels.Models;

namespace Shared_GeneralSharedData.Services
{
    public class ClassificationService : IClassificationService
    {
        private readonly IClassificationRepository _ClassificationRepository;
        public ClassificationService(IClassificationRepository ClassificationRepository)
        {
            _ClassificationRepository = ClassificationRepository;
        }
        #region CURD
        public async Task<ClassificationFullDataModel?> GetById(int? id)
        {
            return await _ClassificationRepository.GetById(id);
        }
        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            ClassificationFullDataModel? model = await _ClassificationRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _ClassificationRepository.Save(model);
        }
        public async Task<BaseResponse?> Save(ClassificationFullDataModel model)
        {
            return await _ClassificationRepository.Save(model); ;
        }
        public async Task<BaseResponse?> ActiveSetInActive(int id)
        {
            var model = await _ClassificationRepository.GetById(id);
            model.ActiveCode = (int)ActiveEnum.InActive;
            model.Active = ActiveEnum.InActive.ToString();
            return await _ClassificationRepository.Save(model);
        }

        public async Task<BaseResponse?> ActiveSetActive(int id)
        {
            var model = await _ClassificationRepository.GetById(id);
            model.ActiveCode = (int)ActiveEnum.Active;
            model.Active = ActiveEnum.Active.ToString();
            return await _ClassificationRepository.Save(model);
        }
        public async Task<PagedList<ClassificationFullDataModel?>> GetPagedList(NamePagedFilterModel filter)
        {
            return await _ClassificationRepository.GetPagedList(filter);
        }
        public async Task<List<BaseDropDown>?> GetDropDownList()
        {
            return await _ClassificationRepository.GetDropDownList();
        }
        public async Task<List<OuterIncludeModel>?> GetIncludeByIdsList(List<int> ids)
        {
            return await _ClassificationRepository.GetIncludeByIdsList(ids);
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
            return await _ClassificationRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _ClassificationRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
