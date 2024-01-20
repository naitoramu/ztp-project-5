using AutoMapper;
using Eshop.Application.Carts.Commands;
using Eshop.Application.Carts.Queries;
using Eshop.Application.Customers.Commands;
using Eshop.Application.Customers.Queries;
using Eshop.Application.Orders.CustomerOrder.Commands;
using Eshop.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Eshop.API.Controllers
{
    [Route(ROUTE_PATH)]
    [ApiController]
    public class CustomerController : Controller
    {
    private const string ROUTE_PATH = "api/v1/customers";
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="request">Customer details</param>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateCustomer(
            [FromBody] CustomerDto request)
        {
            Guid response = await _mediator.Send(new CreateCustomerCommand(request.Name));
            return Created(ROUTE_PATH + '/' + response, response);
        }

        /// <summary>
        /// Retrieve customer.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        [Route("{customerId}")]
        [HttpGet]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerDetails([FromRoute] Guid customerId)
        {
            var customerDetails = await _mediator.Send(new GetCustomerQuery(customerId));
            return Ok(customerDetails);
        }

        /// <summary>
        /// Adds a new order for a specified customer.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="request">List of products.</param>
        [Route("{customerId}/orders")]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCustomerOrder(
            [FromRoute] Guid customerId,
            [FromBody] ProuctListRequest request)
        {
            var response = await _mediator.Send(new AddOrderCommand(customerId, request.Products));
            return Created(string.Empty, response);
        }


        /// <summary>
        /// Adds a new order from a customer cart.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        [Route("{customerId}/orders/from-cart")]
        [HttpPost]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCustomerOrder(
            [FromRoute] Guid customerId)
        {
            var response = await _mediator.Send(new AddOrderFromCustomerCartCommand(customerId));
            return Created(string.Empty, response);
        }

        /// <summary>
        /// Updates cart for a specified customer.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        /// <param name="request">List of products.</param>
        [Route("{customerId}/cart")]
        [HttpPut]
        [ProducesResponseType(typeof(CartDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> UpdateCustomerCart(
            [FromRoute] Guid customerId,
            [FromBody] ProuctListRequest request)
        {
            var updatedCart = await _mediator.Send(new UpdateCartCommand(
                customerId, 
                request.Products
            ));

            return Ok(updatedCart);
        }

        /// <summary>
        /// Retrieve cart for specific customer.
        /// </summary>
        /// <param name="customerId">Customer ID.</param>
        [Route("{customerId}/cart")]
        [HttpGet]
        [ProducesResponseType(typeof(CartDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerCart([FromRoute] Guid customerId)
        {
            var customerCart = await _mediator.Send(new GetCartQuery(customerId));
            return Ok(customerCart);
        }

    }
}
