using System;

namespace Phoenix.Domain
{
    public sealed class Price
    {
        public Price(float amount, string unit)
        {
            Amount = amount;
            Unit = unit;
        }

        public float Amount { get; private set; }
        public string Unit { get; private set; }
    }
}