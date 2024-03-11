using YGOSearcher.ViewModels;

namespace YGOSearcher.View;

public partial class MainPageView : ContentPage
{
	public MainPageView(MainPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
	}
}