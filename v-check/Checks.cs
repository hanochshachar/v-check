using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace v_check
{
    internal class Checks
    {
        Auth auth = new Auth();
        public async Task<string> GetChecksByDate(string StartDate, string EndDate)
        {
           



            var token = await auth.Authorization();


            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.access_token}");
                httpClient.DefaultRequestHeaders.Add("X-API-Key", "VC-RyK3FVOnpDWL8rKQjRyxqARDDP95RIIT6lBpFwQa0e5bpse");

                var queryString = $"StartDate={StartDate}&EndDate={EndDate}";
                var requestUrl = $"https://sandbox-api.v-check.co.il/checks?{queryString}";

                var response = await httpClient.GetAsync(requestUrl);

                var content = await response.Content.ReadAsStringAsync();
                return content;

            }
        }

        public async Task<string> getCheckById(int checkId)
        {
            var token = await auth.Authorization();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.access_token}");
                httpClient.DefaultRequestHeaders.Add("X-API-Key", "VC-RyK3FVOnpDWL8rKQjRyxqARDDP95RIIT6lBpFwQa0e5bpse");

                
                var requestUrl = $"https://sandbox-api.v-check.co.il/checks/{checkId}?asOwner=false";

                var response = await httpClient.GetAsync(requestUrl);

                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
        }

        public async Task<string> CreateCheck(string phone, string title, int amount, int fromWhen, int occur, int Pattern, int bank, string branch, string account)
        {
            var paymentAccountMethodId = await auth.GetMethodId();

            var jsonObj = new
            {
                recipientPhone = $"{phone}",
                title = $"{title}",
                amount = $"{amount}",
                daysToRepayment = $"{fromWhen}",
                recurrencePattern = $"{Pattern}",
                occurrences = $"{occur}",
                paymentAccountMethodId = $"{paymentAccountMethodId[0].paymentAccountMethodId}",
                comment = "string",
                paymentRequestId = "",
                isNegotiable = true,
                handshakeMetadata = new
                {
                    targetBankType = $"{bank}",
                    targetBankBranchNumber = $"{branch}",
                    targetBankAccountNumber = $"{account}"
                }
            };

            string jStr = JsonConvert.SerializeObject(jsonObj);

            var token = await auth.Authorization();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.access_token}");
                httpClient.DefaultRequestHeaders.Add("X-API-Key", "VC-RyK3FVOnpDWL8rKQjRyxqARDDP95RIIT6lBpFwQa0e5bpse");

                var requestUrl = "https://virtserver.swaggerhub.com/V-CHECK/v-check-api/1.0/checks";

                var jsonSt = new StringContent(jStr, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(requestUrl, jsonSt);
                var content = await response.Content.ReadAsStringAsync();
                return content;

            }
        }

        public async Task<string> ResToCheckReq(string reqId, string phone, string title, int amount, int fromWhen, int occur, int Pattern, int bank, string branch, string account)
        {

            var paymentAccountMethodId =  await auth.GetMethodId();
            var jsonObj = new
            {
                recipientPhone = $"{phone}",
                title = $"{title}",
                amount = $"{amount}",
                daysToRepayment = $"{fromWhen}",
                recurrencePattern = $"{Pattern}",
                occurrences = $"{occur}",
                paymentAccountMethodId = $"{paymentAccountMethodId[0].paymentAccountMethodId}",
                comment = "string",
                paymentRequestId = $"{reqId}",
                isNegotiable = true,
                handshakeMetadata = new
                {
                    targetBankType = $"{bank}",
                    targetBankBranchNumber = $"{branch}",
                    targetBankAccountNumber = $"{account}"
                }
            };

            string jStr = JsonConvert.SerializeObject(jsonObj);

            var token = await auth.Authorization();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.access_token}");
                httpClient.DefaultRequestHeaders.Add("X-API-Key", "VC-RyK3FVOnpDWL8rKQjRyxqARDDP95RIIT6lBpFwQa0e5bpse");

                var requestUrl = "https://virtserver.swaggerhub.com/V-CHECK/v-check-api/1.0/checks";

                var jsonSt = new StringContent(jStr, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(requestUrl, jsonSt);
                var content = await response.Content.ReadAsStringAsync();
                return content;

            }
        }

        
    }
}
