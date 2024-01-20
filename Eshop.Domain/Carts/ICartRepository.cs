namespace Eshop.Domain.Carts
{
    public interface ICartRepository
    {
        Task<Cart> GetByCustomerIdAsync(Guid customerId);

        void Update(Cart cart);
    }
}