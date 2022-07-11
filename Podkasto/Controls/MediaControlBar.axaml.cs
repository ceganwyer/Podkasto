using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Podkasto.Controls
{
    public partial class MediaControlBar : UserControl
    {
        public MediaControlBar()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}