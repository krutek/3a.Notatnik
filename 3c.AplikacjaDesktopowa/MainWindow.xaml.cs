using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;

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
        private void ZmienKolorNaCzerwony_Click(object sender, RoutedEventArgs e)
        {
            mainTextBox.Foreground = Brushes.Red;
        }

        private void ZmienKolorNaCzarny_Click(object sender, RoutedEventArgs e)
        {
            mainTextBox.Foreground = Brushes.Black;
        }

        private void WybierzKolor_Click(object sender, RoutedEventArgs e)
        {
            ColorSelectionWindow newWindow = new ColorSelectionWindow();
            newWindow.ShowDialog();
            SolidColorBrush brush = new SolidColorBrush(newWindow.color);
            mainTextBox.Foreground = brush;
        }
    }
}