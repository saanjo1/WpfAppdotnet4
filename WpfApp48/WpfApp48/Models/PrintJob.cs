namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PrintJob
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}
