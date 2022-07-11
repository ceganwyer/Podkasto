using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Podkasto.Views
{
    public partial class SubscriptionsView : UserControl
    {
        public SubscriptionsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}