using SharedModels.Models;
using SharedModels.Helpers;
using SharedModels.Models.Filter;
using Staff_StaffProfileManagement.Models.Staff;
using Staff_StaffProfileManagement.Interfaces.Services;
using Staff_StaffProfileManagement.Interfaces.Repositories;
using Staff_StaffProfileManagement.Enums;
namespace Staff_StaffProfileManagement.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _StaffRepository;
        public StaffService(IStaffRepository StaffRepository)
        {
            _StaffRepository = StaffRepository;
        }
        #region CURD


        public async Task<StaffFullDataModel> GetById(int Id)
        {
            return await _StaffRepository.GetById(Id);
        }

        public async Task<List<StaffFullDataModel>> GetListByIds(List<int> ids)
        {
            return await _StaffRepository.GetListByIds(ids);
        }

        public async Task<List<StaffFullDataModel>> GetFilterList(string Type, string Speciality)
        {
            return await _StaffRepository.GetFilterList(Type,Speciality);
        }

        public async Task<BaseResponse?> Save(StaffFullDataModel model)
        {

            return await _StaffRepository.Save(model); ;
        }
        public async Task<BaseResponse?> StateSetInactive(int Id)
        {
            var model = await _StaffRepository.GetById(Id);
            model.StateCode = (int)StateEnum.Inactive;
            model.State = StateEnum.Inactive.ToString();
            return await _StaffRepository.Save(model);
        }
        public async Task<BaseResponse?> StateSetBlocked(int Id)
        {
            var model = await _StaffRepository.GetById(Id);
            model.StateCode = (int)StateEnum.Blocked;
            model.State = StateEnum.Blocked.ToString();
            return await _StaffRepository.Save(model);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _StaffRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _StaffRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
