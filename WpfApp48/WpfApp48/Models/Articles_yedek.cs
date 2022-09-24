namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Articles_yedek
    {
        [Key]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Deleted { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArticleNumber { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Price { get; set; }

        public Guid? SubCategory_Id { get; set; }

        public string BarCode { get; set; }

        public string Code { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal ReturnFee { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FreeModifiers { get; set; }
    }
}
