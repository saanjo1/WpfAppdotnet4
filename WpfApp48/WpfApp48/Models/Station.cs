namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Station
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Station()
        {
            Invoices = new HashSet<Invoice>();
            StationArticles = new HashSet<StationArticle>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public string Addres { get; set; }

        public string TaxNumber { get; set; }

        public string Currency { get; set; }

        public string Language { get; set; }

        public string Country { get; set; }

        public string Theme { get; set; }

        public bool IsTableService { get; set; }

        public bool PrintPreview { get; set; }

        public bool PrintOrder { get; set; }

        public bool PrintReceiptAfterOrder { get; set; }

        public bool LogOffUserAfterInvoice { get; set; }

        public bool IsFiscal { get; set; }

        public string InvoiceFooter1 { get; set; }

        public string InvoiceFooter2 { get; set; }

        public DateTime WorkDayStartAt { get; set; }

        public bool UseProformaInvoice { get; set; }

        public string PhoneNumber { get; set; }

        public string CityPostCode { get; set; }

        public string IdNumber { get; set; }

        public bool ForbidAccessToTakenTables { get; set; }

        public bool IsVAT { get; set; }

        public bool IsInvoiceDailyCounter { get; set; }

        public string LocationMark { get; set; }

        public string InvoiceMark { get; set; }

        public string InvoiceFooter3 { get; set; }

        public string InvoiceFooter4 { get; set; }

        public bool IsRetail { get; set; }

        public bool AllowCancelOrderItems { get; set; }

        public bool PrintOnA4 { get; set; }

        public string BankAccount { get; set; }

        public string PlaceOfIssueOfInvoice { get; set; }

        public bool UseAdditionalCurrency { get; set; }

        [Required]
        public string AdditionalCurrencyMark { get; set; }

        public decimal AdditionalCurrencyRate { get; set; }

        public bool AreInvoiceItemsGrouped { get; set; }

        public bool UseChangeCalculator { get; set; }

        public bool IsTaxAddedOnPrice { get; set; }

        public string Email { get; set; }

        public bool DisplayAutomaticallyModifiers { get; set; }

        public bool UsePrintAllOrders { get; set; }

        public bool PrintAfterDeleteArticles { get; set; }

        public bool ShowGrossInsteadOfNettPrice { get; set; }

        public string Reserved01 { get; set; }

        public int ServiceChargePercentage { get; set; }

        public bool ShowTaxesOnInvoice { get; set; }

        public bool IsEInvoiceEnabled { get; set; }

        public bool ShowWaiterNameOnA4Invoice { get; set; }

        public bool ForbidEndShiftIfThereAreAnyOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StationArticle> StationArticles { get; set; }
    }
}
