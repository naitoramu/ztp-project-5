using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Carts.Events
{
    public class CartUpdatedEvent : DomainEventBase
    {

        public Guid CustomerId { get; }

        public CartUpdatedEvent(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
