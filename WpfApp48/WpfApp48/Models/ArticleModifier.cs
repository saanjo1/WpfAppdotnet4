namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ArticleModifier
    {
        public Guid Id { get; set; }

        public Guid? Modifier_Id { get; set; }

        public Guid? Article_Id { get; set; }
    }
}
