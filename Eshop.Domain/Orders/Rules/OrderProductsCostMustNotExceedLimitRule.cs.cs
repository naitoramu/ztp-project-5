using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders.Rules
{
    public class OrderProductsCostMustNotExceedLimitRule : IBusinessRule
    {
        private static readonly int MAX_COST = 15000;
        private readonly List<OrderProduct> _orderProducts;

        public OrderProductsCostMustNotExceedLimitRule(List<OrderProduct> orderProducts)
        {
            _orderProducts = orderProducts;
        }

        public bool IsBroken() {
            decimal totalCost = 0;

            foreach(var product in _orderProducts) {
                totalCost += product.TotalCost;
            }

            return totalCost > MAX_COST;
        }

        public string Message => "The total cost of the products in a single order cannot be greater than " + MAX_COST;
    }
}