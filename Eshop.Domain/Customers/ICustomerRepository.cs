namespace Eshop.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(Guid id);

        void Add(Customer customer);
    }
}
