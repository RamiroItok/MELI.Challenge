using MELI.Challenge.Application.Abstractions;
using MELI.Challenge.Application.DTOs;
using MELI.Challenge.Application.Shared;
using MELI.Challenge.Domain.Repositories;

namespace MELI.Challenge.Application.Queries
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdRequest, BaseResponse<ItemResponseDTO>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly ISellerRepository _sellerRepository;
        private readonly IReviewRepository _reviewRepository;

        public GetItemByIdQueryHandler(IItemRepository itemRepository, 
                                        ISellerRepository sellerRepository,
                                        IReviewRepository reviewRepository)
        {
            _itemRepository = itemRepository;
            _sellerRepository = sellerRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<BaseResponse<ItemResponseDTO>> Handle(GetItemByIdRequest query, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetByIdAsync(query.Id, cancellationToken);

            if (item is null)
                return BaseResponse<ItemResponseDTO>.Failure("Product do not exist");

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
    }
}