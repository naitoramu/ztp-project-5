using Eshop.Application.Shared;

namespace Eshop.API.Controllers
{
    public class ProuctListRequest
    {
        public List<ProductDto> Products { get; set; }

        public ProuctListRequest(List<ProductDto> products)
        {
            Products = products ?? throw new ArgumentNullException(nameof(products));
        }
    }
}
