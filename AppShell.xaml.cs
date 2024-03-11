using YGOSearcher.View;

namespace YGOSearcher
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CardDetailsView), typeof(CardDetailsView));
        }
    }
}
