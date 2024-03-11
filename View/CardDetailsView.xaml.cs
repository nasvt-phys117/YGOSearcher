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