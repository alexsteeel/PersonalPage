using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PersonalPage.Shared.Services;
using System.Threading.Tasks;

namespace PersonalPage.Client
{
    public static class Program
    {
        private const string URL = "https://localhost:5001";

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddScoped(s =>
            {
                return new AuthenticationService(URL);
            });

            builder.Services.AddScoped(s =>
            {
                return new PostsService(URL);
            });

            builder.Services.AddScoped(s =>
            {
                return new CommentsService(URL);
            });

            builder.RootComponents.Add<App>("app");

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();

            await builder.Build().RunAsync();
        }
    }
}
