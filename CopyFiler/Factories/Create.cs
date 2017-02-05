using System.Windows;
using System.Windows.Controls;

namespace Factories
{
    public static class Create
    {
        public static void CustomRowToGrid(Grid grid, string path)
        {
            //The inner grid has four columns
            int FirstCol = 0;
            int SecondCol = 1;
            int ThirdCol = 2;
            int FourthCol = 3;

            int childCount = grid.RowDefinitions.Count;

            if (childCount == 7)
            {
                MessageBox.Show("No more files! Clear some.");
                return;
            }

            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(27);
            grid.RowDefinitions.Add(row);

            ImageCustom image = new ImageCustom().Icon(path);

            Grid.SetRow(image, childCount);
            Grid.SetColumn(image, FirstCol);
            grid.Children.Add(image);

            TextBlockCustom textSmall = new TextBlockCustom().TxtFileName(path);

            Grid.SetRow(textSmall, childCount);
            Grid.SetColumn(textSmall, SecondCol);
            grid.Children.Add(textSmall);

            TextBlockCustom textLong = new TextBlockCustom().TxtFilePath(path);

            Grid.SetRow(textLong, childCount);
            Grid.SetColumn(textLong, ThirdCol);
            grid.Children.Add(textLong);

            ButtonCustom button = new ButtonCustom().ButtonSmall();

            Grid.SetRow(button, childCount);
            Grid.SetColumn(button, FourthCol);
            grid.Children.Add(button);

        }
    }
}
