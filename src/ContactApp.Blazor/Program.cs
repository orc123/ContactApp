using Blazored.SessionStorage;
using ContactApp.Blazor;
using ContactApp.Blazor.Core.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;

namespace ContactApp.Blazor;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        //builder.Services.AddHttpClientInterceptor();
        builder.Services.AddAuthorizationCore();
        builder.Services.AddBlazoredSessionStorage();
        builder.Services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri(builder.Configuration["BackendApiUrl"])
        });

        builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

        builder.Services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;

            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 10000;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });

        await builder.Build().RunAsync();
    }
}