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
using WpfApp48.ViewModels;

namespace WpfApp48
{
    /// <summary>
    /// Interaction logic for Modal.xaml
    /// </summary>
    public partial class Modal : Window
    {
        public static List<string> columns;

        public static string ID = String.Empty;
        public static string ItemName = String.Empty;
        public static string ItemSize = String.Empty;
        public static string Barcode = String.Empty;
        public static string Gender = String.Empty;
        public static string Price = String.Empty;

        public Modal()
        {
            InitializeComponent();
        }

        private void btnCloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            ID = Id.Text;
            ItemName = itemime.Text;
            ItemSize = itemsize.Text;
            Barcode = barcode.Text;
            Gender = gender.Text;
            Price = price.Text;

            Close();
        }
    }
}
