using PaymentProcessorFiled.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentProcessorFiled.Domains
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

    }
}
