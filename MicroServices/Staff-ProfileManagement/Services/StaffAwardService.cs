using SharedModels.Models;
using SharedModels.Helpers;
using SharedModels.Models.Filter;
using Staff_StaffProfileManagement.Models.StaffAward;
using Staff_StaffProfileManagement.Interfaces.Repositories;
using Staff_StaffProfileManagement.Interfaces.Services;
namespace Staff_StaffProfileManagement.Services
{
    public class StaffAwardService : IStaffAwardService
    {
        private readonly IStaffAwardRepository _StaffAwardRepository;
        public StaffAwardService(IStaffAwardRepository StaffAwardRepository)
        {
            _StaffAwardRepository = StaffAwardRepository;
        }
        #region CURD
        public async Task<StaffAwardFullDataModel?> GetById(int? id)
        {
            return await _StaffAwardRepository.GetById(id);
        }

        public async Task<List<StaffAwardFullDataModel?>> GetListById(int? id)
        {
            return await _StaffAwardRepository.GetListById(id);
        }
        public async Task<BaseResponse?> Save(StaffAwardFullDataModel model)
        {
            return await _StaffAwardRepository.Save(model); ;
        }

        public async Task<BaseResponse?> DeleteAndActivate(int? id)
        {
            StaffAwardFullDataModel? model = await _StaffAwardRepository.GetById(id);
            if (model != null)
            {
                model.IsDeleted = !(model.IsDeleted ?? false);

            }
            return await _StaffAwardRepository.Save(model);
        }
        #endregion
        #region Logger
        public async Task<BaseResponse> Undo(int? recordId, int? transactionId)
        {
            return await _StaffAwardRepository.Undo(recordId, transactionId);
        }
        public async Task<List<LogModel?>?> GetRecordLogger(int? recordId)
        {
            return await _StaffAwardRepository.GetRecordLogger(recordId);
        }
        #endregion
    }
}
