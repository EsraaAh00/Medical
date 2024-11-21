using Microsoft.EntityFrameworkCore;
using SharedModels.Models;
using SharedModels.BaseRepository;
using Facility_FacilityProfileManagement.Entities;
using Facility_FacilityProfileManagement.Entities.Logger;
namespace Facility_FacilityProfileManagement.Context;
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
    public virtual DbSet<Facility> Facility { get; set; }
    public virtual DbSet<FacilityLogger> FacilityLogger { get; set; }
    public virtual DbSet<FacilityRequest> FacilityRequest { get; set; }
    public virtual DbSet<FacilityRequestLogger> FacilityRequestLogger { get; set; }
    public virtual DbSet<FacilityListing> FacilityListing { get; set; }
    public virtual DbSet<FacilityListingLogger> FacilityListingLogger { get; set; }
    public virtual DbSet<FacilityWorkSchedule> FacilityWorkSchedule { get; set; }
    public virtual DbSet<FacilityWorkScheduleLogger> FacilityWorkScheduleLogger { get; set; }

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
        else if (logTable == "FacilityLogger")
        {
            RecordLog = await FacilityLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "FacilityRequestLogger")
        {
            RecordLog = await FacilityRequestLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "FacilityListingLogger")
        {
            RecordLog = await FacilityListingLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "FacilityWorkScheduleLogger")
        {
            RecordLog = await FacilityWorkScheduleLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        return RecordLog;
    }
}