using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SharedModels.Models;
using SharedModels.BaseRepository;
using Vendor_ProfileManagement.Entities;
using Vendor_ProfileManagement.Entities.Settings;
using Vendor_ProfileManagement.Entities.Logger;
namespace Vendor_ProfileManagement.Context;
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
    public virtual DbSet<BusinessType> BusinessType { get; set; }
    public virtual DbSet<BusinessTypeLogger> BusinessTypeLogger { get; set; }
    public virtual DbSet<BusinessTypeCategory> BusinessTypeCategory { get; set; }
    public virtual DbSet<BusinessTypeCategoryLogger> BusinessTypeCategoryLogger { get; set; }
    public virtual DbSet<VendorRequest> VendorRequest { get; set; }
    public virtual DbSet<VendorRequestLogger> VendorRequestLogger { get; set; }
    public virtual DbSet<SubscriptionPlan> SubscriptionPlan { get; set; }
    public virtual DbSet<SubscriptionPlanLogger> SubscriptionPlanLogger { get; set; }
    public virtual DbSet<MarketingPlan> MarketingPlan { get; set; }
    public virtual DbSet<MarketingPlanLogger> MarketingPlanLogger { get; set; }
    public virtual DbSet<DiscountPlan> DiscountPlan { get; set; }
    public virtual DbSet<DiscountPlanLogger> DiscountPlanLogger { get; set; }
    public virtual DbSet<Vendor> Vendor { get; set; }
    public virtual DbSet<VendorLogger> VendorLogger { get; set; }
    public virtual DbSet<VendorBusiness> VendorBusiness { get; set; }
    public virtual DbSet<VendorBusinessLogger> VendorBusinessLogger { get; set; }
    public virtual DbSet<Feature> Feature { get; set; }
    public virtual DbSet<FeatureLogger> FeatureLogger { get; set; }
    public virtual DbSet<Option> Option { get; set; }
    public virtual DbSet<OptionLogger> OptionLogger { get; set; }
    public virtual DbSet<Facility> Facility { get; set; }
    public virtual DbSet<FacilityLogger> FacilityLogger { get; set; }
    public virtual DbSet<VendorBusinessFacility> VendorBusinessFacility { get; set; }
    public virtual DbSet<VendorBusinessFacilityLogger> VendorBusinessFacilityLogger { get; set; }
    public virtual DbSet<BusinessTypeFeature> BusinessTypeFeature { get; set; }
    public virtual DbSet<BusinessTypeFeatureLogger> BusinessTypeFeatureLogger { get; set; }
    public virtual DbSet<VendorBusinessFeature> VendorBusinessFeature { get; set; }
    public virtual DbSet<VendorBusinessFeatureLogger> VendorBusinessFeatureLogger { get; set; }
    public virtual DbSet<VendorBusinessAreaAttraction> VendorBusinessAreaAttraction { get; set; }
    public virtual DbSet<VendorBusinessAreaAttractionLogger> VendorBusinessAreaAttractionLogger { get; set; }
    public virtual DbSet<VendorBusinessGallery> VendorBusinessGallery { get; set; }
    public virtual DbSet<VendorBusinessGalleryLogger> VendorBusinessGalleryLogger { get; set; }
    public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
    public virtual DbSet<PaymentMethodLogger> PaymentMethodLogger { get; set; }
    public virtual DbSet<VendorBusinessPaymentMethod> VendorBusinessPaymentMethod { get; set; }
    public virtual DbSet<VendorBusinessPaymentMethodLogger> VendorBusinessPaymentMethodLogger { get; set; }
    public virtual DbSet<BusinessAffiliationInfo> BusinessAffiliationInfo { get; set; }
    public virtual DbSet<BusinessAffiliationInfoLogger> BusinessAffiliationInfoLogger { get; set; }
    public virtual DbSet<VendorBusinessPolicy> VendorBusinessPolicy { get; set; }
    public virtual DbSet<VendorBusinessPolicyLogger> VendorBusinessPolicyLogger { get; set; }
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
        else if (logTable == "BusinessTypeLogger")
        {
            RecordLog = await BusinessTypeLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "BusinessTypeCategoryLogger")
        {
            RecordLog = await BusinessTypeCategoryLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "VendorRequestLogger")
        {
            RecordLog = await VendorRequestLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "SubscriptionPlanLogger")
        {
            RecordLog = await SubscriptionPlanLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "MarketingPlanLogger")
        {
            RecordLog = await MarketingPlanLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "DiscountPlanLogger")
        {
            RecordLog = await DiscountPlanLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "VendorLogger")
        {
            RecordLog = await VendorLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "VendorBusinessLogger")
        {
            RecordLog = await VendorBusinessLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "FeatureLogger")
        {
            RecordLog = await FeatureLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "OptionLogger")
        {
            RecordLog = await OptionLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "FacilityLogger")
        {
            RecordLog = await FacilityLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "VendorBusinessFacilityLogger")
        {
            RecordLog = await VendorBusinessFacilityLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "BusinessTypeFeatureLogger")
        {
            RecordLog = await BusinessTypeFeatureLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "VendorBusinessFeatureLogger")
        {
            RecordLog = await VendorBusinessFeatureLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "VendorBusinessAreaAttractionLogger")
        {
            RecordLog = await VendorBusinessAreaAttractionLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "VendorBusinessGalleryLogger")
        {
            RecordLog = await VendorBusinessGalleryLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "PaymentMethodLogger")
        {
            RecordLog = await PaymentMethodLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "VendorBusinessPaymentMethodLogger")
        {
            RecordLog = await VendorBusinessPaymentMethodLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "BusinessAffiliationInfoLogger")
        {
            RecordLog = await BusinessAffiliationInfoLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        else if (logTable == "VendorBusinessPolicyLogger")
        {
            RecordLog = await VendorBusinessPolicyLogger.AsNoTracking().Where(s => s.RecordId == recordId || s.Id == transactionId).Cast<LogModel?>().ToListAsync();
        }
        return RecordLog;
    }
}