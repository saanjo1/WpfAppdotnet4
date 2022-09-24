namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ArticleGood
    {
        public Guid Id { get; set; }

        public decimal Quantity { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }

        public Guid? Article_Id { get; set; }

        public Guid? Good_Id { get; set; }

        public virtual Good Good { get; set; }
    }
}
