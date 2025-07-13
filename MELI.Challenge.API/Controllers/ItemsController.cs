using MELI.Challenge.Application.Abstractions;
using MELI.Challenge.Application.DTOs;
using MELI.Challenge.Application.Queries;
using MELI.Challenge.Application.Shared;
using MELI.Challenge.Application.Shared.Enum;
using Microsoft.AspNetCore.Mvc;

namespace MELI.Challenge.API.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly IRequestHandler<GetItemByIdRequest, BaseResponse<ItemResponseDTO>> _getItemByIdHandler;

        public ItemsController(IRequestHandler<GetItemByIdRequest, BaseResponse<ItemResponseDTO>> getItemByIdHandler)
        {
            _getItemByIdHandler = getItemByIdHandler;
        }

        /// <summary>
        /// Obtiene los detalles completos de un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto en Mercado Libre (ej: MELI-00001).</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Los detalles completos del producto, incluyendo vendedor y opiniones.</returns>
        /// <response code="200">Devuelve el producto solicitado.</response>
        /// <response code="404">Si el producto con el ID especificado no se encuentra.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResponse<ItemResponseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItemById([FromRoute] GetItemByIdRequest request, CancellationToken cancellationToken)
        {
            //var request = new GetItemByIdRequest(id);
            var response = await _getItemByIdHandler.Handle(request, cancellationToken);

            if (response.IsSuccess)
                return Ok(response);

            return response.ErrorType switch
            {
                ErrorType.NotFound => NotFound(response),
                ErrorType.Validation => BadRequest(response),
                _ => StatusCode(500, response)
            };
        }
    }
}
