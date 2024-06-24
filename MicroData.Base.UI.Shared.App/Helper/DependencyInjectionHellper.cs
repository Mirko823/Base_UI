using MicroData.Base.Data;
using MicroData.Base.UI.Shared.Api;
using MicroData.Base.UI.Shared.App.Mapper;
using MicroData.Base.UI.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MicroData.Base.UI.Shared.App.Helper
{
    public static class DependencyInjectionHellper
    {
        public static string BaseConnectionString { get; set; } = string.Empty;

        public static void ConfigureService(IServiceCollection services)
        {
            RegisterUiServices(services);
        }

        public static void RegisterUiServices(IServiceCollection services)
        {
            services.AddDbContext<BaseContext>
                    (options => options.UseSqlServer(BaseConnectionString));

            MicroData.Base.IoC.DependencyContainer.RegisterServices(services);

            services.AddScoped<IBusinessPartnerApi, BusinessPartnerApp>();
            services.AddScoped<IEmployeeApi, EmployeeApp>();
            services.AddScoped<IProductCatalogApi, ProductCatalogApp>();
            services.AddScoped<IProductCategoryApi, ProductCategoryApp>();

            services.AddScoped<IGrainCatalogApi, GrainCatalogApp>();

            services.AddScoped<ILocationApi, LocationApp>();
            services.AddScoped<IShipperApi, ShipperApp>();


            services.AddScoped<ITaxApi, TaxApp>();
            
            services.AddScoped<IUnitApi, UnitApp>();
            services.AddScoped<IWarehouseApi, WarehouseApp>();

            services.AddScoped<ILookupBaseApi, LookupBaseApp>();

            RegisterAutoMapper(services);
        }

        public static void RegisterAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();
        }

    }
}
