using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Podkasto.Views
{
    public partial class EpisodesView : UserControl
    {
        public EpisodesView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}