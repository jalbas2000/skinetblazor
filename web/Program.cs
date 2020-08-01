using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using web.HttpRepositories;
using web.Services;
using BlazorStrap;

namespace web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBlazoredToast();

            builder.Services.AddBootstrapCss();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();

            builder.Services.AddScoped<IErrorService, ErrorService>();

            await builder.Build().RunAsync();
        }
    }
}
