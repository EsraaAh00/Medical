using JwtAuthenticationManager;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharedModels.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SharedModels.Helpers
{
    public class BaseHttpContext
    {
        public static HttpClient client = new HttpClient();
        public static string path = "http://localhost:5049/gateway";
        public static async Task<T?> GetObject<T>(string action)
        {
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", AuthenticationHelper.GetToken());

            HttpResponseMessage response = await client.GetAsync($"{path}/{action}");
            //if (response.IsSuccessStatusCode)
            //{
            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString ?? "");

            //}

        }
        public static async Task<List<T?>?> GetList<T>(string action)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", AuthenticationHelper.GetToken());


            HttpResponseMessage response = await client.GetAsync($"{path}/{action}");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T?>?>(jsonString ?? "");

            }
            else
            {

                return null;
            }

        }
        public static async Task<T?> PostObjectReturnObj<T>(string action, T ?Obj)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", AuthenticationHelper.GetToken());


            HttpResponseMessage response = await client.PostAsJsonAsync($"{path}/{action}", Obj);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T?>(jsonString ?? "");

            }
            else
            {

                return Obj;
            }

        }
        public static async Task<BaseResponse?> PostObjectReturnBaseResponse<T>(string action, T Obj)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", AuthenticationHelper.GetToken());


            HttpResponseMessage response = await client.PostAsJsonAsync($"{path}/{action}", Obj);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseResponse?>(jsonString ?? "");

            }
            else
            {

                return null;
            }

        }
        public static async Task<BaseResponse?> GetReturnBaseResponse(string action)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", AuthenticationHelper.GetToken());


            HttpResponseMessage ?response = await client.GetAsync($"{path}/{action}");
            if (response!=null&&response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BaseResponse?>(jsonString ?? "");

            }
            else
            {

                return null;
            }

        }
        public static async Task<List<OuterIncludeModel?>?> GetOuterIncludeList(string action,List<int?> Ids)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", AuthenticationHelper.GetToken());


            HttpResponseMessage? response = await client.GetAsync($"{path}/{action}");
            if (response != null && response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<OuterIncludeModel?>?>(jsonString ?? "");

            }
            else
            {

                return null;
            }

        }

      


    }
}
