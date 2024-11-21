using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SharedModels.Models;
using SharedModels.BaseRepository;
using Client_ClientRelationMangement.Entities;
using Client_ClientRelationMangement.Entities.Logger;
namespace Client_ClientRelationMangement.Context;
public class ClientRelationMangementContext : DbContext, IDbContext
{
    public ClientRelationMangementContext(DbContextOptions<ClientRelationMangementContext> options)
    : base(options)
    {
    }
    public ClientRelationMangementContext()
    {
    }
    public virtual DbSet<Logger> Logger { get; set; }
    public virtual DbSet<Complaint> Complaint { get; set; }
    public virtual DbSet<ComplaintLogger> ComplaintLogger { get; set; }
    public virtual DbSet<ComplaintAction> ComplaintAction { get; set; }
    public virtual DbSet<ComplaintActionLogger> ComplaintActionLogger { get; set; }
    public virtual DbSet<Sanction> Sanction { get; set; }
    public virtual DbSet<SanctionLogger> SanctionLogger { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    public async Task<List<LogModel?>?> GetRecordLog(string? entityName, int? recordId, string logTable, int? transactionId)
    {
        List<LogModel?>? RecordLog = new List<LogModel?>();
        if (logTable == "Logger")
        {
            RecordLog = await Logger.AsNoTracking().Where(s => s.EntityName == entityName && s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ComplaintLogger")
        {
            RecordLog = await ComplaintLogger.AsNoTracking().Where(s => s.EntityName == entityName && s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ComplaintActionLogger")
        {
            RecordLog = await ComplaintActionLogger.AsNoTracking().Where(s => s.EntityName == entityName && s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "SanctionLogger")
        {
            RecordLog = await SanctionLogger.AsNoTracking().Where(s => s.EntityName == entityName && s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        return RecordLog;
    }
}