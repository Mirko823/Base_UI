using MicroData.Common.UI.Shared.Email;
using MicroData.Identity.UI.Shared.Api;
using MicroData.Identity.UI.Shared.Interface;
using MicroData.Identity.UI.Shared.ViewModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Shared.Api
{
    public class CompanyApi : BaseIdentityApi<CompanyViewModel> , ICompanyApi
    {
      
        public CompanyApi() : base()
        {
        }

        public override string Endpoint => "api/company";

        public CompanyEmailAccountViewModel AddOrUpdateEmailAccount(CompanyEmailAccountViewModel emmailAccount, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/AddOrUpdateEmailAccount";

            var request = GetRequestTemplate(HttpMethod.Post, _endpoint,accessToken);

            request.Content = new StringContent(JsonConvert.SerializeObject(emmailAccount), Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;

            var deserializedObject = JsonConvert.DeserializeObject<CompanyEmailAccountViewModel>(body);

            return deserializedObject;
        }

        public CompanyEmailAccountViewModel GetEmailAccount(string companyId, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/GetEmailAccount/" + companyId;

            var request = GetRequestTemplate(HttpMethod.Get, _endpoint,accessToken);

            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;

            var deserializedObject = JsonConvert.DeserializeObject<CompanyEmailAccountViewModel>(body);

            return deserializedObject;
        }

        public async Task<EmailViewModel> SetEmailModel(string companyId, string accessToken)
        {

            var _endpoint = _webHostApi + Endpoint + "/GetEmailAccount/" + companyId;

            var request = GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken);

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            var emailAccount = JsonConvert.DeserializeObject<CompanyEmailAccountViewModel>(body);

            var emailModel = new EmailViewModel()
            {
                Type = emailAccount.Type,
                ApiKey = emailAccount.ApiKey,
                Password = emailAccount.Password,
                SmtpServer = emailAccount.SmtServer,
                Port = emailAccount.Port,
                EnableSSL = emailAccount.EnableSSL,

                Name = emailAccount.Name,
                From = emailAccount.Email,
                Reply = emailAccount.Reply
            };
            return emailModel;
        }
    }
}
