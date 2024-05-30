using MicroData.Identity.UI.Shared.Api;
using MicroData.Identity.UI.Shared.Interface;
using MicroData.Identity.UI.Shared.ViewModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace MicroData.Base.UI.Shared.Api
{
    public class UserApi : BaseIdentityApi<UserViewModel> , IUserApi
    {
      
        public UserApi() : base()
        {
        }

        public override string Endpoint => "api/user";

        public IEnumerable<UserViewModel> GetAllWithFirstRole(string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/GetAllWithFirstRole";

            var request = GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken);


            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;

            var deserializedObject = JsonConvert.DeserializeObject<IEnumerable<UserViewModel>>(body);

            return deserializedObject;
        }
    }
}
