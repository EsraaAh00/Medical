using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SharedModels.Models;
using SharedModels.BaseRepository;
using Shared_GeneralSharedData.Entities;
using Shared_GeneralSharedData.Entities.Logger;
namespace Shared_GeneralSharedData.Context;
public class GeneralSharedDataContext : DbContext, IDbContext
{
    public GeneralSharedDataContext(DbContextOptions<GeneralSharedDataContext> options)
    : base(options)
    {
    }
    public GeneralSharedDataContext()
    {
    }
    public virtual DbSet<Logger> Logger { get; set; }
    public virtual DbSet<Country> Country { get; set; }
    public virtual DbSet<CountryLogger> CountryLogger { get; set; }
    public virtual DbSet<Governorate> Governorate { get; set; }
    public virtual DbSet<GovernorateLogger> GovernorateLogger { get; set; }
    public virtual DbSet<Region> Region { get; set; }
    public virtual DbSet<RegionLogger> RegionLogger { get; set; }
    public virtual DbSet<Currency> Currency { get; set; }
    public virtual DbSet<CurrencyLogger> CurrencyLogger { get; set; }
    public virtual DbSet<Classification> Classification { get; set; }
    public virtual DbSet<ClassificationLogger> ClassificationLogger { get; set; }
    public virtual DbSet<Degree> Degree { get; set; }
    public virtual DbSet<DegreeLogger> DegreeLogger { get; set; }
    public virtual DbSet<Speciality> Speciality { get; set; }
    public virtual DbSet<SpecialityLogger> SpecialityLogger { get; set; }
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
        else if (logTable == "CountryLogger")
        {
            RecordLog = await CountryLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "GovernorateLogger")
        {
            RecordLog = await GovernorateLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "RegionLogger")
        {
            RecordLog = await RegionLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "CurrencyLogger")
        {
            RecordLog = await CurrencyLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ClassificationLogger")
        {
            RecordLog = await ClassificationLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "DegreeLogger")
        {
            RecordLog = await DegreeLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "SpecialityLogger")
        {
            RecordLog = await SpecialityLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        return RecordLog;
    }
}