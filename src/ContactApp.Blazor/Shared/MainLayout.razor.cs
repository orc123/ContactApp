using Microsoft.AspNetCore.Components;
using MudBlazor.ThemeManager;
using MudBlazor;
using ContactApp.Blazor.Theme;

namespace ContactApp.Blazor.Shared;

public partial class MainLayout
{
    private ThemeManagerTheme _themeManager = new ThemeManagerTheme();
    public bool _drawerOpen = true;
    public bool _themeManagerOpen = false;
    public string fullName = string.Empty;
    public long count = 0;
    int pageIndex = 1;
    int pageSize = 8;
    void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    //void OpenThemeManager(bool value)
    //{
    //    _themeManagerOpen = value;
    //}

    //void UpdateTheme(ThemeManagerTheme value)
    //{
    //    _themeManager = value;
    //    StateHasChanged();
    //}

    protected override async Task OnInitializedAsync()
    {
        _themeManager.Theme = new MudBlazorTheme();
        _themeManager.DrawerClipMode = DrawerClipMode.Always;
        _themeManager.FontFamily = "Montserrat";
        _themeManager.DefaultBorderRadius = 3;
        _themeManager.AppBarElevation = 4;
        _themeManager.DrawerElevation = 25;
        StateHasChanged();
    }

    private async Task HandleLogout()
    {
        //await AuthService.LogoutAsync();
        //NavigationManager.NavigateTo(UrlConstants.Login);
    }
}
