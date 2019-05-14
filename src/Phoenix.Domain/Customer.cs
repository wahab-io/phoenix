using System;

namespace Phoenix.Domain
{
    public sealed class Customer
    {
        public Customer()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}