using MELI.Challenge.Domain.Repositories;
using MELI.Challenge.Infraestructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace MELI.Challenge.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddSingleton<IItemRepository, ItemRepository>();
            services.AddSingleton<ISellerRepository, SellerRepository>();
            services.AddSingleton<IReviewRepository, ReviewRepository>();

            return services;
        }
    }
}
