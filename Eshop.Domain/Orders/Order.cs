using Eshop.Domain.Carts;
using Eshop.Domain.Orders.Events;
using Eshop.Domain.Orders.Rules;
using Eshop.Domain.Products;
using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }

        public Guid CustomerId { get; private set; }

        public List<OrderProduct> Products { get; private set; }

        private Order(Guid customerId, List<OrderProduct> orderProducts)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Products = orderProducts ?? throw new ArgumentNullException(nameof(orderProducts));

            AddDomainEvent(new OrderAddedEvent(Id, customerId));
        }

        public static Order Create(Cart cart)
        {
            List<OrderProduct> orderProducts = new();

            foreach (var cartProduct in cart.Products)
            {
                orderProducts.Add(OrderProduct.Create(
                    cartProduct.ProductId, 
                    cartProduct.Quantity, 
                    cartProduct.UnitPrice
                ));
            }

            CheckRule(new OrderMustHaveAtLeastOneProductRule(orderProducts));
            CheckRule(new OrderProductsCostMustNotExceedLimitRule(orderProducts));

            return new Order(cart.CustomerId, orderProducts);
        }
    }
}
