using PaymentProcessorFiled.Domains.Abstract;
using PaymentProcessorFiled.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentProcessorFiled.Domains
{
    public class Payment : Audit, IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [CreditCard]
        [StringLength(maximumLength: 20)]
        public string CreditCardNumber { get; set; }
        [Required]
        [StringLength(maximumLength: 70)]
        public string CardHolder { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [StringLength(maximumLength: 3)]
        public string SecurityCode { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [ForeignKey(nameof(PaymentStateId))]
        public PaymentState PaymentState { get; set; }
        public string PaymentStateId { get; set; }

        public override string ToString()
        {
            return PaymentState?.PayState.ToString() ?? base.ToString();
        }
    }

    namespace ViewModel
    {
        public class PaymentViewModel
        {
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
            [StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "The field SecurityCode must be a digit with a total length of 3.")]
            [SecurityCode]
            public string SecurityCode { get; set; }
            [Required]
            [PaymentAmount]
            public decimal Amount { get; set; }
        }
    }

    namespace DTO
    {
        public class PaymentDTO
        {

            public string Id { get; set; }
            public string CreditCardNumber { get; set; }
            public string CardHolder { get; set; }
            public DateTime ExpirationDate { get; set; }
            public string SecurityCode { get; set; }
            public decimal Amount { get; set; }
            public string PaymentState { get; set; }
        }
    }
}
