namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            ArticleGoods = new HashSet<ArticleGood>();
            InventoryItemBases = new HashSet<InventoryItemBas>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? Unit_Id { get; set; }

        public decimal LatestPrice { get; set; }

        public decimal? Volumen { get; set; }

        public decimal? Refuse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArticleGood> ArticleGoods { get; set; }

        public virtual MeasureUnit MeasureUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryItemBas> InventoryItemBases { get; set; }
    }
}
