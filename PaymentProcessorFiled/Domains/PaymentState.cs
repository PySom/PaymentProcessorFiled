using PaymentProcessorFiled.Domains.Abstract;
using PaymentProcessorFiled.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentProcessorFiled.Domains
{
    public class PaymentState : Audit, IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public PayState PayState { get; set; }
        [ForeignKey(nameof(PaymentId))]
        public Payment Payment { get; set; }
        public string PaymentId { get; set; }
    }
}
