using AutoMapper;
using MicroData.Common.UI.Shared.Email;
using MicroData.Common.UI.Shared.Identity;
using MicroData.Identity.Application.Interface;
using MicroData.Identity.Domain.Model;
using MicroData.Identity.UI.Shared.Interface;
using MicroData.Identity.UI.Shared.ViewModel;

namespace MicroData.Identity.UI.Shared.App
{
    public class AuthrizeApp : IAuthorizeApi
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AuthrizeApp(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public bool SignInUserCompany(SignInViewModel userViewModel)
        {
            var userModel = _mapper.Map<SignInModel>(userViewModel);

            var logInUser= _userService.GetUser(userModel, true);

            if (logInUser == null)
                return false;

            CurrentCompany.TenantId = logInUser.Company.TenantId.ToString();
            CurrentCompany.CompanyId = logInUser.Company.Id.ToString();
            CurrentCompany.Name = logInUser.Company.Name;
            CurrentCompany.Address = logInUser.Company.Address;
            CurrentCompany.City = logInUser.Company.City;
            CurrentCompany.State = logInUser.Company.State;
            CurrentCompany.Email = logInUser.Company.Email;
            CurrentCompany.TaxNumber = logInUser.Company.TaxNumber;
            CurrentCompany.RegistryNumber = logInUser.Company.RegistryNumber;
            CurrentCompany.Jbkjs = logInUser.Company.JBKJS;
            CurrentCompany.InVat = logInUser.Company.InVat;
            CurrentCompany.SefApiKey = logInUser.Company.SefApiKey;
            CurrentCompany.LicenceType = logInUser.Company.LicenceType;
            CurrentCompany.LicenceExpiryDate = logInUser.Company.LicenceExpiryDate;

            //CurrentCompany.Accounts = logInUser.Company.Accounts
            //    .OrderByDescending(o=>o.IsDefault)
            //    .Select(s => new BaseIntLookup()
            //    {
            //        Value = s.AccountNumber
            //    })
            //    .ToList();

            if (logInUser.Company.EmailAccount != null)
            {
                var emailModel = new EmailViewModel()
                {
                    //Type = logInUser.Company.EmailAccount.Type,
                    ApiKey = logInUser.Company.EmailAccount.ApiKey,
                    Password = logInUser.Company.EmailAccount.Password,
                    SmtpServer = logInUser.Company.EmailAccount.SmtServer,
                    Port = logInUser.Company.EmailAccount.Port,
                    EnableSSL = logInUser.Company.EmailAccount.EnableSSL,

                    Name = logInUser.Company.EmailAccount.Name,
                    From = logInUser.Company.EmailAccount.Email,
                    Reply = logInUser.Company.EmailAccount.Reply
                };

                CurrentCompany.EmailModel = emailModel;
            }

            CurrentUser.Id = new Guid(logInUser.Id.ToString());
            CurrentUser.TenantId = new Guid(logInUser.TenantId.ToString());
            CurrentUser.ComapanyId = new Guid(logInUser.Company.Id.ToString());
            CurrentUser.EmployeeId = logInUser.EmployeeId;
            CurrentUser.UserName = logInUser.UserName;
            CurrentUser.FirstName = logInUser.FirstName;
            CurrentUser.LastName = logInUser.LastName;
            CurrentUser.Email = logInUser.Email;
            CurrentUser.Roles = logInUser.Roles.Select(s => s.Name).ToList();

            CurrentUser.AccessToken = logInUser.AccessToken;

            CurrentUser.BusinessYear = (short)logInUser.BusinessYear;

            return true;

        }

        public  UserViewModel SignInUser(SignInViewModel userViewModel)
        {
            var userModel = _mapper.Map<SignInModel>(userViewModel);

            var logInUser = _userService.GetUser(userModel, true);

            return _mapper.Map<UserViewModel>(logInUser);
        }
    }
}
