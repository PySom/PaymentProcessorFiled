using System;

namespace PaymentProcessorFiled.Domains.Abstract
{
    public interface IModel
    {
        public string Id { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }
}
