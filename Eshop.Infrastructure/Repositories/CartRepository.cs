
using Eshop.Domain.Carts;
using Eshop.Infrastructure.Database;
using Eshop.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Eshop.Infrastructure.Repositories
{
    internal class CartRepository : ICartRepository 
    {
        private readonly CartsContext _context;
        private readonly IEntityTracker _entityTracker;

        public CartRepository(CartsContext context, IEntityTracker entityTracker)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entityTracker = entityTracker ?? throw new ArgumentNullException(nameof(entityTracker));
        }

        public void Update(Cart cart)
        {
            _entityTracker.TrackEntity(cart);
        }

        public async Task<Cart> GetByCustomerIdAsync(Guid customerId)
        {
            var cart = await _context.Carts
                .Find(c => c.CustomerId == customerId)
                .FirstOrDefaultAsync() ?? Cart.Empty(customerId);
                
            _entityTracker.TrackEntity(cart);

            return cart;
        }
    }
}