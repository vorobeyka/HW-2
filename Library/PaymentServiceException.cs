using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class PaymentServiceException : Exception
    {
        public PaymentServiceException(string message) : base(message)
        {
        }

        public PaymentServiceException()
        {
        }
    }
}
