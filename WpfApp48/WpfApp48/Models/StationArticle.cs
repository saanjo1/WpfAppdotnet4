namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StationArticle
    {
        [Key]
        [Column(Order = 0)]
        public Guid Station_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid Article_Id { get; set; }

        public virtual Station Station { get; set; }
    }
}
