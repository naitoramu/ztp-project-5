using Eshop.Domain.Carts.Events;
using MediatR;

internal class CartUpdateEventHandler : INotificationHandler<CartUpdatedEvent>
{
    public Task Handle(CartUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}