using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using YGOSearcher.Helpers;
using YGOSearcher.Models;
using YGOSearcher.View;

namespace YGOSearcher.ViewModels;

public partial class MainPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public ICommand PerformSearch => new Command<string>((string query) =>
    {
        SearchResults = MainPageModel.SearchCard(query);
    });

    private List<string> searchResults = [];
    public List<string> SearchResults
    {
        get
        {
            return searchResults;
        }
        set
        {
            searchResults = value;
            NotifyPropertyChanged();
        }
    }

    public Datum card = new();

    public async Task TapCommand(string s)
    {
        if (s is null) return;
        card = MainPageModel.GetCard(s);
        DatabaseHelpers.GetCardImage(card);
        await Shell.Current.GoToAsync(nameof(CardDetailsView),
            new Dictionary<string, object>
            {
                ["Card"] = card,
                ["ImagePath"] = $"{GlobalsDB.cacheDir}/p_{card.id}.jpg"
            }) ;
    }
}
