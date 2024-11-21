using SharedModels.Models;
using Facility_FacilityProfileManagement.Models.Facility;
using Facility_FacilityProfileManagement.Interfaces.Repositories;
using Facility_FacilityProfileManagement.Interfaces.Services;
using Facility_FacilityProfileManagement.Enums;
namespace Facility_FacilityProfileManagement.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IFacilityRepository _FacilityRepository;
        public FacilityService(IFacilityRepository FacilityRepository)
        {
            _FacilityRepository = FacilityRepository;
        }
        #region CURD

        public async Task<FacilityFullDataModel> GetById(int Id)
        {
            return await _FacilityRepository.GetById(Id);
        }


        public async Task<List<FacilityFullDataModel>> GetListByIds(List<int> ids)
        {
            return await _FacilityRepository.GetListByIds(ids);
        }


        public async Task<List<FacilityFullDataModel>> GetFilterList(string Type, double lat, double lng)
        {
            return await _FacilityRepository.GetFilterList(Type, lat, lng);
        }

        public async Task<BaseResponse?> Save(FacilityFullDataModel model)
        {

            return await _FacilityRepository.Save(model); ;
        }
        public async Task<BaseResponse?> StateSetInactive(int Id)
        {
            var model = await _FacilityRepository.GetById(Id);
            model.StateCode = (int)StateEnum.Inactive;
            model.State = StateEnum.Inactive.ToString();
            return await _FacilityRepository.Save(model);
        }
        public async Task<BaseResponse?> StateSetBlocked(int Id)
        {
            var model = await _FacilityRepository.GetById(Id);
            model.StateCode = (int)StateEnum.Blocked;
            model.State = StateEnum.Blocked.ToString();
            return await _FacilityRepository.Save(model);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _FacilityRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _FacilityRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
