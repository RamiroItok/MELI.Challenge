using MELI.Challenge.Application.Abstractions;
using MELI.Challenge.Application.DTOs;
using MELI.Challenge.Application.Shared;
using MELI.Challenge.Application.Shared.Enum;
using MELI.Challenge.Domain.Repositories;
using MELI.Challenge.Domain.Shared;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MELI.Challenge.Application.Queries
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdRequest, BaseResponse<ItemResponseDTO>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly ISellerRepository _sellerRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly ILogger<GetItemByIdQueryHandler> _logger;

        public GetItemByIdQueryHandler(IItemRepository itemRepository, 
                                        ISellerRepository sellerRepository,
                                        IReviewRepository reviewRepository,
                                        ILogger<GetItemByIdQueryHandler> logger)
        {
            _itemRepository = itemRepository;
            _sellerRepository = sellerRepository;
            _reviewRepository = reviewRepository;
            _logger = logger;
        }

        public async Task<BaseResponse<ItemResponseDTO>> Handle(GetItemByIdRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Id))
                return BaseResponse<ItemResponseDTO>.Failure(ItemsErrors.IdCannotBeNull, ErrorType.Validation);

            try
            {
                var item = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);

                if (item is null)
                    return BaseResponse<ItemResponseDTO>.Failure(ItemsErrors.ProductDoNotExist, ErrorType.NotFound);

                var sellerInfo = await _sellerRepository.GetByIdAsync(item.SellerId, cancellationToken);

                var reviews = await _reviewRepository.GetByItemIdAsync(item.Id, cancellationToken);

                var responseDTO = new ItemResponseDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Price = item.Price.Amount,
                    Currency = item.Price.Currency.ToString(),
                    Pictures = item.Pictures,
                    Condition = item.Condition.ToString(),
                    FreeShipping = item.FreeShipping,
                    Description = item.Description,
                    Seller = sellerInfo is null ? null : new SellerInfoResponseDTO
                    {
                        Nickname = sellerInfo.Nickname,
                        Reputation = sellerInfo.Reputation.ToString(),
                        SellingSince = sellerInfo.SellingSince
                    },
                    Reviews = reviews.Select(r => new ReviewResponseDTO
                    {
                        Rating = r.Rating,
                        Title = r.Title,
                        Content = r.Content,
                        DateCreated = r.DateCreated
                    }).ToList()
                };

                return BaseResponse<ItemResponseDTO>.Success(responseDTO);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "El formato de uno de los archivos JSON es inválido.");

                return BaseResponse<ItemResponseDTO>.Failure(SharedErrors.DataProcessing, ErrorType.Validation);
            }
        }
    }
}