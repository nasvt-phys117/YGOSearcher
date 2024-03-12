using YGOSearcher.Models;
using YGOSearcher.ViewModels;

namespace YGOSearcher.View;

public partial class MainPageView : ContentPage
{
	public MainPageView(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var item = e.SelectedItem as string;
		MainPageViewModel mpvm = new();

		await mpvm.TapCommand(item);
    }
}