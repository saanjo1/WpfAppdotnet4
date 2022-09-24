namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        public Guid Id { get; set; }

        public int Order { get; set; }

        public string Printer { get; set; }

        public string Name { get; set; }

        public bool Deleted { get; set; }

        public Guid? Storage_Id { get; set; }

        public string ExtraPrinter1 { get; set; }

        public string ExtraPrinter2 { get; set; }

        public virtual Storage Storage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
