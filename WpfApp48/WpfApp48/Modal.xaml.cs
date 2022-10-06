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
        public static ArticleDisplayVM columns;

        public Modal()
        {
            InitializeComponent();
        }

        private void btnCloseClick(object sender, RoutedEventArgs e) =>
    Close();
        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            columns = new ArticleDisplayVM
            {
                ID = Id.Text,
                ItemName = itemime.Text,
                ItemSize = itemsize.Text,
                BarCode = barcode.Text,
                CollectionCategory = CollectionCategory.Text,
                Gender = gender.Text,
                So_Price = price.Text
            };
            

            Close();
        }
    }
}
