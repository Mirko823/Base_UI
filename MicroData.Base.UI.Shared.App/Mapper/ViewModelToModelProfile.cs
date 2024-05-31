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

            CreateMap<CatalogCategoryViewModel, ProductCategoryModel>();
            CreateMap<CatalogCategoryViewModel, ServiceCategoryModel>();

            CreateMap<CatalogViewModel, ProductCatalogModel>();

            CreateMap<CatalogViewModel, ServiceCatalogModel>();

            CreateMap<ProfessionViewModel, ProfessionModel>();

            CreateMap<WarehouseViewModel, WarehouseModel>();

            CreateMap<WorkPlaceViewModel, WorkPlaceModel>();
            CreateMap<WorkShiftViewModel, WorkShiftModel>();


        }
    }
}
