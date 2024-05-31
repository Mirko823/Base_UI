using MicroData.Base.UI.Shared.Api;
using MicroData.Base.UI.Shared.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MicroData.Base.UI.Shared.Helper
{
    public static class DependencyInjectionHellper
    {
        public static void ConfigureService(IServiceCollection services)
        {
            RegisterUiServices(services);
        }

        public static void RegisterUiServices(IServiceCollection services)
        {
            //services.AddScoped<IAuthorizeApi, AuthrizeApi>();

            //services.AddMemoryCache();

            //services.AddScoped<ICityApi, CityApi>();
            //services.AddScoped<ICurrencyApi, CurrencyApi>();
            //services.AddScoped<ITaxApi, TaxApi>();
            services.AddScoped<IUnitApi, UnitApi>();

            //services.AddScoped<IClientApi, ClientApi>();
            //services.AddScoped<IProfessionApi, ProfessionApi>();

            //services.AddScoped<IProductCatalogApi, ProductCatalogApi>();
            //services.AddScoped<IProductCategoryApi, ProductCategoryApi>();
            //services.AddScoped<IServiceCatalogApi, ServiceCatalogApi>();
            //services.AddScoped<IServiceCategoryApi, ServiceCategoryApi>();
            //services.AddScoped<IBusinessPartnerApi, BusinessPartnerApi>();
            //services.AddScoped<IBusinessPartnerLookupApi, BusinessPartnerLookupApi>();
            //services.AddScoped<ICatalogLookupApi, CatalogLookupApi>();
            //services.AddScoped<IWarehouseApi, WarehouseApi>();
            //services.AddScoped<IWorkShiftApi, WorkShiftApi>();
            //services.AddScoped<IWorkPlaceApi, WorkPlaceApi>();
            //services.AddScoped<IEmployeeApi, EmployeeApi>();

            //services.AddScoped<ILookupBaseApi, LookupBaseApi>();
        }

    }
}
