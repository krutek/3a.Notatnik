using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace _3c.AplikacjaDesktopowa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickOn(object sender, RoutedEventArgs e)
        {

        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            string text = mainTextBox.Text;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                string path = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(text);
                }

                MessageBox.Show($"Plik został zapisany do: {text}");


            }
        }

        private void SaveAsClick(object sender, RoutedEventArgs e)
        {
            string text = mainTextBox.Text;

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Pole edytora jest puste");
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";

            string path = string.Empty;

            if (openFileDialog.ShowDialog() == true)
                path = openFileDialog.FileName;
            else
                return;

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(text);
            }

            MessageBox.Show("Plik został zapisany do: ");

        
        }

        //OpenFileDialog openFileDialog = new OpenFileDialog();
        //SaveFileDialog saveFileDialog = new SaveFileDialog();
        //StreamWriter writer = new StreamWriter(path);
        //StreamReader streamReader = new StreamReader(path);



        private void OpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";

            string path = string.Empty;

            if (openFileDialog.ShowDialog() == true)
                path = openFileDialog.FileName;
            else
                return;

            using (StreamReader streamReader = new StreamReader(path))
            {
                mainTextBox.Text = streamReader.ReadToEnd();
            }
        }
    }
}