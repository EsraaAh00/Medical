using SharedModels.Models;
using Facility_FacilityProfileManagement.Models.FacilityWorkSchedule;
using Facility_FacilityProfileManagement.Interfaces.Repositories;
using Facility_FacilityProfileManagement.Interfaces.Services;
namespace Facility_FacilityProfileManagement.Services
{
    public class FacilityWorkScheduleService : IFacilityWorkScheduleService
    {
        private readonly IFacilityWorkScheduleRepository _FacilityWorkScheduleRepository;
        public FacilityWorkScheduleService(IFacilityWorkScheduleRepository FacilityWorkScheduleRepository)
        {
            _FacilityWorkScheduleRepository = FacilityWorkScheduleRepository;
        }
        #region CURD
        public async Task<FacilityWorkScheduleFullDataModel?> GetById(int? id)
        {
            return await _FacilityWorkScheduleRepository.GetById(id);
        }

        public async Task<List<FacilityWorkScheduleFullDataModel?>> GetListById(int? id)
        {
            return await _FacilityWorkScheduleRepository.GetListById(id);
        }
        public async Task<BaseResponse?> Save(FacilityWorkScheduleFullDataModel model)
        {
            return await _FacilityWorkScheduleRepository.Save(model); ;
        }

        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            FacilityWorkScheduleFullDataModel? model = await _FacilityWorkScheduleRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _FacilityWorkScheduleRepository.Save(model);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _FacilityWorkScheduleRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _FacilityWorkScheduleRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
