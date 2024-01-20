using AutoMapper;
using Eshop.Application.Configuration.Commands;
using Eshop.Domain.Customers;
using Eshop.Domain.Carts;
using Eshop.Domain.SeedWork;
using Eshop.Domain.Orders;
using Eshop.Application.Shared;

namespace Eshop.Application.Carts.Commands
{
    public class UpdateCartCommandHandler : ICommandHandler<UpdateCartCommand, CartDto>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductPriceDataApi _productPriceDataApi;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCartCommandHandler(
            ICartRepository cartRepository, 
            IProductPriceDataApi productPriceDataApi, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _productPriceDataApi = productPriceDataApi ?? throw new ArgumentNullException(nameof(productPriceDataApi));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<CartDto> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {         
            var productsData = await _productPriceDataApi.Get();
            var cart = Cart.Create(
                request.CustomerId,
                request.Products.Select(_mapper.Map<CartProduct>).ToList(),
                productsData
            );

            _cartRepository.Update(cart);

            await _unitOfWork.CommitAsync(cancellationToken);

            return _mapper.Map<CartDto>(cart);
        }
    }
}
