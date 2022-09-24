namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            InvoiceItems = new HashSet<InvoiceItem>();
        }

        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public int InvoiceNumber { get; set; }

        public bool IsOrder { get; set; }

        public bool IsProformaInvoice { get; set; }

        public decimal Total { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsClosed { get; set; }

        public DateTime WorkingDay { get; set; }

        public string Error { get; set; }

        public Guid? Waiter_Id { get; set; }

        public Guid? PaymentType_Id { get; set; }

        public Guid? Table_Id { get; set; }

        public Guid? Station_Id { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal DiscountAmmount { get; set; }

        public Guid? Customer_Id { get; set; }

        public string Note { get; set; }

        public bool IsStorned { get; set; }

        public string JIR { get; set; }

        public string ZKI { get; set; }

        public decimal ReturnChange { get; set; }

        public string CashPayed { get; set; }

        public string InvoiceNumberFormatted { get; set; }

        public DateTime OrderCreated { get; set; }

        public Guid? OrderByWaiter_Id { get; set; }

        public int ServiceChargePercentage { get; set; }

        public string FiscalReceiptNumber { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual EInvoice EInvoice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }

        public virtual User User { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public virtual Station Station { get; set; }

        public virtual Table Table { get; set; }

        public virtual User User1 { get; set; }
    }
}
