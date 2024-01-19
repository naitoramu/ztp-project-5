using Eshop.Application.Configuration.Commands;
using Eshop.Application.Shared;

namespace Eshop.Application.Customers.Commands
{
    public class CreateCustomerCommand : CommandBase<Guid>
    {
        public string Name { get; }

        public CreateCustomerCommand(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
