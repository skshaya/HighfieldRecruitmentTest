using HFQ_APP_Backend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace HFQ_APP_Backend.Services
{
    public static class APIAccess
    {/// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="httpClient"></param>
    /// <param name="url"></param>
    /// <param name="param"></param>
    /// <returns></returns>
        public static async Task<T> PostExtSentAsync<T>(this HttpClient httpClient, string url, object param)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{url}")
                };

                if (param != null)
                    request.Content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");

                var response = await httpClient.SendAsync(request).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();


                string responseBody = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseBody))
                    throw new Exception("Empty content");

                return JsonConvert.DeserializeObject<T>(responseBody);
            }
            catch (UnauthorizedAccessException uaExc)
            {
                throw uaExc;
            }
            //catch()
            catch (Exception exc)
            {
                throw exc;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<T> GetExtSentAsync<T>(this HttpClient httpClient, string url)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{url}")
                };

                var response = await httpClient.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseBody))
                    throw new Exception("Empty content");

                return JsonConvert.DeserializeObject<T>(responseBody);

            }
            catch (UnauthorizedAccessException uaExc)
            {
                throw;
            }
            catch (Exception exc)
            {
                throw;
            }
        }
    }
}