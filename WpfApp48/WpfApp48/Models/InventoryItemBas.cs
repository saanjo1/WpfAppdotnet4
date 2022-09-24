namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryItemBases")]
    public partial class InventoryItemBas
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public decimal Quantity { get; set; }

        public bool IsDeleted { get; set; }

        public decimal? Price { get; set; }

        public decimal? Tax { get; set; }

        public decimal? Total { get; set; }

        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }

        public Guid? InventoryDocument_Id { get; set; }

        public Guid? Storage_Id { get; set; }

        public Guid? Good_Id { get; set; }

        public Guid? InvoiceItem_Id { get; set; }

        public decimal? NormativQuantity { get; set; }

        public decimal? CurrentQuantity { get; set; }

        public decimal? Refuse { get; set; }

        public virtual Good Good { get; set; }

        public virtual InventoryDocument InventoryDocument { get; set; }

        public virtual InvoiceItem InvoiceItem { get; set; }

        public virtual Storage Storage { get; set; }
    }
}
