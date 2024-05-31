using System.Net.Http;
using System.Net.Http.Headers;

namespace MicroData.Base.UI.Shared.Helper
{
    public static class BaseHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static string BaseWebApiHost { get; set; }

        public static void InitializeClient(string accessToken)
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}
