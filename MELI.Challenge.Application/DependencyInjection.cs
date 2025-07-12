using MELI.Challenge.Application.Abstractions;
using MELI.Challenge.Application.DTOs;
using MELI.Challenge.Application.Queries;
using MELI.Challenge.Application.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace MELI.Challenge.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<GetItemByIdRequest, BaseResponse<ItemResponseDTO>>, GetItemByIdQueryHandler>();

            return services;
        }
    }
}
