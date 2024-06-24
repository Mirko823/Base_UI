using AutoMapper;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.App.Mapper
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            CreateMap<BankViewModel, BankModel>();
            CreateMap<TaxViewModel, TaxModel>();
            CreateMap<UnitViewModel, UnitModel>();
            CreateMap<CityViewModel, CityModel>();
            CreateMap<CurrencyViewModel, CurrencyModel>();

            CreateMap<BusinessPartnerViewModel, BusinessPartnerModel>();

            CreateMap<CityViewModel, CityModel>();
            CreateMap<ClientViewModel, ClientModel>();
            CreateMap<EmployeeViewModel, EmployeeModel>();

            CreateMap<LocationViewModel, LocationModel>();
            CreateMap<ShipperViewModel, ShipperModel>();

            CreateMap<ProductCategoryViewModel, ProductCategoryModel>();
            CreateMap<ServiceCategoryViewModel, ServiceCategoryModel>();

            
            CreateMap<ProductCatalogViewModel, ProductCatalogModel>();
            CreateMap<ServiceCatalogViewModel, ServiceCatalogModel>();

            CreateMap<GrainCatalogViewModel, GrainCatalogModel>();

            CreateMap<ProfessionViewModel, ProfessionModel>();

            CreateMap<WarehouseViewModel, WarehouseModel>();

            CreateMap<WorkPlaceViewModel, WorkPlaceModel>();
            CreateMap<WorkShiftViewModel, WorkShiftModel>();


        }
    }
}
