using System.Text.RegularExpressions;
using Eshop.Domain.SeedWork;

namespace Eshop.Domain.Orders.Rules
{
    public class CustomerNameMustBeValidAlphabeticStringRule : IBusinessRule
    {
        private static readonly string CUSTOMER_NAME_PATTERN = "^[A-Za-z]+$";
        private readonly string _customerName;

        public CustomerNameMustBeValidAlphabeticStringRule(string customerName)
        {
            _customerName = customerName;
        }

        public bool IsBroken() => !Regex.IsMatch(_customerName, CUSTOMER_NAME_PATTERN);

        public string Message => "Customer Name cannot be empty and can only contains alhpabetic characters";
    }
}