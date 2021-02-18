using PaymentProcessorFiled.Domains.Abstract;
using PaymentProcessorFiled.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentProcessorFiled.Domains
{
    public class Payment : Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [CreditCard]
        [CreditCardWithLuhn]
        [StringLength(maximumLength: 20)]
        public string CreditCardNumber { get; set; }
        [Required]
        [StringLength(maximumLength: 70)]
        public string CardHolder { get; set; }
        [Required]
        [ExpirationDate]
        public DateTime ExpirationDate { get; set; }
        [StringLength(maximumLength: 3)]
        public string SecurityCode { get; set; }
        [Required]
        [PaymentAmount]
        public decimal Amount { get; set; }
        [ForeignKey(nameof(PaymentStateId))]
        public PaymentState PaymentState { get; set; }
        public string PaymentStateId { get; set; }

    }
}
