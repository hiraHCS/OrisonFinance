using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DevExpress.Blazor;
using OrisonFinance.Client;
using Blazored.SessionStorage;
using Blazored.LocalStorage;
using Cloudcrate.AspNetCore.Blazor.Browser.Storage;
using OrisonFinance.Client.Services;

namespace OrisonFinance.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<FunctionService>();
            builder.Services.AddSingleton<AccountService>();
            builder.Services.AddScoped<TaxInvoiceService>();
            builder.Services.AddDevExpressBlazor();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddStorage();
            await builder.Build().RunAsync();

        }

       
    }
}
