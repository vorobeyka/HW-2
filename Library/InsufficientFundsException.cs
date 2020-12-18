using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }
}
