using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace v_check
{
    internal class Auth
    {
        public async Task<dynamic> Authorization()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, "https://sandbox-api.v-check.co.il/auth/token"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer VC-RyK3FVOnpDWL8rKQjRyxqARDDP95RIIT6lBpFwQa0e5bpse");
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                           { "username", "0556803386" },
                           { "password", "5s3ARhRwFGeKPrY" },
                           { "grant_type", "password" },
                           { "scope", "openid email phone profile offline_access roles" },
                    });
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                    var response = await httpClient.SendAsync(request);
                    /*Console.WriteLine(await response.Content.ReadAsStringAsync());*/
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<dynamic>(content);
                    return result;

                }
            }
        }

        public async Task<dynamic> GetMethodId()
        {
            var token = await Authorization();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.access_token}");
                httpClient.DefaultRequestHeaders.Add("X-API-Key", "VC-RyK3FVOnpDWL8rKQjRyxqARDDP95RIIT6lBpFwQa0e5bpse");

               
                var requestUrl = $"https://virtserver.swaggerhub.com/V-CHECK/v-check-api/1.0/payment-accounts/methods";

                var response = await httpClient.GetAsync(requestUrl);

               
                
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(content);
                return result;
             

                
                

            }
        }

    }

    internal class PaymentAccount
    {
    }
}
