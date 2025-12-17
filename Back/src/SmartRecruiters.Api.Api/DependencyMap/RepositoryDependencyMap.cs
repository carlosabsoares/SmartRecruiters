using SmartRecruiters.Api.Domain.Repositories;
using SmartRecruiters.Api.Infra.Repositories;

//using SmartRecruiters.Api.Infra.Repositories.Product;

namespace SmartRecruiters.Api.Api.DependencyMap
{
    public static class RepositoryDependencyMap
    {
        public static void RepositoryMap(this IServiceCollection services)
        {
            services.AddScoped<ICudRepository, CudRepository>();
            services.AddScoped<ICreditoRepository, CreditoRepository>();
        }
    }
}