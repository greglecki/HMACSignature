using HMACSignature.WPClient.BL.Handlers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace HMACSignature.WPClient.BL
{
    public static class NetworkManager
    {
        private const string baseURL = "http://localhost:49224/api/values/";

        public static async Task<IEnumerable<string>> GetValues()
        {
            IEnumerable<string> result = null;
            HMACDelegatingHandler hmacDelegatingHandler = new HMACDelegatingHandler();
            using (var client = new HttpClient(hmacDelegatingHandler))
            {
                var uri = new Uri(string.Format("{0}getvalues/", baseURL));

                try
                {
                    var json = await client.GetStringAsync(uri);
                    result = JsonConvert.DeserializeObject<List<string>>(json);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                return result;
            }
        }

        public static async Task<string> GetValue(int id)
        {
            string result = "None";
            HMACDelegatingHandler hmacDelegatingHandler = new HMACDelegatingHandler();
            using (var client = new HttpClient(hmacDelegatingHandler))
            {
                var uri = new Uri(string.Format("{0}getvaluebyid/?id={1}", baseURL, id));

                try
                {
                    var json = await client.GetStringAsync(uri);
                    result = json;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                return result;
            }
        }
    }
}
