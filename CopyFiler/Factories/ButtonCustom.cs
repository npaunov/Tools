using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Factories
{
    public class ButtonCustom : Button
    {
        public ButtonCustom ButtonSmall()
        {
            ButtonCustom smallButton = new ButtonCustom();

            //this deletes current row from grid
            smallButton.Click += (send, ev) =>
            {
                Grid grid = ((send as Button).Parent) as Grid;
                int row = Grid.GetRow((send as Button));
                int childCount = grid.Children.Count;

                for (int i = childCount - 1; i >= 0; i--)
                {
                    var child = grid.Children[i];
                    int currentRow = Grid.GetRow(child);

                    if (row == currentRow)
                    {
                        grid.Children.Remove(child);
                    }
                    if (currentRow > row)
                    {
                        Grid.SetRow(child, Grid.GetRow(child) - 1);
                    }
                }

                grid.RowDefinitions.RemoveAt(row);
            };

            smallButton.Content = "Изтрий";

            return smallButton;
        }
    }
}
