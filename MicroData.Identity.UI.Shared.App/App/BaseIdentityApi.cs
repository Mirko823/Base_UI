using MicroData.Common.UI.Shared.Interface;
using MicroData.Common.UI.Shared.ViewModel.Interface;
using MicroData.Identity.UI.Shared.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroData.Identity.UI.Shared.Api
{
    public abstract class BaseIdentityApi<T> : IBaseApi<T> where T : IBaseViewModel
    {
        public string _webHostApi;
        public static HttpClient _httpClient = new HttpClient();

        public BaseIdentityApi()
        {
            _webHostApi = IdentityHelper.IdentityWebApiHost;
        }

        public abstract string Endpoint { get; }

        #region Get
        public async Task<IEnumerable<T>> GetAllAsync(string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/GetAsync";

            var response = await _httpClient.SendAsync(GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken));
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(body);

        }

        public IEnumerable<T> GetAll(string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint;

            var response = _httpClient.SendAsync(GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken)).Result;
            var body = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IEnumerable<T>>(body);
        }
        public T Get(object id, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/" + id.ToString();

            var response = _httpClient.SendAsync(GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken)).Result;
            var body = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(body);

        }

        public async Task<T> GetAsync(object id, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/GetAsync/" + id.ToString();

            var response = await _httpClient .SendAsync(GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken));
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(body);

        }

        public T GetPreview(object id, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/GetPreview/" + id.ToString();

            var response = _httpClient.SendAsync(GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken)).Result;
            var body = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(body);
        }

        public async Task<T> GetPreviewAsync(object id, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/GetPreviewAsync/" + id.ToString();

            var response = await _httpClient.SendAsync(GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken));
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(body);

        }
        #endregion

        #region Add new
        public T GetNew(string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/GetNew";

            var response = _httpClient.SendAsync(GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken)).Result;
            var body = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(body);
        }

        public T CreateNew(T Model, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint;

            var request = GetRequestTemplate(HttpMethod.Post, _endpoint, accessToken);

            request.Content = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;

            var deserializedObject = JsonConvert.DeserializeObject<T>(body);

            return deserializedObject;
        }

        public async Task<T> CreateNewAsync(T Model, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint;

            var request = GetRequestTemplate(HttpMethod.Post, _endpoint, accessToken);

            request.Content = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            var deserializedObject = JsonConvert.DeserializeObject<T>(body);

            return deserializedObject;
        }

        public T ValidateCreateNew(T model)
        {
            return model;
        }
        #endregion

        #region Edit Existing
        public T EditExisting(T model, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint;

            var request = GetRequestTemplate(HttpMethod.Put, _endpoint, accessToken);

            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            var body = response.Content.ReadAsStringAsync().Result;

            var deserializedObject = JsonConvert.DeserializeObject<T>(body);

            return deserializedObject;
        }

        public async Task<T> EditExistingAsync(T Model,string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint;

            var request = GetRequestTemplate(HttpMethod.Put, _endpoint, accessToken);

            request.Content = new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            var deserializedObject = JsonConvert.DeserializeObject<T>(body);

            return deserializedObject;
        }

        public T ValidateEditExisting(T model)
        {
            return model;
        }

        #endregion

        #region Delete Existing
        public bool DeleteExisting(object id, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/" + id.ToString();
            var req = GetRequestTemplate(HttpMethod.Delete, _endpoint, accessToken);
            HttpResponseMessage response = _httpClient.SendAsync(req).Result;

            var body = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<bool>(body);
        }

        public async Task<bool> DeleteExistingAsync(object id, string accessToken)
        {
            var _endpoint = _webHostApi + Endpoint + "/" + id.ToString();
            var req = GetRequestTemplate(HttpMethod.Delete, _endpoint, accessToken);
            HttpResponseMessage response = await _httpClient.SendAsync(req);

            var body = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(body);
        }

        public HttpRequestMessage GetRequestTemplate(HttpMethod method, string endpoint,string accessToken)
        {
            if ((accessToken == "") || (accessToken.Length == 0) || (accessToken == null))
            {
                throw new Exception("You are not authorized to view this content");
            }
            HttpRequestMessage req = new HttpRequestMessage();
            req.Method = method;
            req.RequestUri = new Uri(endpoint);
        
            req.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            return req;
        }

        public T ValidateDeleteExisting(T model)
        {
            return model;
        }

        #endregion
    }
}
