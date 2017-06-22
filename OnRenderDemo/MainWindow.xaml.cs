using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace OnRenderDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PreviewBrush.Visual = _renderTarget;
        }

        private readonly RenderOnlyElement _renderTarget = new RenderOnlyElement();

        private void PutInOutButton_Click(object sender, RoutedEventArgs e)
        {
            if (RootPanel.Children.Contains(_renderTarget))
            {
                RootPanel.Children.Remove(_renderTarget);
            }
            else
            {
                RootPanel.Children.Add(_renderTarget);
            }
        }

        private void Rerender_Click(object sender, RoutedEventArgs e)
        {
            _renderTarget.Rerender();
        }

        private class RenderOnlyElement : FrameworkElement
        {
            private readonly Brush[] _fillBrushes =
            {
                Brushes.BlueViolet,
                Brushes.Coral,
                Brushes.DeepSkyBlue,
                Brushes.LightSeaGreen,
                Brushes.YellowGreen,
            };

            private int _index;

            public void Rerender()
            {
                InvalidateVisual();
                //if (IsLoaded)
                //{
                //    InvalidateVisual();
                //}
                //else
                //{
                //    var method = GetType()
                //        .GetMethod("RenderOpen",
                //            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
                //    var dc = (DrawingContext) method.Invoke(this, null);
                //    try
                //    {
                //        OnRender(dc);
                //    }
                //    finally
                //    {
                //        dc.Close();
                //    }
                //}
            }

            protected override void OnRender(DrawingContext dc)
            {
                dc.DrawEllipse(_fillBrushes[_index % _fillBrushes.Length], null,
                    new Point(RenderSize.Width / 2, RenderSize.Height / 2),
                    RenderSize.Width / 2, RenderSize.Height / 2);
                dc.DrawText(
                    new FormattedText(
                        _index.ToString(CultureInfo.InvariantCulture),
                        CultureInfo.InvariantCulture,
                        FlowDirection.LeftToRight,
                        new Typeface(
                            new FontFamily("Microsoft YaHei"),
                            FontStyles.Normal,
                            FontWeights.Normal,
                            FontStretches.Normal),
                        64.0,
                        Brushes.White,
                        new NumberSubstitution(),
                        TextFormattingMode.Display,
                        1.0),
                    new Point());
                _index++;
            }
        }
    }
}
