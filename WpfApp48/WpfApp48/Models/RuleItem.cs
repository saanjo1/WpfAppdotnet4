namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RuleItem
    {
        public Guid Id { get; set; }

        public decimal NewPrice { get; set; }

        public Guid? Article_Id { get; set; }

        public Guid? Rule_Id { get; set; }

        public virtual Rule Rule { get; set; }
    }
}
