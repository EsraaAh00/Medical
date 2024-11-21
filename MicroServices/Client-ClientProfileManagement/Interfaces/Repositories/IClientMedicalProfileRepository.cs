using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientMedicalProfile;

namespace Client_ClientProfileManagement.Interfaces.Repositories
{
    public interface IClientMedicalProfileRepository
    {
        #region CURD
        Task<ClientMedicalProfileFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ClientMedicalProfileFullDataModel model);
        Task<PagedList<ClientMedicalProfileFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
