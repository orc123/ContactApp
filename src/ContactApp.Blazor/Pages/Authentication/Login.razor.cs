using ContactApp.Blazor.Services.Implement;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using ContactApp.Blazor.Dto.Login;
using ContactApp.Blazor.Services.Interface;
using static System.Formats.Asn1.AsnWriter;

namespace ContactApp.Blazor.Pages.Authentication;

public partial class Login
{
    private bool loading = false;
    LoginRequestDto model = new LoginRequestDto()
    {
        Username = "",
        Password = ""
    };
    string errorMsg = string.Empty;

    bool PasswordVisibility;
    InputType PasswordInput = InputType.Password;
    string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

    async Task HandleLogin()
    {
        loading = true;
        if (model == null)
        {
            errorMsg = "Đăng nhập không đúng.";
        }
        else
        {
            model.ClientId = configuration.GetValue<string>("IdentityServerConfig:client_id");
            model.GrantType = configuration.GetValue<string>("IdentityServerConfig:grant_type");
            model.ClientSecret = configuration.GetValue<string>("IdentityServerConfig:client_secret");
            model.Scope = configuration.GetValue<string>("IdentityServerConfig:scope");
            var result = await authService.LoginAsync(model);
            if (result != null)
            {
                navigationManager.NavigateTo("/home");
            }
            else
            {
                errorMsg = "Đăng nhập không đúng.";
            }
        }
        loading = false;
    }

    void TogglePasswordVisibility()
    {
        if(PasswordVisibility)

        {
            PasswordVisibility = false;
            PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
            PasswordInput = InputType.Password;
        }

        else
        {
            PasswordVisibility = true;
            PasswordInputIcon = Icons.Material.Filled.Visibility;
            PasswordInput = InputType.Text;
        }
    }
    private async Task KeyboardEventHandler(KeyboardEventArgs args)
    {
        if (args.Code == "Enter")
        {
            await HandleLogin();
        }
    }
}
