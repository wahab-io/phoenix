using System;
using System.Collections.Generic;

namespace Phoenix.Domain
{
    public sealed class Leadger
    {
        public Leadger()
        {
            Entries = new HashSet<Entry>();
        }

        public ICollection<Entry> Entries { get; private set; }

        public class Entry
        {
            private Entry(ICollection<CreditEntry> creditEntries, ICollection<DebitEntry> debitEntries)
            {
                if (creditEntries == null)
                    throw new ArgumentNullException(nameof(creditEntries));
                
                if (creditEntries.Count < 1)
                    throw new ArgumentOutOfRangeException(nameof(creditEntries));
                
                if (debitEntries == null)
                    throw new ArgumentNullException(nameof(debitEntries));
                
                if (debitEntries.Count < 1)
                    throw new ArgumentOutOfRangeException(nameof(debitEntries));
                
                CreatedOn = DateTime.UtcNow;
                Credits = creditEntries;
                Debits = debitEntries;
            }

            public DateTime CreatedOn { get; private set; }
            public ICollection<CreditEntry> Credits { get; private set; }
            public ICollection<DebitEntry> Debits { get; private set; }

            public class CreditEntry
            {
                public CreditEntry(Account account, float amount, string description)
                {
                    if (amount <= 0)
                        throw new ArgumentOutOfRangeException(nameof(amount));
                    
                    Account = account;
                    Amount = amount;
                    Description = description;
                }

                public Account Account { get; }
                public float Amount { get; }
                public string Description { get; }
            }
            public class DebitEntry
            {
                public DebitEntry(Account account, float amount, string description)
                {
                    if (account == null)
                        throw new ArgumentNullException(nameof(account));

                    if (amount <= 0)
                        throw new ArgumentOutOfRangeException(nameof(amount));
                    
                    Account = account;
                    Amount = amount;
                    Description = description;
                }

                public Account Account { get; }
                public float Amount { get; }
                public string Description { get; }
            }
        }
    }
}