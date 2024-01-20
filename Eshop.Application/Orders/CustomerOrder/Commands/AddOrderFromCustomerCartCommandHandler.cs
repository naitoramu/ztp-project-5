using AutoMapper;
using Eshop.Application.Configuration.Commands;
using Eshop.Domain.Carts;
using Eshop.Domain.Orders;
using Eshop.Domain.SeedWork;

namespace Eshop.Application.Orders.CustomerOrder.Commands
{
    public class AddOrderCommandFromCustomerCartCommandHandler : ICommandHandler<AddOrderFromCustomerCartCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddOrderCommandFromCustomerCartCommandHandler(
            IOrderRepository orderRepository, 
            ICartRepository cartRepository, 
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Guid> Handle(AddOrderFromCustomerCartCommand request, CancellationToken cancellationToken)
        {         
            var order = Order.Create(
                await _cartRepository.GetByCustomerIdAsync(request.CustomerId)
            );

            _orderRepository.Add(order);
            _cartRepository.Update(Cart.Empty(request.CustomerId));

            await _unitOfWork.CommitAsync(cancellationToken);

            return order.Id;
        }
    }
}
