using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Customers.Events
{
    public class CustomerCreatedEvent : DomainEventBase
    {
        public Guid OrderId { get; }

        public CustomerCreatedEvent(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}