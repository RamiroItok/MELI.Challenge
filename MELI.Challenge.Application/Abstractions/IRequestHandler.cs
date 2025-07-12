using MELI.Challenge.Application.DTOs;
using MELI.Challenge.Application.Queries;
using MELI.Challenge.Application.Shared;

namespace MELI.Challenge.Application.Abstractions
{
    public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<BaseResponse<ItemResponseDTO>> Handle(GetItemByIdRequest query, CancellationToken cancellationToken);
    }
}
