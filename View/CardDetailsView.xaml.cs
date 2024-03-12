using CommunityToolkit.Mvvm.ComponentModel;
using YGOSearcher.Models;
using YGOSearcher.ViewModels;

namespace YGOSearcher.View;

public partial class CardDetailsView : ContentPage
{
	public CardDetailsView(CardDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}