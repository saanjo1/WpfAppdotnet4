namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InvoiceItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvoiceItem()
        {
            InventoryItemBases = new HashSet<InventoryItemBas>();
            InvoiceItemModifiers = new HashSet<InvoiceItemModifier>();
        }

        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public bool IsDeleted { get; set; }

        public decimal Quantity { get; set; }

        public decimal BasePrice { get; set; }

        public decimal Total { get; set; }

        public Guid? Article_Id { get; set; }

        public Guid? Invoice_Id { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal DiscountAmmount { get; set; }

        public decimal PriceWithoutDiscount { get; set; }

        public decimal BasePriceWithoutDiscount { get; set; }

        public decimal TotalWithoutDiscount { get; set; }

        public decimal TotalTaxes { get; set; }

        public decimal TaxAmmount { get; set; }

        public decimal TotalWithoutTax { get; set; }

        public string Note { get; set; }

        public int State { get; set; }

        public decimal ReturnFee { get; set; }

        [StringLength(50)]
        public string TaxTag { get; set; }

        public decimal? TaxVal { get; set; }

        public string ArticleName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryItemBas> InventoryItemBases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceItemModifier> InvoiceItemModifiers { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
