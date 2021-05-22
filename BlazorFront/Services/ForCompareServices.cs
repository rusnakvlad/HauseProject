using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using BuisnesLogicLayer.DTO;
using DataAccesLayer.Enteties;
using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using BlazorFront.AuthServices;

namespace BlazorFront.Services
{
    public class ForCompareServices : IForCompareServices // Authorized
    {
        private HttpClient httpClient { get; }
        public ILocalStorageService localStorageService { get; }
        public ITokenServices tokenServices;

        public ForCompareServices(HttpClient httpClient,ILocalStorageService localStorageService, ITokenServices tokenServices)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
            this.tokenServices = tokenServices;
        }
        public async Task<IEnumerable<ForCompareDTO>> GetAllComparesByUserId(string userId)
        {
            string serializedAd = JsonConvert.SerializeObject("");
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{userId}");
            requestMessage.Content = new StringContent(serializedAd);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.SendAsync(requestMessage); 

            var errorMessage = new Regex("(?<=error_description=\").*(?=;)").Match(response.Headers.WwwAuthenticate.ToString());
            if (errorMessage.Value == "The token lifetime is invalid" && response.StatusCode.ToString() == "Unauthorized")
            {
                string refreshToken = await localStorageService.GetItemAsync<string>("refreshToken");
                await tokenServices.RefreshToken(new UserTokenDTO() { AccessToken = accessToken, RefreshToken = refreshToken });
                await GetAllComparesByUserId(userId); // call method again after 
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                var returnedAd = JsonConvert.DeserializeObject<IEnumerable<ForCompareDTO>>(responseBody);

                return returnedAd;
            }
            return null;
        }

        public async Task RemoveCopareByUserIdAndAdId(string userId, int AdId)
        {
            string serializedAd = JsonConvert.SerializeObject("");
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{userId}/{AdId}");
            requestMessage.Content = new StringContent(serializedAd);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();
        }

        public async Task SetForCompare(string userId, int adId)
        {
            string serializedAd = JsonConvert.SerializeObject("");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{userId}/{adId}");
            requestMessage.Content = new StringContent(serializedAd);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();
        }
    }
}
