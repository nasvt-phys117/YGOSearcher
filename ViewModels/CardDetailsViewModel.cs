using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using YGOSearcher.Models;

namespace YGOSearcher.ViewModels;


[QueryProperty(nameof(Card), nameof(Card))]
public partial class CardDetailsViewModel : ObservableObject
{
    [ObservableProperty]
    public Datum? card;
}