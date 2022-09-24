namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Invoices = new HashSet<Invoice>();
            Invoices1 = new HashSet<Invoice>();
            Messages = new HashSet<Message>();
            Messages1 = new HashSet<Message>();
            Tables = new HashSet<Table>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool AllowBackoffice { get; set; }

        public bool AllowEdit { get; set; }

        public string Password { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public int UserNumber { get; set; }

        public Guid? Group_Id { get; set; }

        public bool AllowViewInvoices { get; set; }

        public bool AllowEndShift { get; set; }

        public bool AllowAccessToTakenTables { get; set; }

        public string TaxNumber { get; set; }

        public bool IsDeleted { get; set; }

        public bool AllowDiscount { get; set; }

        public bool AllowSettings { get; set; }

        public bool AllowCancelOrderItems { get; set; }

        public bool OnlyMyRevenue { get; set; }

        public bool AllowAccesToStorage { get; set; }

        public bool AllowAccestToReports { get; set; }

        public bool AllowVoidInvoice { get; set; }

        public bool AllowMoveToTable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Table> Tables { get; set; }

        public virtual UserGroup UserGroup { get; set; }
    }
}
