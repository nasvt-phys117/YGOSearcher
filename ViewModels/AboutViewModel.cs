using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using YGOSearcher.Helpers;

namespace YGOSearcher.ViewModels;

public partial class AboutViewModel : ObservableObject
{
    //readonly IConnectivity connectivity;

    //public AboutViewModel(IConnectivity connectivity)
    //{
    //    this.connectivity = connectivity;
    //}

    [ObservableProperty]
    public string title = AppInfo.Name;

    [ObservableProperty]
    public string version = AppInfo.VersionString;

    [ObservableProperty]
    public string message = "Made with .NET MAUI";


    public static string MoreInfoUrl => "https://www.nasosvoutouras.xyz/about/";
    [RelayCommand]
    static async Task ShowMoreInfo() =>
        await Launcher.Default.OpenAsync(MoreInfoUrl);

    [RelayCommand]
    async Task RefreshDatabase()
    {
        //if(connectivity.NetworkAccess != NetworkAccess.Internet)
        //{
        //    await Shell.Current.DisplayAlert("Negated!", "No Internet Access...", "OK");
        //    return;
        //}
        await DatabaseHelpers.RetrieveDatabase();
    }

}
