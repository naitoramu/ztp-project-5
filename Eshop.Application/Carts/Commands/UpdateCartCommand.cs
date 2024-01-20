using Eshop.Application.Configuration.Commands;
using Eshop.Application.Shared;
using Eshop.Domain.Carts;

namespace Eshop.Application.Carts.Commands
{
    public class UpdateCartCommand : CommandBase<CartDto>
    {
        public Guid CustomerId { get; }

        public List<ProductDto> Products { get; }

        public UpdateCartCommand(
            Guid customerId,
            List<ProductDto> products)
        {
            CustomerId = customerId != Guid.Empty ? customerId : throw new ArgumentException(nameof(customerId));
            Products = products ?? throw new ArgumentNullException(nameof(products));
        }
    }
}
