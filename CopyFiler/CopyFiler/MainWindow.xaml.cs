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
            LoadFilesToStack(Grid_Addresses);
        }

        private void Button_AddProject_Click(object sender, RoutedEventArgs e)
        {
            //string[] temp = new string[2] { "aa", "bb" };
            //List<string[]> myList = new List<string[]>();
            //myList.Add(temp);


            //var a = CSVManager.CSVReader.GetData(@"C:\Users\NPaunov\Downloads\Google Drive\Tools\CopyFiler\CopyFiler\Data\DefaultAddress.csv", Globals.DA_Separator);
            //CSVManager.CSVWriter.WriteData(myList, @"C:\Users\NPaunov\Downloads\Google Drive\Tools\CopyFiler\CopyFiler\Data\DefaultAddress.csv", Globals.DA_Separator);

            //StackPanelCustom newPanel = new StackPanelCustom();

            //newPanel.Name = "aa";

            //Button button = new Button();
            //button.Content = "mybutton";

            //newPanel.Children.Add(button);

            //projectStack.Children.Add(newPanel);


        }
        private void Grid_Addresses_Drop(object sender, DragEventArgs e)
        {
            string[] filePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];
            var file = e.Data;
            List<string[]> files = new List<string[]>();

            foreach (var filePath in filePaths)
            {
                string fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);

                if (!string.IsNullOrEmpty(fileName))
                {
                    string[] fileArr = { fileName, filePath };
                    files.Add(fileArr);

                    GridCustom grid = new GridCustom();
                    grid.AddCustomRowToGrid(Grid_Addresses, filePath);                
                }
            }

            if (files.Count() != 0)
            {
                CSVWriter.WriteData(files, Globals.FileLinksFile, Globals.DA_Separator);
            }

            
            
        }
        private void Button_DefaultAddres_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            string selectedPath = dialog.SelectedPath;

            File.WriteAllText(Globals.DefaultAddressFile, string.Empty);

            CSVWriter.WriteText(selectedPath, Globals.DefaultAddressFile, Globals.DA_Separator);

            txBlock_DAdress.Text = selectedPath;

        }

        private string LoadAddresText()
        {
            IEnumerable<string[]> dAdressText = CSVReader.GetData(Globals.DefaultAddressFile, Globals.DA_Separator);
            string address = dAdressText.Count() == 0 ? "" : dAdressText.First().ToArray()[1].ToString();
            return address;
        }

        private void LoadFilesToStack(Grid grid)
        {
            IEnumerable<string[]> files = CSVReader.GetData(Globals.FileLinksFile, Globals.DA_Separator);

            if (files.Count() != 0)
            {

            }
        }   
    }
}
