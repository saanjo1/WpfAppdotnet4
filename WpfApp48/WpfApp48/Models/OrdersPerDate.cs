namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdersPerDate")]
    public partial class OrdersPerDate
    {
        [Key]
        public DateTime Date { get; set; }

        public int NumberOfOrders { get; set; }
    }
}
