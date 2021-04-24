using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorFront.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
namespace BlazorFront.Services
{
    public class UserServices : IUserServices
    {
        public HttpClient _httpClient { get; }

        public UserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserViewModel> GetUserByEmail(string email)
        {
            string serializedRefreshRequest = JsonConvert.SerializeObject(email);
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "Email/" + email);
            requestMessage.Content = new StringContent(serializedRefreshRequest);
            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedUser = JsonConvert.DeserializeObject<UserViewModel>(responseBody);

            return returnedUser;
        }
    }
}
