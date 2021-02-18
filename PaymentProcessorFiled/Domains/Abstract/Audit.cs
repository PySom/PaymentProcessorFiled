using System;

namespace PaymentProcessorFiled.Domains.Abstract
{
    public abstract class Audit
    {
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }
}
