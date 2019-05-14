using System;

namespace Phoenix.Domain
{
    public sealed class Supplier
    {
        public Supplier()
        {

        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}