using Eshop.Domain.Customers;
using Eshop.Infrastructure.Database;
using Eshop.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Eshop.Infrastructure.Repositories
{
    internal class CustomerRepository : ICustomerRepository 
    {
        private readonly CustomersContext _context;
        private readonly IEntityTracker _entityTracker;

        public CustomerRepository(CustomersContext context, IEntityTracker entityTracker)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entityTracker = entityTracker ?? throw new ArgumentNullException(nameof(entityTracker));
        }

        public void Add(Customer customer)
        {
            _entityTracker.TrackEntity(customer);
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var customer = await _context.Customers
                .Find(c => c.Id == id)
                .FirstOrDefaultAsync() ?? throw new CustomerNotExistsException(id);
                
            _entityTracker.TrackEntity(customer);

            return customer;
        }
    }
}