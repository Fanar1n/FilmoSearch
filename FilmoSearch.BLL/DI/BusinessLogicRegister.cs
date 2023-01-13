using FilmoSearch.BLL.Interfaces;
using FilmoSearch.BLL.Services;
using FilmoSearch.DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmoSearch.BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IFilmService, FilmService>();
            serviceCollection.AddScoped<IActorService, ActorService>();
            serviceCollection.AddScoped<IReviewService, ReviewService>();
            serviceCollection.AddScoped<IActorFilmsService, ActorFilmsService>();
            serviceCollection.AddDataAccess(configuration);
        }
    }
}
