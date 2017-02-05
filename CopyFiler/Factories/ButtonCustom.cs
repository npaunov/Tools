using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Calculations;

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
                GridCalc.DeleteCurrentRow(send as Button);
            };

            smallButton.Content = "Изтрий";

            return smallButton;
        }
    }
}
