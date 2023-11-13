using VSMDivine.Application.Interfaces;
using VSMDivine.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace VSMDivine.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
