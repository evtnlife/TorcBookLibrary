using TorcBookLibrary.Domain.Repositories;
using TorcBookLibrary.Infra.Repositories;
using TorcBookLibrary.Services;
using TorcBookLibrary.Services.Interfaces;

namespace TorcBookLibrary.Api.Common
{
    public static class DependencyInjection
    {
        public static void Configure(IServiceCollection services)
        {
            // repositories
            services.AddScoped<IBookRepository, BookRepository>();

            // services
            services.AddScoped<IBookService, BookService>();

        }
    }
}
