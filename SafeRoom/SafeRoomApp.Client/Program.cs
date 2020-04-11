using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SafeRoomApp.Core.Services;
using SafeRoomApp.Core;

namespace SafeRoomApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();

            builder.Services.AddScoped<HttpClient>(s =>
            {
                var client = new HttpClient() { BaseAddress = new System.Uri("https://localhost:44309/") };
                return client;
            });

            builder.Services.AddScoped<IUserDataService, UserDataService>();
            builder.Services.AddScoped<IChatroomDataService, ChatroomDataService>();

            await builder.Build().RunAsync();
        }
    }
}
