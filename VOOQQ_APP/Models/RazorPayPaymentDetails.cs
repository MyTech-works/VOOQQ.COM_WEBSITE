using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Models
{
    public class RazorPayPaymentDetails
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long RecordId { get; set; }
        [StringLength(25)]
        public string PaymentType { get; set; }
        [StringLength(75)]

        public string PaymentId { get; set; }
        [StringLength(25)]
        public string Entity { get; set; }
        public double Amount { get; set; }
        [StringLength(10)]

        public string Currency { get; set; }
        [StringLength(15)]

        public string Status { get; set; }
        [StringLength(75)]

        public string OrderId { get; set; }
        [StringLength(75)]
        public string InvoiceId { get; set; }
        public bool? International { get; set; }
        [StringLength(35)]
        public string Method { get; set; }

        public double? AmountRefunded { get; set; }
        [StringLength(25)]

        public string RefundStatus { get; set; }
        [StringLength(25)]

        public string Captured { get; set; }
        [StringLength(250)]

        public string Description { get; set; }
        [StringLength(35)]

        public string CardId { get; set; }
        [StringLength(55)]

        public string Bank { get; set; }
        [StringLength(35)]

        public string Wallet { get; set; }
        [StringLength(35)]

        public string Vpa { get; set; }
        [StringLength(35)]

        public string Email { get; set; }
        [StringLength(25)]

        public string Contact { get; set; }
        [StringLength(45)]

        public string MerchantOrderId { get; set; }

        public decimal? Fee { get; set; }
        public decimal? ServiceTax { get; set; }

        public DateTime? PaymentDate { get; set; }
        [StringLength(50)]
        public string RefundId { get; set; }
        public DateTime? RefundDate { get; set; }
        [StringLength(50)]
        public string RazorpayOrderId { get; set; }
        [StringLength(50)]
        public string Signature { get; set; }

    }
}