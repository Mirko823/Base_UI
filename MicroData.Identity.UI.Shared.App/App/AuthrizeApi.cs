using MicroData.Common.UI.Shared.Email;
using MicroData.Common.UI.Shared.Identity;
using MicroData.Common.UI.Shared.Lookup;
using MicroData.Identity.UI.Shared.Helper;
using MicroData.Identity.UI.Shared.Interface;
using MicroData.Identity.UI.Shared.ViewModel;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace MicroData.Identity.UI.Shared.App
{
    public class AuthrizeApi : IAuthorizeApi
    {

        private string _webHostApi;
        //private string _signInEndpoint2 = "http://178.219.10.32:50551/api/account/signin2";

       // public event EventHandler<EventArgs> AccessTokenChanged;

        private static HttpClient _httpClient = new HttpClient();

        public AuthrizeApi()
        {
            _webHostApi = IdentityHelper.IdentityWebApiHost;
        }

        public bool SignInUserCompany(SignInViewModel userModel)
        {
            //to do - Razdvojiti logovanje usera od company
            // company uzeti podatke async

            var _signInEndpoint3 = _webHostApi + "api/authenticate/SignInUserCompany";

            HttpRequestMessage req = new HttpRequestMessage();
            req.Method = HttpMethod.Post;
            req.RequestUri = new Uri(_signInEndpoint3);

            req.Content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.SendAsync(req).Result;
            var body = response.Content.ReadAsStringAsync().Result;

            var logInUser= JsonConvert.DeserializeObject<UserViewModel>(body);

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
                    Type = logInUser.Company.EmailAccount.Type,
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

        public  UserViewModel SignInUser(SignInViewModel userModel)
        {
            var _signInEndpoint3 = _webHostApi + "api/authenticate/SignInUser";

            HttpRequestMessage req = new HttpRequestMessage();
            req.Method = HttpMethod.Post;
            req.RequestUri = new Uri(_signInEndpoint3);

            req.Content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.SendAsync(req).Result;
            var body = response.Content.ReadAsStringAsync().Result;

            var logInUser = JsonConvert.DeserializeObject<UserViewModel>(body);

            return logInUser;
        }
    }
}
