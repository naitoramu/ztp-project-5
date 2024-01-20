using Eshop.Domain.Carts.Events;
using Eshop.Domain.Products;
using Eshop.Domain.SeedWork;
using MongoDB.Bson.Serialization.Attributes;

namespace Eshop.Domain.Carts
{
    [BsonIgnoreExtraElements]
    public class Cart : Entity, IAggregateRoot
    {
        public Guid CustomerId { get; private set; }

        public List<CartProduct> Products { get; private set; }

        private Cart(Guid customerId, List<CartProduct> orderProducts)
        {
            CustomerId = customerId;
            Products = orderProducts ?? throw new ArgumentNullException(nameof(orderProducts));

            AddDomainEvent(new CartUpdatedEvent(customerId));
        }

        public static Cart Create(
            Guid customerId,
            List<CartProduct> products,
            List<ProductPriceData> allProductPriceDatas)
        {
            List<CartProduct> cartProducts = new();

            foreach (var product in products)
            {
                var productPriceData = allProductPriceDatas.First(x => x.ProductId == product.ProductId) 
                ?? throw new ArgumentException("Product with ID=" + product.ProductId + "does not exists.");

                cartProducts.Add(CartProduct.Create(product.ProductId, product.Quantity, productPriceData.UnitPrice));
            }

            return new Cart(customerId, products);
        }

        public static Cart Empty(Guid customerId)
        {
            return new(customerId, new List<CartProduct>());
        }
    }
}