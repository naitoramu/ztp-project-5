using Eshop.Application.Configuration.Commands;
using Eshop.Application.Shared;

namespace Eshop.Application.Orders.CustomerOrder.Commands
{
    public class AddOrderFromCustomerCartCommand : CommandBase<Guid>
    {
        public Guid CustomerId { get; }

        public AddOrderFromCustomerCartCommand(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
