using SafeRoom.Business.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SafeRoomApp.Core.Services
{
    public class ChatroomDataService : IChatroomDataService
    {
        private readonly HttpClient _httpClient;
        private const string apiPath = "api/chatrooms";

        public ChatroomDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ChatroomDto>> GetChatrooms()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<ChatroomDto>>
                (await _httpClient.GetStreamAsync(apiPath), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<ChatroomDto>> GetChatroomsOfUser(int userId)
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<ChatroomDto>>
                (await _httpClient.GetStreamAsync($"{apiPath}/user/{userId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ChatroomDto> GetChatroomDetails(int chatroomId)
        {
            return await JsonSerializer.DeserializeAsync<ChatroomDto>
                (await _httpClient.GetStreamAsync($"{apiPath}/{chatroomId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
