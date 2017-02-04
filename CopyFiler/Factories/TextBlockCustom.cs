using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Factories
{
    public class TextBlockCustom : TextBlock
    {
        public TextBlockCustom TxtFileName(string filePath)
        {
            TextBlockCustom customText = new TextBlockCustom();

            customText.Text = filePath.Substring(filePath.LastIndexOf('\\') + 1);
            customText.Foreground = Brushes.Blue;
            customText.VerticalAlignment = VerticalAlignment.Center;
            customText.FontSize = 12;
            customText.Margin = new Thickness(5);
            customText.FontFamily = new FontFamily("Georgia");


            return customText;
        }

        public TextBlockCustom TxtFilePath(string filePath)
        {
            TextBlockCustom customText = new TextBlockCustom();

            customText.VerticalAlignment = VerticalAlignment.Center;
            customText.FontSize = 12;
            customText.Text = filePath;
            customText.Margin = new Thickness(5);
            customText.FontFamily = new FontFamily("Georgia");
            customText.Foreground = Brushes.Blue;

            return customText;
        }
    }
}
