using Eshop.Domain.Customers.Events;
using MediatR;

internal class CustomerCreatedEventHandler : INotificationHandler<CustomerCreatedEvent>
{
    public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}