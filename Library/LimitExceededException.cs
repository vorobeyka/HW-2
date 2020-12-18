using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class LimitExceededException : Exception
    {
        public LimitExceededException(string message) : base(message)
        {
        }
    }
}
