using System;

namespace Phoenix.Domain
{
    public sealed class OrderState
    {
        public OrderState()
        {

        }

        public string Description { get; private set; }
    }
}