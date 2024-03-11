using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using YGOSearcher.Models;

namespace YGOSearcher.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
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

    private List<string> searchResults = new List<string>();
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

    //[ObservableProperty]
    //[NotifyPropertyChangedFor(nameof(filterText))]
    //string text;

    //[ObservableProperty]
    //List<string> searchResults;

    //public string filterText => $"{text}";

    //[RelayCommand]
    //void performSearch()
    //{
    //    List<Card> results = MainPageModel.SearchCard(text);

    //    if (results is not null )
    //    {
    //        if (results.Count < 5 )
    //        {
    //            for (int i = 0; i < results.Count; i++)
    //                searchResults.Add(results[i].name);
    //        }
    //        else
    //        {
    //            for (int i = 0; i < 5; i++)
    //                searchResults.Add(results[i].name);
    //        }
    //    }   
    //}


}
