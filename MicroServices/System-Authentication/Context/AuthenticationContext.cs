using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharedModels.BaseRepository;
using SharedModels.Models;
using System_Authentication.Entities;
using System_Authentication.Entities.Logger;
namespace System_Authentication.Context;
public class AuthenticationContext : IdentityDbContext<User, RoleGroup, int>, IDbContext
{
    public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
    {
    }
    public AuthenticationContext()
    {
    }
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<RoleGroup> RoleGroup { get; set; }
    public virtual DbSet<Logger> Logger { get; set; }
    public virtual DbSet<Rank> Rank { get; set; }
    public virtual DbSet<RankLogger> RankLogger { get; set; }
    public virtual DbSet<UserLogger> UserLogger { get; set; }
    public virtual DbSet<UserRoleGroup> UserRoleGroup { get; set; }
    public virtual DbSet<UserRoleGroupLogger> UserRoleGroupLogger { get; set; }
    public virtual DbSet<RoleGroupLogger> RoleGroupLogger { get; set; }
    public virtual DbSet<ActionRole> ActionRole { get; set; }
    public virtual DbSet<ActionRoleLogger> ActionRoleLogger { get; set; }
    public virtual DbSet<UserActionRole> UserActionRole { get; set; }
    public virtual DbSet<UserActionRoleLogger> UserActionRoleLogger { get; set; }
   // public virtual DbSet<RequestGuestToken> RequestGuestToken { get; set; }
    //public virtual DbSet<RequestGuestTokenLogger> RequestGuestTokenLogger { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
       .HasIndex(u => u.PhoneNumber).IsUnique();
        modelBuilder.Ignore<IdentityUserLogin<int>>();
        modelBuilder.Ignore<IdentityUserRole<int>>();
        modelBuilder.Ignore<IdentityUserClaim<int>>();
        modelBuilder.Ignore<IdentityUserToken<int>>();
        modelBuilder.Ignore<IdentityUser<int>>();
    }
    public async Task<List<LogModel?>?> GetRecordLog(string? entityName, int? recordId, string logTable, int? transactionId)
    {
        List<LogModel?>? RecordLog = new List<LogModel?>();
        if (logTable == "Logger")
        {
            RecordLog = await Logger.AsNoTracking().Where(s => (s.EntityName == entityName && s.RecordId == recordId) || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "RankLogger")
        {
            RecordLog = await RankLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "UserLogger")
        {
            RecordLog = await UserLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "UserRoleGroupLogger")
        {
            RecordLog = await UserRoleGroupLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "RoleGroupLogger")
        {
            RecordLog = await RoleGroupLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ActionRoleLogger")
        {
            RecordLog = await ActionRoleLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "UserActionRoleLogger")
        {
            RecordLog = await UserActionRoleLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
      //  else if (logTable == "RequestGuestTokenLogger")
        //{
          //  RecordLog = await RequestGuestTokenLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        //}
        return RecordLog;
    }
}