using AutoMapper;
using MicroData.Common.UI.Shared.Email;
using MicroData.Identity.Application.Interface;
using MicroData.Identity.Domain.Model;
using MicroData.Identity.UI.Shared.Api;
using MicroData.Identity.UI.Shared.Interface;
using MicroData.Identity.UI.Shared.ViewModel;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Shared.Api
{
    public class CompanyApp : BaseIdentityApp<CompanyViewModel,CompanyModel> , ICompanyApi
    {

        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyApp(ICompanyService companyService, IMapper mapper) : base(companyService,mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }


        public override CompanyViewModel Get(object id, string accessToken)
        {
            var res = _companyService.Get(id);
            var resultViewModel = _mapper.Map<CompanyViewModel>(res);
            return resultViewModel;
        }

        public CompanyEmailAccountViewModel AddOrUpdateEmailAccount(CompanyEmailAccountViewModel emmailAccount, string accessToken)
        {
            //var _endpoint = _webHostApi + Endpoint + "/AddOrUpdateEmailAccount";

            //var request = GetRequestTemplate(HttpMethod.Post, _endpoint,accessToken);

            //request.Content = new StringContent(JsonConvert.SerializeObject(emmailAccount), Encoding.UTF8, "application/json");

            //HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            //var body = response.Content.ReadAsStringAsync().Result;

            //var deserializedObject = JsonConvert.DeserializeObject<CompanyEmailAccountViewModel>(body);

            //return deserializedObject;

            return new CompanyEmailAccountViewModel { };
        }

        public CompanyEmailAccountViewModel GetEmailAccount(string companyId, string accessToken)
        {
            //var _endpoint = _webHostApi + Endpoint + "/GetEmailAccount/" + companyId;

            //var request = GetRequestTemplate(HttpMethod.Get, _endpoint,accessToken);

            //HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            //var body = response.Content.ReadAsStringAsync().Result;

            //var deserializedObject = JsonConvert.DeserializeObject<CompanyEmailAccountViewModel>(body);

            //return deserializedObject;

            return new CompanyEmailAccountViewModel { };
        }

        public async Task<EmailViewModel> SetEmailModel(string companyId, string accessToken)
        {

            //var _endpoint = _webHostApi + Endpoint + "/GetEmailAccount/" + companyId;

            //var request = GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken);

            //HttpResponseMessage response = await _httpClient.SendAsync(request);
            //var body = await response.Content.ReadAsStringAsync();

            //var emailAccount = JsonConvert.DeserializeObject<CompanyEmailAccountViewModel>(body);

            //var emailModel = new EmailViewModel()
            //{
            //    Type = emailAccount.Type,
            //    ApiKey = emailAccount.ApiKey,
            //    Password = emailAccount.Password,
            //    SmtpServer = emailAccount.SmtServer,
            //    Port = emailAccount.Port,
            //    EnableSSL = emailAccount.EnableSSL,

            //    Name = emailAccount.Name,
            //    From = emailAccount.Email,
            //    Reply = emailAccount.Reply
            //};
            //return emailModel;

            return new EmailViewModel { };
        }
    }
}
