namespace Eshop.Application.Shared
{
    public class CartDto 
    {
        public List<ProductDto> Products { get; }

        private CartDto()
        {
            Products = new List<ProductDto>();
        }

        public CartDto(List<ProductDto> products)
        {
            Products = products ?? throw new ArgumentNullException(nameof(products));
        }
    }
}
