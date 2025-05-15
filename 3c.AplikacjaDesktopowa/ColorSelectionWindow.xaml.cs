using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _3c.AplikacjaDesktopowa
{
    /// <summary>
    /// Interaction logic for ColorSelectionWindow.xaml
    /// </summary>
    public partial class ColorSelectionWindow : Window
    {
        public Color color;

        public ColorSelectionWindow()
        {
            InitializeComponent();
        }

        private void SaveColor_Click(object sender, RoutedEventArgs e)
        {
            byte RedColorNumber = Convert.ToByte(RedColor.Text);
            byte GreenColorNumber = Convert.ToByte(GreenColor.Text);
            byte BlueColorNumber = Convert.ToByte(BlueColor.Text);

            color = Color.FromRgb(RedColorNumber, GreenColorNumber, BlueColorNumber);
            this.Close();

        }
    }
}
