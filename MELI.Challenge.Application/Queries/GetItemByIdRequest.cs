using MELI.Challenge.Application.Abstractions;
using MELI.Challenge.Application.DTOs;
using MELI.Challenge.Application.Shared;

namespace MELI.Challenge.Application.Queries
{
    public class GetItemByIdRequest : IRequest<BaseResponse<ItemResponseDTO>>
    {
        public string Id { get; }

        public GetItemByIdRequest(string id)
        {
            Id = id;
        }
    }
}
