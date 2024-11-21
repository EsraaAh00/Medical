using SharedModels.Models;
using SharedModels.Helpers;
using SharedModels.Models.Filter;
using Staff_StaffProfileManagement.Models.StaffExperience;
using Staff_StaffProfileManagement.Interfaces.Repositories;
using Staff_StaffProfileManagement.Interfaces.Services;
namespace Staff_StaffProfileManagement.Services
{
    public class StaffExperienceService : IStaffExperienceService
    {
        private readonly IStaffExperienceRepository _StaffExperienceRepository;
        public StaffExperienceService(IStaffExperienceRepository StaffExperienceRepository)
        {
            _StaffExperienceRepository = StaffExperienceRepository;
        }
        #region CURD
        public async Task<StaffExperienceFullDataModel> GetById(int? id)
        {
            return await _StaffExperienceRepository.GetById(id);
        }

        public async Task<List<StaffExperienceFullDataModel>> GetListById(int? id)
        {
            return await _StaffExperienceRepository.GetListById(id);
        }
        public async Task<BaseResponse?> Save(StaffExperienceFullDataModel model)
        {
            return await _StaffExperienceRepository.Save(model); ;
        }

        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            StaffExperienceFullDataModel? model = await _StaffExperienceRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _StaffExperienceRepository.Save(model);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _StaffExperienceRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _StaffExperienceRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
