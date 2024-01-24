using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProfitTest.Application.Commands;
using ProfitTest.Application.DTOs;
using ProfitTest.Application.Queries;
using ProfitTest.Core.Models;

namespace ProfitTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        [ProducesDefaultResponseType(typeof(List<ProductResponseDTO>))]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            return Ok(await _mediator.Send(new GetProductsQuery(), token).ConfigureAwait(false));
        }

        [HttpGet("{productId}")]
        [ProducesDefaultResponseType(typeof(ProductResponseDTO))]
        public async Task<IActionResult> Get([FromRoute] Guid productId, CancellationToken token)
        {
            var result = await _mediator.Send(new GetProductQuery(productId), token).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("Create")]
        [ProducesDefaultResponseType(typeof(ModifyProductResponseDTO))]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand product, CancellationToken token)
        {
            ModifyProductResponseDTO response = new();

            if (!ModelState.IsValid)
            {
                response.Errors = new(
                    ModelState
                        .Where(item => item.Value?.ValidationState == ModelValidationState.Invalid)
                        .Select(item =>
                        (
                            item.Key,
                            item.Value!.Errors.Select(err => err.ErrorMessage).ToList()
                        ))
                        .ToDictionary()
                );

                //foreach (var item in ModelState)
                //{
                //    if (item.Value.ValidationState == ModelValidationState.Invalid)
                //    {
                //        response.Errors.Add(item.Key, item.Value.Errors.Select(err => err.ErrorMessage).ToList());
                //    }
                //}

                return BadRequest(response);
            }

            response.ProductId = await _mediator.Send(product, token).ConfigureAwait(false);

            if (response.ProductId == Guid.Empty)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPut("Update")]
        [ProducesDefaultResponseType(typeof(ModifyProductResponseDTO))]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand product, CancellationToken token)
        {
            ModifyProductResponseDTO response = new();

            if (!ModelState.IsValid)
            {
                response.Errors = new(
                    ModelState
                        .Where(item => item.Value?.ValidationState == ModelValidationState.Invalid)
                        .Select(item =>
                        (
                            item.Key,
                            item.Value!.Errors.Select(err => err.ErrorMessage).ToList()
                        ))
                        .ToDictionary()
                );

                return BadRequest(response);
            }

            response.ProductId = await _mediator.Send(product, token).ConfigureAwait(false);

            if (response.ProductId == Guid.Empty)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid productId, CancellationToken token)
        {
            var res = _mediator.Send(new DeleteProductCommand(productId), token).ConfigureAwait(false);

            if (await res)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("FindAll")]
        [ProducesDefaultResponseType(typeof(List<ProductResponseDTO>))]
        public async Task<IActionResult> FindAllByTitle([FromQuery] string title, CancellationToken token)
        {
            return Ok(await _mediator.Send(new FindProductsByTitleQuery(title), token).ConfigureAwait(false));
        }

        [HttpGet("Find")]
        [ProducesDefaultResponseType(typeof(ProductResponseDTO))]
        public async Task<IActionResult> FindFirstByTitle([FromQuery] string title, CancellationToken token)
        {
            return Ok(await _mediator.Send(new FindProductByTitleQuery(title), token).ConfigureAwait(false));
        }
    }
}
