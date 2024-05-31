using AutoMapper;
using MicroData.Identity.Domain.Model;
using MicroData.Identity.UI.Shared.ViewModel;

namespace MicroData.Identity.UI.Shared.App.Mapper
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<SignInModel, SignInViewModel>(MemberList.Source);

            CreateMap<UserModel, UserViewModel>(MemberList.Source);

            CreateMap<CompanyModel, CompanyViewModel>(MemberList.Source);

            CreateMap<CompanyEmailAccountModel, CompanyEmailAccountViewModel>(MemberList.Source);

            CreateMap<CompanyAccountModel, CompanyAccountViewModel>(MemberList.Source);
            CreateMap<CompanyBusinessYearModel, CompanyBusinessYearViewModel>(MemberList.Source);
            CreateMap<CompanyUnitModel, CompanyUnitViewModel>(MemberList.Source);

            CreateMap<TenantModel, TenantViewModel>(MemberList.Source);

            CreateMap<ApiModel, ApiViewModel>(MemberList.Source);
            CreateMap<TenantApiModel, TenantApiViewModel>(MemberList.Source);

            CreateMap<UserSettingsModel, UserSettingsViewModel>(MemberList.Source);

            CreateMap<CompanySettingsModel, CompanySettingsViewModel>(MemberList.Source);
        }
    }
}
