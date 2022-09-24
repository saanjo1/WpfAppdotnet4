using System.Data.Entity;

namespace WpfApp48
{
    public partial class PosSectorContext : DbContext
    {
        public PosSectorContext()
            : base("name=ConfigurationModel")
        {
        }

        public DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public DbSet<ArticleGood> ArticleGoods { get; set; }
        public DbSet<ArticleModifier> ArticleModifiers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EInvoiceOrderFormFile> EInvoiceOrderFormFiles { get; set; }
        public DbSet<EInvoiceParty> EInvoiceParties { get; set; }
        public DbSet<EInvoice> EInvoices { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<InventoryDocument> InventoryDocuments { get; set; }
        public DbSet<InventoryItemBas> InventoryItemBases { get; set; }
        public DbSet<InvoiceItemModifier> InvoiceItemModifiers { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Novi> Novis { get; set; }
        public DbSet<OrdersPerDate> OrdersPerDates { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PrintJob> PrintJobs { get; set; }
        public DbSet<Print> Prints { get; set; }
        public DbSet<RuleItem> RuleItems { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<StationArticle> StationArticles { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TaxArticle> TaxArticles { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Articles_yedek> Articles_yedek { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleGood>()
                .Property(e => e.Quantity)
                .HasPrecision(14, 4);

            modelBuilder.Entity<Article>()
                .Property(e => e.Price)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategories)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Category_Id);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.Customer_Id);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.People)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.Customer_Id);

            modelBuilder.Entity<EInvoiceOrderFormFile>()
                .HasMany(e => e.EInvoices)
                .WithOptional(e => e.EInvoiceOrderFormFile)
                .HasForeignKey(e => e.OrderFormFileId);

            modelBuilder.Entity<EInvoiceParty>()
                .HasMany(e => e.EInvoices)
                .WithOptional(e => e.EInvoiceParty)
                .HasForeignKey(e => e.ReceiverId);

            modelBuilder.Entity<EInvoiceParty>()
                .HasMany(e => e.EInvoices1)
                .WithOptional(e => e.EInvoiceParty1)
                .HasForeignKey(e => e.SenderId);

            modelBuilder.Entity<Good>()
                .Property(e => e.LatestPrice)
                .HasPrecision(14, 4);

            modelBuilder.Entity<Good>()
                .Property(e => e.Volumen)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.ArticleGoods)
                .WithOptional(e => e.Good)
                .HasForeignKey(e => e.Good_Id);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.InventoryItemBases)
                .WithOptional(e => e.Good)
                .HasForeignKey(e => e.Good_Id);

            modelBuilder.Entity<InventoryDocument>()
                .HasMany(e => e.InventoryDocuments1)
                .WithOptional(e => e.InventoryDocument1)
                .HasForeignKey(e => e.SourceInvoice_Id);

            modelBuilder.Entity<InventoryDocument>()
                .HasMany(e => e.InventoryItemBases)
                .WithOptional(e => e.InventoryDocument)
                .HasForeignKey(e => e.InventoryDocument_Id);

            modelBuilder.Entity<InventoryItemBas>()
                .Property(e => e.Quantity)
                .HasPrecision(14, 4);

            modelBuilder.Entity<InventoryItemBas>()
                .Property(e => e.Price)
                .HasPrecision(14, 4);

            modelBuilder.Entity<InventoryItemBas>()
                .Property(e => e.Total)
                .HasPrecision(14, 3);

            modelBuilder.Entity<InventoryItemBas>()
                .Property(e => e.NormativQuantity)
                .HasPrecision(14, 4);

            modelBuilder.Entity<InventoryItemBas>()
                .Property(e => e.CurrentQuantity)
                .HasPrecision(14, 4);

            modelBuilder.Entity<InvoiceItemModifier>()
                .Property(e => e.PriceWithoutDiscount)
                .HasPrecision(14, 4);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.Price)
                .HasPrecision(14, 4);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.Quantity)
                .HasPrecision(14, 4);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.BasePrice)
                .HasPrecision(14, 8);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.Total)
                .HasPrecision(14, 4);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.DiscountPercentage)
                .HasPrecision(16, 2);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.DiscountAmmount)
                .HasPrecision(16, 2);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.PriceWithoutDiscount)
                .HasPrecision(14, 4);

            modelBuilder.Entity<InvoiceItem>()
                .Property(e => e.BasePriceWithoutDiscount)
                .HasPrecision(14, 8);

            modelBuilder.Entity<InvoiceItem>()
                .HasMany(e => e.InventoryItemBases)
                .WithOptional(e => e.InvoiceItem)
                .HasForeignKey(e => e.InvoiceItem_Id);

            modelBuilder.Entity<InvoiceItem>()
                .HasMany(e => e.InvoiceItemModifiers)
                .WithOptional(e => e.InvoiceItem)
                .HasForeignKey(e => e.InvoiceItem_Id);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Total)
                .HasPrecision(14, 4);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.DiscountPercentage)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.DiscountAmmount)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.ReturnChange)
                .HasPrecision(14, 4);

            modelBuilder.Entity<Invoice>()
                .HasOptional(e => e.EInvoice)
                .WithRequired(e => e.Invoice);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceItems)
                .WithOptional(e => e.Invoice)
                .HasForeignKey(e => e.Invoice_Id);

            modelBuilder.Entity<MeasureUnit>()
                .HasMany(e => e.Goods)
                .WithOptional(e => e.MeasureUnit)
                .HasForeignKey(e => e.Unit_Id);

            modelBuilder.Entity<Novi>()
                .Property(e => e.Price)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PaymentType>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.PaymentType)
                .HasForeignKey(e => e.PaymentType_Id);

            modelBuilder.Entity<Rule>()
                .HasMany(e => e.RuleItems)
                .WithOptional(e => e.Rule)
                .HasForeignKey(e => e.Rule_Id);

            modelBuilder.Entity<Rule>()
                .HasMany(e => e.Taxes)
                .WithMany(e => e.Rules)
                .Map(m => m.ToTable("RuleTaxes"));

            modelBuilder.Entity<Sector>()
                .HasMany(e => e.Tables)
                .WithOptional(e => e.Sector)
                .HasForeignKey(e => e.Sector_Id);

            modelBuilder.Entity<Station>()
                .Property(e => e.AdditionalCurrencyRate)
                .HasPrecision(14, 4);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.Station)
                .HasForeignKey(e => e.Station_Id);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.StationArticles)
                .WithRequired(e => e.Station)
                .HasForeignKey(e => e.Station_Id);

            modelBuilder.Entity<Storage>()
                .HasMany(e => e.Categories)
                .WithOptional(e => e.Storage)
                .HasForeignKey(e => e.Storage_Id);

            modelBuilder.Entity<Storage>()
                .HasMany(e => e.InventoryDocuments)
                .WithOptional(e => e.Storage)
                .HasForeignKey(e => e.Storage_Id);

            modelBuilder.Entity<Storage>()
                .HasMany(e => e.InventoryItemBases)
                .WithOptional(e => e.Storage)
                .HasForeignKey(e => e.Storage_Id);

            modelBuilder.Entity<Storage>()
                .HasMany(e => e.SubCategories)
                .WithOptional(e => e.Storage)
                .HasForeignKey(e => e.Storage_Id);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Articles)
                .WithOptional(e => e.SubCategory)
                .HasForeignKey(e => e.SubCategory_Id);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Novis)
                .WithOptional(e => e.SubCategory)
                .HasForeignKey(e => e.SubCategory_Id);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.InventoryDocuments)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.Supplier_Id);

            modelBuilder.Entity<Table>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.Table)
                .HasForeignKey(e => e.Table_Id);

            modelBuilder.Entity<Tax>()
                .HasMany(e => e.TaxArticles)
                .WithRequired(e => e.Tax)
                .HasForeignKey(e => e.Tax_Id);

            modelBuilder.Entity<UserGroup>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.UserGroup)
                .HasForeignKey(e => e.Group_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.OrderByWaiter_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Invoices1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.Waiter_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.From_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.To_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tables)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Waiter_Id);

            modelBuilder.Entity<Articles_yedek>()
                .Property(e => e.Price)
                .HasPrecision(18, 4);
        }
    }
}
