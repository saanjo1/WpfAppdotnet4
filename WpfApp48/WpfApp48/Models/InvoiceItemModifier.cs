namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InvoiceItemModifier
    {
        public Guid Id { get; set; }

        public decimal PriceWithoutDiscount { get; set; }

        public Guid? Modifier_Id { get; set; }

        public Guid? InvoiceItem_Id { get; set; }

        public virtual InvoiceItem InvoiceItem { get; set; }
    }
}
