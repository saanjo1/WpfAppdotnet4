namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public bool IsRead { get; set; }

        public int Type { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public Guid? From_Id { get; set; }

        public Guid? To_Id { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
