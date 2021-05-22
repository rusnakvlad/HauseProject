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

namespace BlazorFront.Services
{
    public class AdServices : IAdServices
    {
        private HttpClient httpClient { get; }
        public ILocalStorageService localStorageService { get; }

        public AdServices(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
        }

        public async Task AddNewAd(AdCreateDTO createAdDTO) // Authorized
        {
            string serializedUser = JsonConvert.SerializeObject(createAdDTO);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "");
            requestMessage.Content = new StringContent(serializedUser);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

        }

        public async Task DeleteAdById(int id) // Authorized
        {
            string serializedUser = JsonConvert.SerializeObject("");
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{id}");
            requestMessage.Content = new StringContent(serializedUser);
            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();
        }

        public async Task<AdInfoDTO> GetAdById(int id)
        {
            return await httpClient.GetJsonAsync<AdInfoDTO>("GetById/" + id);
        }

        public async Task<IEnumerable<AdInfoDTO>> GetAdsByUserId(string userId) // Authorized
        {
            string serializedAd = JsonConvert.SerializeObject("");
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "UserId/" + userId);
            requestMessage.Content = new StringContent(serializedAd);
            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedAd = JsonConvert.DeserializeObject<IEnumerable<AdInfoDTO>>(responseBody);

            return returnedAd;
        }

        public async Task<IEnumerable<AdInfoDTO>> GetAllAds()
        {
            return await httpClient.GetJsonAsync<IEnumerable<AdInfoDTO>>("GetAll");
        }

        public async Task UpdateAd(AdEditDTO editAdDTO) // Authorized
        {
            string serializedUser = JsonConvert.SerializeObject(editAdDTO);
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, "");
            requestMessage.Content = new StringContent(serializedUser);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();
        }

        public async Task<IEnumerable<AdInfoDTO>> GetAdsByOptions(AdToCompare adToCompare)
        {
            string serializedUser = JsonConvert.SerializeObject(adToCompare);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "GetByOptions");
            requestMessage.Content = new StringContent(serializedUser);
            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedAd = JsonConvert.DeserializeObject<IEnumerable<AdInfoDTO>>(responseBody);

            return returnedAd;
        }

        public async Task<AdEditDTO> GetAdForEdit(int id)
        {
            string serializedUser = JsonConvert.SerializeObject("");
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"GetByIdToEdit/{id}");
            requestMessage.Content = new StringContent(serializedUser);
            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();
            var returnedAd = JsonConvert.DeserializeObject<AdEditDTO>(responseBody);

            return returnedAd;
        }
    }
}
