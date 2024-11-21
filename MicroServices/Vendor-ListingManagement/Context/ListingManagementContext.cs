using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SharedModels.Models;
using SharedModels.BaseRepository;
using Vendor_ListingManagement.Entities;
using Vendor_ListingManagement.Entities.Logger;

namespace Vendor_ListingManagement.Context;
public class ListingManagementContext : DbContext, IDbContext
{
    public ListingManagementContext(DbContextOptions<ListingManagementContext> options)
    : base(options)
    {
    }
    public ListingManagementContext()
    {
    }
    public virtual DbSet<Logger> Logger { get; set; }
    public virtual DbSet<ListingItemDetailSetting> ListingItemDetailSetting { get; set; }
    public virtual DbSet<ListingItemDetailSettingLogger> ListingItemDetailSettingLogger { get; set; }
    public virtual DbSet<ItemCategories> ItemCategories { get; set; }
    public virtual DbSet<ItemCategoriesLogger> ItemCategoriesLogger { get; set; }
    public virtual DbSet<ListingItem> ListingItem { get; set; }
    public virtual DbSet<ListingItemLogger> ListingItemLogger { get; set; }
    public virtual DbSet<ListingItemDetail> ListingItemDetail { get; set; }
    public virtual DbSet<ListingItemDetailLogger> ListingItemDetailLogger { get; set; }
    public virtual DbSet<ListingItemPhotos> ListingItemPhotos { get; set; }
    public virtual DbSet<ListingItemsPricing> ListingItemsPricing { get; set; }
    public virtual DbSet<ListingItemsPricingLogger> ListingItemsPricingLogger { get; set; }
    public virtual DbSet<ListingItemsTax> ListingItemsTax { get; set; }
    public virtual DbSet<ListingItemsTaxLogger> ListingItemsTaxLogger { get; set; }
    public virtual DbSet<ItemSubCategories> ItemSubCategories { get; set; }
    public virtual DbSet<ItemSubCategoriesLogger> ItemSubCategoriesLogger { get; set; }
    public virtual DbSet<ListingItemPackgeLogger> ListingItemPackgeLogger { get; set; }
    public virtual DbSet<ListingItemCancellationPolicy> ListingItemCancellationPolicy { get; set; }
    public virtual DbSet<ListingItemCancellationPolicyLogger> ListingItemCancellationPolicyLogger { get; set; }
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
        else if (logTable == "ListingItemDetailSettingLogger")
        {
            RecordLog = await ListingItemDetailSettingLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ItemCategoriesLogger")
        {
            RecordLog = await ItemCategoriesLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ListingItemLogger")
        {
            RecordLog = await ListingItemLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ListingItemDetailLogger")
        {
            RecordLog = await ListingItemDetailLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ListingItemsPricingLogger")
        {
            RecordLog = await ListingItemsPricingLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ListingItemsTaxLogger")
        {
            RecordLog = await ListingItemsTaxLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ListingItemPackgeLogger")
        {
            RecordLog = await ListingItemPackgeLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "ListingItemCancellationPolicyLogger")
        {
            RecordLog = await ListingItemCancellationPolicyLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        return RecordLog;
    }

    public static implicit operator DbSet<object>(ListingManagementContext v)
    {
        throw new NotImplementedException();
    }
}