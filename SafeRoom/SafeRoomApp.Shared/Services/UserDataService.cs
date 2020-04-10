using SafeRoom.Business.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SafeRoomApp.Shared.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly HttpClient _httpClient;
        private const string apiPath = "api/users";

        public UserDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var test = await _httpClient.GetStreamAsync(apiPath);
            return await JsonSerializer.DeserializeAsync<IEnumerable<UserDto>>
                (await _httpClient.GetStreamAsync(apiPath), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<UserDto> GetUser(int userId)
        {
            return await JsonSerializer.DeserializeAsync<UserDto>
                (await _httpClient.GetStreamAsync($"{apiPath}/{userId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<UserDto> AddUser(UserDto user)
        {
            var userJson =
                new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiPath, userJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<UserDto>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateUser(UserDto user)
        {
            var userJson =
                new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync(apiPath, userJson);
        }

        public async Task DeleteUser(int userId)
        {
            await _httpClient.DeleteAsync($"{apiPath}/{userId}");
        }
    }
}
