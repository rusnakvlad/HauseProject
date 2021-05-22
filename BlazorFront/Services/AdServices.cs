﻿using System;
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
using BlazorFront.AuthServices;
using System.Text.RegularExpressions;

namespace BlazorFront.Services
{
    public class AdServices : IAdServices
    {
        private HttpClient httpClient { get; }
        public ILocalStorageService localStorageService { get; }
        public ITokenServices tokenServices;

        public AdServices(HttpClient httpClient, ILocalStorageService localStorageService,ITokenServices tokenServices)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
            this.tokenServices = tokenServices;
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

            var errorMessage = new Regex("(?<=error_description=\").*(?=;)").Match(response.Headers.WwwAuthenticate.ToString());
            if (errorMessage.Value == "The token lifetime is invalid" && response.StatusCode.ToString() == "Unauthorized")
            {
                string refreshToken = await localStorageService.GetItemAsync<string>("refreshToken");
                await tokenServices.RefreshToken(new UserTokenDTO() { AccessToken = accessToken, RefreshToken = refreshToken });
                await AddNewAd(createAdDTO); // call method again after refresh token
            }

            var responseBody = await response.Content.ReadAsStringAsync();
        }

        public async Task DeleteAdById(int id) // Authorized
        {
            string serializedUser = JsonConvert.SerializeObject("");
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"{id}");
            requestMessage.Content = new StringContent(serializedUser);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            var responseBody = await response.Content.ReadAsStringAsync();

            var errorMessage = new Regex("(?<=error_description=\").*(?=;)").Match(response.Headers.WwwAuthenticate.ToString());
            if (errorMessage.Value == "The token lifetime is invalid" && response.StatusCode.ToString() == "Unauthorized")
            {
                string refreshToken = await localStorageService.GetItemAsync<string>("refreshToken");
                await tokenServices.RefreshToken(new UserTokenDTO() { AccessToken = accessToken, RefreshToken = refreshToken });
                await DeleteAdById(id); // call method again after refresh token
            }

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

            IEnumerable<AdInfoDTO> savedResult = new List<AdInfoDTO>();
            var errorMessage = new Regex("(?<=error_description=\").*(?=;)").Match(response.Headers.WwwAuthenticate.ToString());
            if (errorMessage.Value == "The token lifetime is invalid" && response.StatusCode.ToString() == "Unauthorized")
            {
                string refreshToken = await localStorageService.GetItemAsync<string>("refreshToken");
                await tokenServices.RefreshToken(new UserTokenDTO() { AccessToken = accessToken, RefreshToken = refreshToken });
                savedResult = await GetAdsByUserId(userId); // call method again after refresh token
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<AdInfoDTO>>(responseBody);
            }
            return savedResult;
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
            var responseBody = await response.Content.ReadAsStringAsync();
            var errorMessage = new Regex("(?<=error_description=\").*(?=;)").Match(response.Headers.WwwAuthenticate.ToString());
            if (errorMessage.Value == "The token lifetime is invalid" && response.StatusCode.ToString() == "Unauthorized")
            {
                string refreshToken = await localStorageService.GetItemAsync<string>("refreshToken");
                await tokenServices.RefreshToken(new UserTokenDTO() { AccessToken = accessToken, RefreshToken = refreshToken });
                await UpdateAd(editAdDTO);
            }
        }

        public async Task<IEnumerable<AdInfoDTO>> GetAdsByOptions(AdToCompare adToCompare)
        {
            string serializedUser = JsonConvert.SerializeObject(adToCompare);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "GetByOptions");
            requestMessage.Content = new StringContent(serializedUser);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            //requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;

            //IEnumerable<AdInfoDTO> savedResult = new List<AdInfoDTO>();
            //var errorMessage = new Regex("(?<=error_description=\").*(?=;)").Match(response.Headers.WwwAuthenticate.ToString());
            //if (errorMessage.Value == "The token lifetime is invalid" && response.StatusCode.ToString() == "Unauthorized")
            //{
            //    string refreshToken = await localStorageService.GetItemAsync<string>("refreshToken");
            //    await tokenServices.RefreshToken(new UserTokenDTO() { AccessToken = accessToken, RefreshToken = refreshToken });
            //    savedResult = await GetAdsByOptions(adToCompare); // call method again after refresh token
            //}
            //else
            //{
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<AdInfoDTO>>(responseBody);
            //}
            //return savedResult;
        }

        public async Task<AdEditDTO> GetAdForEdit(int id)
        {
            string serializedUser = JsonConvert.SerializeObject("");
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"GetByIdToEdit/{id}");
            requestMessage.Content = new StringContent(serializedUser);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string accessToken = await localStorageService.GetItemAsync<string>("accessToken");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;

            AdEditDTO savedResult = new AdEditDTO();
            var errorMessage = new Regex("(?<=error_description=\").*(?=;)").Match(response.Headers.WwwAuthenticate.ToString());
            if (errorMessage.Value == "The token lifetime is invalid" && response.StatusCode.ToString() == "Unauthorized")
            {
                string refreshToken = await localStorageService.GetItemAsync<string>("refreshToken");
                await tokenServices.RefreshToken(new UserTokenDTO() { AccessToken = accessToken, RefreshToken = refreshToken });
                savedResult = await GetAdForEdit(id); // call method again after refresh token
            }
            else
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AdEditDTO>(responseBody);
            }
            return savedResult;
        }
    }
}
