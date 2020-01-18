using System;
using Grkouk.Nop.Api3.Models;
using Microsoft.EntityFrameworkCore;

namespace Grkouk.Nop.Api3.Data
{
    public  class AngelikasDbContext : BaseNopContext
    {
        public AngelikasDbContext()
        {
        }
       

        public AngelikasDbContext(DbContextOptions<AngelikasDbContext> options)
            : base(options)
        {
        }
        #region DbSets
        //public virtual DbSet<AclRecord> AclRecord { get; set; }
        //public virtual DbSet<ActivityLog> ActivityLog { get; set; }
        //public virtual DbSet<ActivityLogType> ActivityLogType { get; set; }
        //public virtual DbSet<Address> Address { get; set; }
        //public virtual DbSet<AddressAttribute> AddressAttribute { get; set; }
        //public virtual DbSet<AddressAttributeValue> AddressAttributeValue { get; set; }
        //public virtual DbSet<Affiliate> Affiliate { get; set; }
        //public virtual DbSet<BackInStockSubscription> BackInStockSubscription { get; set; }
        //public virtual DbSet<BlogComment> BlogComment { get; set; }
        //public virtual DbSet<BlogPost> BlogPost { get; set; }
        //public virtual DbSet<Campaign> Campaign { get; set; }
        //public virtual DbSet<Category> Category { get; set; }
        //public virtual DbSet<CategoryBanner> CategoryBanner { get; set; }
        //public virtual DbSet<CategoryTemplate> CategoryTemplate { get; set; }
        //public virtual DbSet<CheckoutAttribute> CheckoutAttribute { get; set; }
        //public virtual DbSet<CheckoutAttributeValue> CheckoutAttributeValue { get; set; }
        //public virtual DbSet<Country> Country { get; set; }
        //public virtual DbSet<CrossSellProduct> CrossSellProduct { get; set; }
        //public virtual DbSet<Currency> Currency { get; set; }
        //public virtual DbSet<Customer> Customer { get; set; }
        //public virtual DbSet<CustomerAddresses> CustomerAddresses { get; set; }
        //public virtual DbSet<CustomerAttribute> CustomerAttribute { get; set; }
        //public virtual DbSet<CustomerAttributeValue> CustomerAttributeValue { get; set; }
        //public virtual DbSet<CustomerCustomerRoleMapping> CustomerCustomerRoleMapping { get; set; }
        //public virtual DbSet<CustomerPassword> CustomerPassword { get; set; }
        //public virtual DbSet<CustomerRole> CustomerRole { get; set; }
        //public virtual DbSet<DeliveryDate> DeliveryDate { get; set; }
        //public virtual DbSet<Discount> Discount { get; set; }
        //public virtual DbSet<DiscountAppliedToCategories> DiscountAppliedToCategories { get; set; }
        //public virtual DbSet<DiscountAppliedToManufacturers> DiscountAppliedToManufacturers { get; set; }
        //public virtual DbSet<DiscountAppliedToProducts> DiscountAppliedToProducts { get; set; }
        //public virtual DbSet<DiscountRequirement> DiscountRequirement { get; set; }
        //public virtual DbSet<DiscountUsageHistory> DiscountUsageHistory { get; set; }
        //public virtual DbSet<Download> Download { get; set; }
        //public virtual DbSet<EmailAccount> EmailAccount { get; set; }
        //public virtual DbSet<ExternalAuthenticationRecord> ExternalAuthenticationRecord { get; set; }
        //public virtual DbSet<ForumsForum> ForumsForum { get; set; }
        //public virtual DbSet<ForumsGroup> ForumsGroup { get; set; }
        //public virtual DbSet<ForumsPost> ForumsPost { get; set; }
        //public virtual DbSet<ForumsPostVote> ForumsPostVote { get; set; }
        //public virtual DbSet<ForumsPrivateMessage> ForumsPrivateMessage { get; set; }
        //public virtual DbSet<ForumsSubscription> ForumsSubscription { get; set; }
        //public virtual DbSet<ForumsTopic> ForumsTopic { get; set; }
        //public virtual DbSet<GdprConsent> GdprConsent { get; set; }
        //public virtual DbSet<GdprLog> GdprLog { get; set; }
        //public virtual DbSet<GenericAttribute> GenericAttribute { get; set; }
        //public virtual DbSet<GiftCard> GiftCard { get; set; }
        //public virtual DbSet<GiftCardUsageHistory> GiftCardUsageHistory { get; set; }
        //public virtual DbSet<Language> Language { get; set; }
        //public virtual DbSet<LocaleStringResource> LocaleStringResource { get; set; }
        //public virtual DbSet<LocalizedProperty> LocalizedProperty { get; set; }
        //public virtual DbSet<Log> Log { get; set; }
        //public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        //public virtual DbSet<ManufacturerTemplate> ManufacturerTemplate { get; set; }
        //public virtual DbSet<MeasureDimension> MeasureDimension { get; set; }
        //public virtual DbSet<MeasureWeight> MeasureWeight { get; set; }
        //public virtual DbSet<MessageTemplate> MessageTemplate { get; set; }
        //public virtual DbSet<News> News { get; set; }
        //public virtual DbSet<NewsComment> NewsComment { get; set; }
        //public virtual DbSet<NewsLetterSubscription> NewsLetterSubscription { get; set; }
        //public virtual DbSet<Order> Order { get; set; }
        //public virtual DbSet<OrderItem> OrderItem { get; set; }
        //public virtual DbSet<OrderNote> OrderNote { get; set; }
        //public virtual DbSet<PermissionRecord> PermissionRecord { get; set; }
        //public virtual DbSet<PermissionRecordRoleMapping> PermissionRecordRoleMapping { get; set; }
        //public virtual DbSet<Picture> Picture { get; set; }
        //public virtual DbSet<PictureBinary> PictureBinary { get; set; }
        //public virtual DbSet<Poll> Poll { get; set; }
        //public virtual DbSet<PollAnswer> PollAnswer { get; set; }
        //public virtual DbSet<PollVotingRecord> PollVotingRecord { get; set; }
        //public virtual DbSet<PredefinedProductAttributeValue> PredefinedProductAttributeValue { get; set; }
        //public virtual DbSet<Product> Product { get; set; }
        //public virtual DbSet<ProductAttribute> ProductAttribute { get; set; }
        //public virtual DbSet<ProductAttributeCombination> ProductAttributeCombination { get; set; }
        //public virtual DbSet<ProductAttributeValue> ProductAttributeValue { get; set; }
        //public virtual DbSet<ProductAvailabilityRange> ProductAvailabilityRange { get; set; }
        //public virtual DbSet<ProductCategoryMapping> ProductCategoryMapping { get; set; }
        //public virtual DbSet<ProductManufacturerMapping> ProductManufacturerMapping { get; set; }
        //public virtual DbSet<ProductPictureMapping> ProductPictureMapping { get; set; }
        //public virtual DbSet<ProductProductAttributeMapping> ProductProductAttributeMapping { get; set; }
        //public virtual DbSet<ProductProductTagMapping> ProductProductTagMapping { get; set; }
        //public virtual DbSet<ProductReview> ProductReview { get; set; }
        //public virtual DbSet<ProductReviewHelpfulness> ProductReviewHelpfulness { get; set; }
        //public virtual DbSet<ProductReviewReviewTypeMapping> ProductReviewReviewTypeMapping { get; set; }
        //public virtual DbSet<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMapping { get; set; }
        //public virtual DbSet<ProductTag> ProductTag { get; set; }
        //public virtual DbSet<ProductTemplate> ProductTemplate { get; set; }
        //public virtual DbSet<ProductWarehouseInventory> ProductWarehouseInventory { get; set; }
        //public virtual DbSet<QueuedEmail> QueuedEmail { get; set; }
        //public virtual DbSet<RecurringPayment> RecurringPayment { get; set; }
        //public virtual DbSet<RecurringPaymentHistory> RecurringPaymentHistory { get; set; }
        //public virtual DbSet<RelatedProduct> RelatedProduct { get; set; }
        //public virtual DbSet<ReturnRequest> ReturnRequest { get; set; }
        //public virtual DbSet<ReturnRequestAction> ReturnRequestAction { get; set; }
        //public virtual DbSet<ReturnRequestReason> ReturnRequestReason { get; set; }
        //public virtual DbSet<ReviewType> ReviewType { get; set; }
        //public virtual DbSet<RewardPointsHistory> RewardPointsHistory { get; set; }
        //public virtual DbSet<ScheduleTask> ScheduleTask { get; set; }
        //public virtual DbSet<SearchTerm> SearchTerm { get; set; }
        //public virtual DbSet<Setting> Setting { get; set; }
        //public virtual DbSet<Shipment> Shipment { get; set; }
        //public virtual DbSet<ShipmentItem> ShipmentItem { get; set; }
        //public virtual DbSet<ShippingByWeightByTotalRecord> ShippingByWeightByTotalRecord { get; set; }
        //public virtual DbSet<ShippingMethod> ShippingMethod { get; set; }
        //public virtual DbSet<ShippingMethodRestrictions> ShippingMethodRestrictions { get; set; }
        //public virtual DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        //public virtual DbSet<SpecificationAttribute> SpecificationAttribute { get; set; }
        //public virtual DbSet<SpecificationAttributeOption> SpecificationAttributeOption { get; set; }
        //public virtual DbSet<StateProvince> StateProvince { get; set; }
        //public virtual DbSet<StockQuantityHistory> StockQuantityHistory { get; set; }
        //public virtual DbSet<Store> Store { get; set; }
        //public virtual DbSet<StoreMapping> StoreMapping { get; set; }
        //public virtual DbSet<StorePickupPoint> StorePickupPoint { get; set; }
        //public virtual DbSet<TaxCategory> TaxCategory { get; set; }
        //public virtual DbSet<TaxRate> TaxRate { get; set; }
        //public virtual DbSet<TierPrice> TierPrice { get; set; }
        //public virtual DbSet<Topic> Topic { get; set; }
        //public virtual DbSet<TopicTemplate> TopicTemplate { get; set; }
        //public virtual DbSet<UrlRecord> UrlRecord { get; set; }
        //public virtual DbSet<Vendor> Vendor { get; set; }
        //public virtual DbSet<VendorAttribute> VendorAttribute { get; set; }
        //public virtual DbSet<VendorAttributeValue> VendorAttributeValue { get; set; }
        //public virtual DbSet<VendorNote> VendorNote { get; set; }
        //public virtual DbSet<Warehouse> Warehouse { get; set; }
#endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

       
    }
}
