namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EInvoiceOrderFormFile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EInvoiceOrderFormFile()
        {
            EInvoices = new HashSet<EInvoice>();
        }

        public Guid Id { get; set; }

        [Column(TypeName = "image")]
        public byte[] GZippedContents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EInvoice> EInvoices { get; set; }
    }
}
