using CommunityToolkit.Mvvm.ComponentModel;
using YGOSearcher.Helpers;
using YGOSearcher.Models;

namespace YGOSearcher.ViewModels;


[QueryProperty(nameof(Card), nameof(Card))]
[QueryProperty(nameof(ImagePath), nameof(ImagePath))]
public partial class CardDetailsViewModel : ObservableObject
{
    [ObservableProperty]
    Datum? card;


    [ObservableProperty]
    string? imagePath;
}
