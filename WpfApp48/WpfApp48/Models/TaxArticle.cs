namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TaxArticle
    {
        [Key]
        [Column(Order = 0)]
        public Guid Tax_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid Article_Id { get; set; }

        public virtual Tax Tax { get; set; }
    }
}
