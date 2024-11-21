using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SharedModels.Models;
using SharedModels.BaseRepository;
using Client_ClientProfileManagement.Entities.Logger;
using Client_ClientProfileManagement.Entities;
namespace Client_ClientProfileManagement.Context;

 public class ClientProfileManagementContext : DbContext, IDbContext
    {
    public ClientProfileManagementContext(DbContextOptions<ClientProfileManagementContext> options): base(options)
    {
    }

    public ClientProfileManagementContext()
    {
    }

    public virtual DbSet<Logger> Logger { get; set; }
    public virtual DbSet<Client> Client { get; set; }
    public virtual DbSet<ClientLogger> ClientLogger { get; set; }
    public virtual DbSet<ClientAnalysisResult> ClientAnalysisResult { get; set; }
    public virtual DbSet<ClientAnalysisResultLogger> ClientAnalysisResultLogger { get; set; }
    public virtual DbSet<ClientExternalMedicalReport> ClientExternalMedicalReport { get; set; }
    public virtual DbSet<ClientExternalMedicalReportLogger> ClientExternalMedicalReportLogger { get; set; }
    public virtual DbSet<ClientInsurance> ClientInsurance { get; set; }
    public virtual DbSet<ClientInsuranceLogger> ClientInsuranceLogger { get; set; }
    public virtual DbSet<ClientMedicalProfile> ClientMedicalProfile { get; set; }
    public virtual DbSet<ClientMedicalProfileLogger> ClientMedicalProfileLogger { get; set; }
    public virtual DbSet<ClientMedicalReport> ClientMedicalReport { get; set; }
    public virtual DbSet<ClientMedicalReportLogger> ClientMedicalReportLogger { get; set; }
    public virtual DbSet<ClientPrescribtion> ClientPrescribtion { get; set; }
    public virtual DbSet<ClientPrescribtionLogger> ClientPrescribtionLogger { get; set; }
    public virtual DbSet<ClientTherapyProgram> ClientTherapyProgram { get; set; }
    public virtual DbSet<ClientTherapyProgramLogger> ClientTherapyProgramLogger { get; set; }
    public virtual DbSet<ClientXray> ClientXray { get; set; }
    public virtual DbSet<ClientXrayLogger> ClientXrayLogger { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public async Task<List<LogModel?>?> GetRecordLog(string? entityName, int? recordId, string logTable, int? transactionId)
    {
        List<LogModel?>? RecordLog = new List<LogModel?>();
        if (logTable == "Logger")
        {
            RecordLog = await Logger.AsNoTracking().Where(s => (s.EntityName == entityName && s.RecordId == recordId) || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ClientLogger")
        {
            RecordLog = await ClientLogger.AsNoTracking().Where(s => (s.EntityName == entityName && s.RecordId == recordId) || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ClientAnalysisResultLogger")
        {
            RecordLog = await ClientAnalysisResultLogger.AsNoTracking().Where(s => (s.EntityName == entityName && s.RecordId == recordId) || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ClientExternalMedicalReportLogger")
        {
            RecordLog = await ClientExternalMedicalReportLogger.AsNoTracking().Where(s => (s.EntityName == entityName && s.RecordId == recordId) || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ClientInsuranceLogger")
        {
            RecordLog = await ClientInsuranceLogger.AsNoTracking().Where(s => (s.EntityName == entityName && s.RecordId == recordId) || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ClientMedicalProfileLogger")
        {
            RecordLog = await ClientMedicalProfileLogger.AsNoTracking().Where(s => (s.EntityName == entityName && s.RecordId == recordId) || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ClientMedicalReportLogger")
        {
            RecordLog = await ClientMedicalReportLogger.AsNoTracking().Where(s => (s.EntityName == entityName && s.RecordId == recordId) || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ClientPrescribtionLogger")
        {
            RecordLog = await ClientPrescribtionLogger.AsNoTracking().Where(s => (s.EntityName == entityName && s.RecordId == recordId) || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ClientTherapyProgramLogger")
        {
            RecordLog = await ClientTherapyProgramLogger.AsNoTracking().Where(s => (s.EntityName == entityName && s.RecordId == recordId) || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ClientXrayLogger")
        {
            RecordLog = await ClientXrayLogger.AsNoTracking().Where(s => (s.EntityName == entityName && s.RecordId == recordId) || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        return RecordLog;
    }


}

