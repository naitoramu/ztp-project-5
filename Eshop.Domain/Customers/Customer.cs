using Eshop.Domain.Customers.Events;
using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; } 

        public string Name { get; private set; }    
        
        public static Customer Create(string name)
        {
            return new(Guid.NewGuid(), name);
        }

        private Customer(Guid id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));

            AddDomainEvent(new CustomerCreatedEvent(Id));
        }
    }
}
