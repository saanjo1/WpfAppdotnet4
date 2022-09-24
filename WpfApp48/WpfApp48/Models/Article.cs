namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Article
    {
        public Guid Id { get; set; }

        public bool Deleted { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }

        public int ArticleNumber { get; set; }

        public int Order { get; set; }

        public decimal Price { get; set; }

        public Guid? SubCategory_Id { get; set; }

        public string BarCode { get; set; }

        public string Code { get; set; }

        public decimal ReturnFee { get; set; }

        public int FreeModifiers { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
