using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SharedModels.Models;
using SharedModels.BaseRepository;
using Operation_OperationsManagement.Entities;
using Operation_OperationsManagement.Entities.Logger;
namespace Operation_OperationsManagement.Context;
public class OperationsManagementContext : DbContext,IDbContext
{
    public OperationsManagementContext (DbContextOptions<OperationsManagementContext> options)
    : base(options)
    {
    }
    public OperationsManagementContext ()
    {
    }
    public virtual DbSet<Logger> Logger { get; set; }
    public virtual DbSet<Ticket> Ticket { get; set; }
    public virtual DbSet<TicketLogger> TicketLogger { get; set; }
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
        else if (logTable == "TicketLogger")
        {
            RecordLog = await TicketLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        return RecordLog;
    }
}