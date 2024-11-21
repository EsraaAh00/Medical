using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SharedModels.Models;
using SharedModels.BaseRepository;
using Operation_FinanceManagement.Entities;
using Operation_FinanceManagement.Entities.Logger;
namespace Operation_FinanceManagement.Context;
public class FinanceManagementContext : DbContext,IDbContext
{
    public FinanceManagementContext (DbContextOptions<FinanceManagementContext> options)
    : base(options)
    {
    }
    public FinanceManagementContext ()
    {
    }
    public virtual DbSet<Logger> Logger { get; set; }
    public virtual DbSet<Transaction> Transaction { get; set; }
    public virtual DbSet<TransactionLogger> TransactionLogger { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    public async Task<List<LogModel?>?> GetRecordLog(string? entityName, int ?recordId,string logTable,int ?transactionId)
    {
        List<LogModel?> ?RecordLog = new List<LogModel?>();
        if (logTable == "Logger")
        {
            RecordLog = await Logger.AsNoTracking().Where(s =>( s.EntityName == entityName && s.RecordId == recordId)||s.Id== transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "TransactionLogger")
        {
            RecordLog = await TransactionLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        return RecordLog;
    }
}