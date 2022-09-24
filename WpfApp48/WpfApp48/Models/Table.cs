namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Table()
        {
            Invoices = new HashSet<Invoice>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Rotation { get; set; }

        public int Type { get; set; }

        public int State { get; set; }

        public bool Deleted { get; set; }

        public Guid? Waiter_Id { get; set; }

        public Guid? Sector_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual Sector Sector { get; set; }

        public virtual User User { get; set; }
    }
}
