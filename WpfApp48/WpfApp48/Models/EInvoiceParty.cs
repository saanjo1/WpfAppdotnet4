namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EInvoiceParty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EInvoiceParty()
        {
            EInvoices = new HashSet<EInvoice>();
            EInvoices1 = new HashSet<EInvoice>();
        }

        public Guid Id { get; set; }

        [Required]
        public string RegistrationName { get; set; }

        [Required]
        [StringLength(11)]
        public string CompanyId { get; set; }

        public string EndpointId { get; set; }

        public string EndpointIdSchemeId { get; set; }

        public string PartyIdentificationId { get; set; }

        public string BusinessBranchName { get; set; }

        public string PostalAddress_StreetName { get; set; }

        public string PostalAddress_CityName { get; set; }

        public string PostalAddress_PostalCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EInvoice> EInvoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EInvoice> EInvoices1 { get; set; }
    }
}
