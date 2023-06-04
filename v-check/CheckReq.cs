using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v_check
{
    internal class CheckReq
    {
        Auth auth = new Auth();

        public async Task<string> CheckRequest(string phone, string[] emails, int amount, int fromWhen, int occur, int Pattern) 
        {
            var token = await auth.Authorization();


            using (var httpClient = new HttpClient())
            {
                var jsonObj = new
                {
                    recipientPhone = $"{phone}",
                    title = "hh",
                    amount = $"{amount}",
                    daysToRepayment = $"{fromWhen}",
                    reference = "string",
                    recipientAlias = "",
                    notificationEmails = new string[] { $"{emails}" },

                      senderAlias= "",
                      isFlexible= "",
                      smsNotificationsType= 0,
                      externalId= "",
                      collectionSprintId= "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                      occurrences= $"{occur}",
                      recurrencePattern= $"{Pattern}"
                };
                    string jStr = JsonConvert.SerializeObject(jsonObj);

                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.access_token}");
                    httpClient.DefaultRequestHeaders.Add("X-API-Key", "VC-RyK3FVOnpDWL8rKQjRyxqARDDP95RIIT6lBpFwQa0e5bpse");
                    var requestUrl = $"https://virtserver.swaggerhub.com/V-CHECK/v-check-api/1.0/payment-requests";
                    var jsonSt = new StringContent(jStr, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(requestUrl, jsonSt);
                    var content = await response.Content.ReadAsStringAsync();
                    return content;

            }
        }
            public async Task<string> getPaymentReqByDate(string StartDate, string EndDate)
            {
            var token = await auth.Authorization();


            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.access_token}");
                httpClient.DefaultRequestHeaders.Add("X-API-Key", "VC-RyK3FVOnpDWL8rKQjRyxqARDDP95RIIT6lBpFwQa0e5bpse");

                var queryString = $"StartDate={StartDate}&EndDate={EndDate}";
                var requestUrl = $"https://sandbox-api.v-check.co.il/payment-requests?{queryString}";

                var response = await httpClient.GetAsync(requestUrl);

                var content = await response.Content.ReadAsStringAsync();
                return content;

            }
            }

        public async Task<string> getPaymentReqById(string checkId)
        {
            var token = await auth.Authorization();


            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token.access_token}");
                httpClient.DefaultRequestHeaders.Add("X-API-Key", "VC-RyK3FVOnpDWL8rKQjRyxqARDDP95RIIT6lBpFwQa0e5bpse");


                var requestUrl = $"https://sandbox-api.v-check.co.il/payment-requests/{checkId}";

                var response = await httpClient.GetAsync(requestUrl);

                var content = await response.Content.ReadAsStringAsync();
                return content;

            }
        }
    }
}
