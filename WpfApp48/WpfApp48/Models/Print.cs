namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Print
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public string Type { get; set; }

        public DateTime Created { get; set; }
    }
}
