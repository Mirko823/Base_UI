﻿using MicroData.Identity.UI.Shared.Api;
using MicroData.Identity.UI.Shared.Interface;
using MicroData.Identity.UI.Shared.ViewModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Shared.Api
{
    public class UserSettingsApi : BaseIdentityApi<UserSettingsViewModel> , IUserSettingsApi
    {
      
        public UserSettingsApi() : base()
        {
        }

        public override string Endpoint => "api/UserSettings";

        public IEnumerable<UserSettingsViewModel> GetAllBySettingsGroup(int settingsGroup, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/GetAllBySettingsGroup/" + settingsGroup.ToString();

            var request = GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken);
            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;

            var deserializedObject = JsonConvert.DeserializeObject<IEnumerable<UserSettingsViewModel>>(body);

            return deserializedObject;
        }

        public async Task<IEnumerable<UserSettingsViewModel>> GetAllBySettingsGroupAsync(int settingsGroup, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/GetAllBySettingsGroupAsync/" + settingsGroup.ToString();

            var request = GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken);
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            var deserializedObject = JsonConvert.DeserializeObject<IEnumerable<UserSettingsViewModel>>(body);

            return deserializedObject;
        }

    }
}
