using Eshop.Application.Configuration.Queries;
using Eshop.Application.Shared;

namespace Eshop.Application.Customers.Queries
{
    public class GetCustomerQuery : IQuery<CustomerDto>
    {
        public Guid CustomerId { get; }

        public GetCustomerQuery(
            Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}