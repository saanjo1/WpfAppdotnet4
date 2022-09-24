namespace WpfApp48
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EInvoice
    {
        [Key]
        public Guid InvoiceId { get; set; }

        public int Status_Code { get; set; }

        public DateTime Status_Timestamp { get; set; }

        public string Status_Note { get; set; }

        public string Note { get; set; }

        [Required]
        public string SenderBankAccountNumber { get; set; }

        public Guid? SenderId { get; set; }

        public Guid? ReceiverId { get; set; }

        public Guid? OrderFormFileId { get; set; }

        public bool IsStationVat { get; set; }

        [Required]
        public string WaiterName { get; set; }

        public string OrderFormReference { get; set; }

        public string OrderFormFileName { get; set; }

        public int? PaymentDue { get; set; }

        public string PaymentIdModel { get; set; }

        public string PaymentIdReferenceNumber { get; set; }

        public string PaymentTerms { get; set; }

        [Required]
        [StringLength(3)]
        public string RegisterId { get; set; }

        public virtual EInvoiceOrderFormFile EInvoiceOrderFormFile { get; set; }

        public virtual EInvoiceParty EInvoiceParty { get; set; }

        public virtual EInvoiceParty EInvoiceParty1 { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
