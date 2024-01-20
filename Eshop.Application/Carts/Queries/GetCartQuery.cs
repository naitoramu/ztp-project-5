using Eshop.Application.Configuration.Queries;
using Eshop.Application.Shared;

namespace Eshop.Application.Carts.Queries
{
    public class GetCartQuery : IQuery<CartDto>
    {
        public Guid CustomerId { get; }

        public GetCartQuery(
            Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}