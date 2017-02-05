using CopyFiler.Data;
using Factories;
using System.Linq;
using CSVManager;
using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Specialized;

namespace CopyFiler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ImageSource ImageSource { get; set; }
        public string DAdress_text { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            LoadData();

        }

        private void LoadData()
        {
            DAdress_text = LoadAddresText();
            LoadFilesToStack(Grid_Addresses, Properties.Settings.Default.CustomerPaths);
        }

        private void Button_Copy_Click(object sender, RoutedEventArgs e)
        {
            foreach (var fileSource in Properties.Settings.Default.CustomerPaths)
            {
                FileUse.Copy(fileSource, Properties.Settings.Default.DefaultPatfh);
            }
        }
        private void Grid_Addresses_Drop(object sender, DragEventArgs e)
        {
            string[] filePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            //var file = e.Data;
            //List<string[]> files = new List<string[]>();

            foreach (var filePath in filePaths)
            {
                string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);

                if (!string.IsNullOrEmpty(fileName))
                {
                    //string[] fileArr = { fileName, filePath };
                    //files.Add(fileArr);

                    GridCustom grid = new GridCustom();
                    Create.CustomRowToGrid(Grid_Addresses, filePath);

                    Properties.Settings.Default.CustomerPaths.Add(filePath);
                    Properties.Settings.Default.Save();
                }
            }

        }
        private void Button_DefaultAddres_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            string selectedPath = dialog.SelectedPath;

            Properties.Settings.Default.DefaultPatfh = selectedPath;
            Properties.Settings.Default.Save();

            txBlock_DAdress.Text = selectedPath;

        }

        private string LoadAddresText()
        {
            return Properties.Settings.Default.DefaultPatfh;
        }

        private void LoadFilesToStack(Grid grid, StringCollection collection)
        {
            if (Properties.Settings.Default.CustomerPaths == null)
            {
                Properties.Settings.Default.CustomerPaths =
                    new StringCollection();
            }

            foreach (var path in collection)
            {
                Create.CustomRowToGrid(grid, path);
            }

        }

        private void Btn_ClearAllFiles_Click(object sender, RoutedEventArgs e)
        {
            Grid_Addresses.Children.Clear();
            Grid_Addresses.RowDefinitions.Clear();

            Properties.Settings.Default.CustomerPaths.Clear();
            Properties.Settings.Default.Save();
        }

        private void Grid_Addresses_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.Source.GetType() == typeof(ButtonCustom))
            {
                int row = Grid.GetRow(e.Source as ButtonCustom);

                Properties.Settings.Default.CustomerPaths.RemoveAt(row);
                Properties.Settings.Default.Save();
            }
        }
    }
}
