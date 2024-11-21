using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SharedModels.Models;
using SharedModels.BaseRepository;
using Staff_StaffProfileManagement.Entities;
using Staff_StaffProfileManagement.Entities.Logger;
namespace Staff_StaffProfileManagement.Context;
public class ProfileManagementContext : DbContext, IDbContext
{
    public ProfileManagementContext(DbContextOptions<ProfileManagementContext> options)
    : base(options)
    {
    }
    public ProfileManagementContext()
    {
    }
    public virtual DbSet<Logger> Logger { get; set; }
    public virtual DbSet<StaffRequest> StaffRequest { get; set; }
    public virtual DbSet<StaffRequestLogger> StaffRequestLogger { get; set; }
    public virtual DbSet<Staff> Staff { get; set; }
    public virtual DbSet<StaffLogger> StaffLogger { get; set; }
    public virtual DbSet<StaffAward> StaffAward { get; set; }
    public virtual DbSet<StaffAwardLogger> StaffAwardLogger { get; set; }
    public virtual DbSet<StaffExperience> StaffExperience { get; set; }
    public virtual DbSet<StaffExperienceLogger> StaffExperienceLogger { get; set; }
    public virtual DbSet<StaffWorkSchedule> StaffWorkSchedule { get; set; }
    public virtual DbSet<StaffWorkScheduleLogger> StaffWorkScheduleLogger { get; set; }
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
        else if (logTable == "StaffLogger")
        {
            RecordLog = await StaffLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "StaffAwardLogger")
        {
            RecordLog = await StaffAwardLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "StaffExperienceLogger")
        {
            RecordLog = await StaffExperienceLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "StaffWorkScheduleLogger")
        {
            RecordLog = await StaffWorkScheduleLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        return RecordLog;
    }
}