using AutoMapper;
using MicroData.Identity.Application.Interface;
using MicroData.Identity.Domain.Model;
using MicroData.Identity.UI.Shared.Api;
using MicroData.Identity.UI.Shared.Interface;
using MicroData.Identity.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class UserApp : BaseIdentityApp<UserViewModel,UserModel> , IUserApi
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserApp(IUserService userService, IMapper mapper) : base(userService, mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        public IEnumerable<UserViewModel> GetAllWithFirstRole(string accessToken)
        {
            var items = _userService.GetAllWithFirstRole();

            return _mapper.Map<IEnumerable<UserViewModel>>(items);
        }
    }
}
