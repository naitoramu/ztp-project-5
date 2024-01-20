namespace Eshop.Infrastructure.Exceptions
{
    public class ProductNotExistsException : Exception
    {
        public Guid Id { get; }

        public ProductNotExistsException(Guid id)
        {
            Id = id;
        }
    }
}