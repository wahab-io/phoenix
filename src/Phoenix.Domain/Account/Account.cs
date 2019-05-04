using System;
using System.Collections.Generic;
using Phoenix.Core;

namespace Phoenix.Domain
{
    public sealed class Account : IEntity
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
            CreatedOn = DateTime.UtcNow;
        }

        public long Id { get; }
        private ICollection<Transaction> Transactions { get; }
        public DateTime CreatedOn { get; private set; }
        public float Balance
        {
            get
            {
                float total = 0.0F;
                foreach (var transaction in Transactions)
                {
                    total += transaction.CreditAmount;
                    total -= transaction.DebitAmount;
                }
                return total;
            }
        }

        public void CreateTransaction(string naration, float credit, float debit)
        {
            var tranction = new Transaction(naration, credit, debit);
            Transactions.Add(tranction);
        }

        private class Transaction
        {
            public Transaction(string naration, float credit, float debit)
            {
                if (string.IsNullOrEmpty(naration))
                    throw new ArgumentNullException(nameof(naration));
                
                if (credit <= 0)
                    throw new ArgumentOutOfRangeException(nameof(credit));
                
                if (debit <= 0)
                    throw new ArgumentOutOfRangeException(nameof(debit));
                
                CreatedOn = DateTime.UtcNow;
                Naration = naration;
                CreditAmount = credit;
                DebitAmount = debit;
            }

            public DateTime CreatedOn { get; }
            public string Naration { get; }
            public float CreditAmount { get; }
            public float DebitAmount { get; }
            
        }
    }
}