using MicroData.Base.UI.Shared.Api;
using MicroData.Identity.Data;
using MicroData.Identity.UI.Shared.App.Mapper;
using MicroData.Identity.UI.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MicroData.Identity.UI.Shared.App.Helper
{
    public static class DependencyInjectionHellper
    {
        public static string IdentityConnectionString { get; set; } = string.Empty;

        public static void ConfigureService(IServiceCollection services)
        {
            RegisterUiServices(services);
        }

        public static void RegisterUiServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>
                    (options => options.UseSqlServer(IdentityConnectionString));

            MicroData.Identity.IoC.DependencyContainer.RegisterServices(services);

            services.AddScoped<ICompanyApi, CompanyApp>();
            services.AddScoped<IAuthorizeApi, AuthrizeApp>();
            services.AddScoped<IUserApi, UserApp>();
            services.AddScoped<ITenantApi, TenantApp>();

            RegisterAutoMapper(services);
        }

        public static void RegisterAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();
        }

    }
}
