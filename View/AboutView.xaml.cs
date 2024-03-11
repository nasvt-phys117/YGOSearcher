using YGOSearcher.ViewModels;

namespace YGOSearcher.View;

public partial class AboutView : ContentPage
{
	public AboutView(AboutViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}