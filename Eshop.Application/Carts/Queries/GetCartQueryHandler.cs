using AutoMapper;
using Eshop.Application.Carts.Queries;
using Eshop.Application.Configuration.Queries;
using Eshop.Application.Shared;
using Eshop.Domain.Carts;

namespace Eshop.Application.Orders.CustomerOrder.Queries
{
    public class GetCartQueryHandler : IQueryHandler<GetCartQuery, CartDto>
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;

        public GetCartQueryHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CartDto> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetByCustomerIdAsync(request.CustomerId);
            return _mapper.Map<CartDto>(cart);
        }
    }
}