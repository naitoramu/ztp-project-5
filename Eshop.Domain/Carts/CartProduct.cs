using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Carts
{
    public class CartProduct : ValueObject
    {
        public Guid ProductId { get; private set; }

        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        private CartProduct() {}

        private CartProduct(Guid productId, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public static CartProduct Create(
          Guid productId,
          int quantity, 
          decimal unitPrice)
        {
            return new CartProduct(productId, quantity, unitPrice);
        }
    }
}