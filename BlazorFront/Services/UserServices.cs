using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using BuisnesLogicLayer.DTO;
using Microsoft.AspNetCore.Components;
namespace BlazorFront.Services
{
    public class UserServices : IUserServices
    {
        private HttpClient httpClient { get; }
         
        public UserServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<UserProfileDTO> GetUserByEmail(string email)
        {
            return await httpClient.GetJsonAsync<UserProfileDTO>("Email/" + email);
        }

        public async Task<bool> RegisterUser(UserRegisterDTO user)
        {
            string serializedUser = JsonConvert.SerializeObject(user);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "RegisterUser");
            requestMessage.Content = new StringContent(serializedUser);
            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var response = await httpClient.SendAsync(requestMessage);
            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedUser = JsonConvert.DeserializeObject<UserRegisterDTO>(responseBody);
            
            return returnedUser.Email != null ? true : false;
        }
    }
}
