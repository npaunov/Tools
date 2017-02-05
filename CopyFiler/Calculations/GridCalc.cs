using System.Windows.Controls;
using System.Windows.Media;

namespace Calculations
{
    public static class GridCalc
    {
        //this deletes current row from grid
        public static void DeleteCurrentRow(Button button)
        {
            Grid grid = (button.Parent) as Grid;
            int row = Grid.GetRow(button);
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
        }
    }
}
