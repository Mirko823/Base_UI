using AutoMapper;
using MicroData.Identity.Domain.Model;
using MicroData.Identity.UI.Shared.ViewModel;

namespace MicroData.Identity.UI.Shared.App.Mapper
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            CreateMap<SignInViewModel, SignInModel>();

            CreateMap<RoleViewModel, RoleModel>();
            CreateMap<UserViewModel, UserModel>();

            CreateMap<TenantViewModel, TenantModel>();
            CreateMap<ApiViewModel, ApiModel>();
            CreateMap<TenantApiViewModel, TenantApiModel>();

            CreateMap<CompanyViewModel, CompanyModel>();

            CreateMap<CompanyEmailAccountViewModel, CompanyEmailAccountModel>();

            CreateMap<CompanyAccountViewModel, CompanyAccountModel>();
            CreateMap<CompanyBusinessYearViewModel, CompanyBusinessYearModel>();
            CreateMap<CompanyUnitViewModel, CompanyUnitModel>();

            CreateMap<UserSettingsViewModel, UserSettingsModel>();

            CreateMap<CompanySettingsViewModel, CompanySettingsModel>();
        }
    }
}
