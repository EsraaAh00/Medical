using Client_ClientProfileManagement.Models.Client;
using SharedModels.Models.Filter;
using SharedModels.Models;
using Client_ClientProfileManagement.Models.ClientTherapyProgram;

namespace Client_ClientProfileManagement.Interfaces.Services
{
    public interface IClientTherapyProgramService
    {
        #region CURD
        Task<ClientTherapyProgramFullDataModel?> GetById(int? id);
        Task<BaseResponse?> Save(ClientTherapyProgramFullDataModel model);
        Task<PagedList<ClientTherapyProgramFullDataModel?>> GetPagedList(NamePagedFilterModel filter);
        #endregion
        #region Logger
        Task<BaseResponse> Undo(int? recordId, int? transactionId);
        Task<List<LogModel?>?> GetRecordLogger(int? recordId);
        #endregion
    }
}
