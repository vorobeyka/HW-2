using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public abstract class PaymentMethodBase
    {
        public string Name { get; protected set; }
        protected decimal TransactionLimit { get; set; } 

        protected bool IsOutOfTransactionLimit(decimal amount, string currency)
        {
            ServiceError();
            if (TransactionLimit == -1) return false;
            switch (currency)
            {
                case "USD": return amount * 28.36m > TransactionLimit;
                case "EUR": return amount * 33.63m > TransactionLimit;
                default: return amount > TransactionLimit;
            }
        }

        protected void ServiceError()
        {
            int rndValue = new Random().Next(0, 100);
            if (rndValue < 2) throw new PaymentServiceException();
        }
    }
}
