using System.Windows;
using System.Windows.Media;
using System.Windows.Controls.Primitives;

namespace ColorPicker
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        UserActivityHook mouseHook = new UserActivityHook(false);

        public Window1()
        {
            InitializeComponent();
            mouseHook.OnMouseActivity += (hook, args) =>
            {
                Point cursorPosition = UserActivityHook.GetCursorPosition();
                Color screenColor = PointColorPicker.GetColorFromPoint(cursorPosition);
                colorPanel.Background = new SolidColorBrush(screenColor);
                colorText.Text = screenColor.ToString();
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as ToggleButton).IsChecked)
            {
                mouseHook.Start();
            }
            else
            {
                mouseHook.Stop();
            }
        }

        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mouseHook != null)
            {
                mouseHook.Stop();
            }
        }
    }
}
