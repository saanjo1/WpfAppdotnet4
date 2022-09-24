namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InventoryDocument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventoryDocument()
        {
            InventoryDocuments1 = new HashSet<InventoryDocument>();
            InventoryItemBases = new HashSet<InventoryItemBas>();
        }

        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public int Order { get; set; }

        public Guid? Storage_Id { get; set; }

        public Guid? Supplier_Id { get; set; }

        public bool IsActivated { get; set; }

        public bool IsDeleted { get; set; }

        public int Type { get; set; }

        public Guid? SourceInvoice_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryDocument> InventoryDocuments1 { get; set; }

        public virtual InventoryDocument InventoryDocument1 { get; set; }

        public virtual Storage Storage { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryItemBas> InventoryItemBases { get; set; }
    }
}
