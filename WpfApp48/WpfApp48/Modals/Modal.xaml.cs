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
using WpfApp48.Services;
using WpfApp48.ViewModels;

namespace WpfApp48
{
    /// <summary>
    /// Interaction logic for Modal.xaml
    /// </summary>
    public partial class Modal : Window
    {
        public static ArticleDisplayVM columns;
        public static ExcelDataService _objDataService;
        public Modal()
        {
            InitializeComponent();
            _objDataService = new ExcelDataService();
        }

      

        private void closeButton_Click(object sender, RoutedEventArgs e) =>
    Close();
        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            columns = new ArticleDisplayVM
            {
                ItemName = itemime.Text,
                ItemSize = itemsize.Text,
                BarCode = barcode.Text,
                CollectionCategory = CollectionCategory.Text,
                Gender = gender.Text,
                So_Price = price.Text
            };
            

            Close();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            List<string> lista = _objDataService.GetData().Result;

            if (lista != null)
            {
                itemime.ItemsSource = lista;
                itemsize.ItemsSource = lista;
                gender.ItemsSource = lista;
                barcode.ItemsSource = lista;
                price.ItemsSource = lista;
                CollectionCategory.ItemsSource = lista;
            }


            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Contains("SO_PRICE"))
                    price.SelectedItem = lista[i];
                if (lista[i].Contains("GENDER"))
                    gender.SelectedItem = lista[i];
                if (lista[i].Contains("BARCODE"))
                    barcode.SelectedItem = lista[i];
                if (lista[i].Contains("ITEM_SIZE"))
                    itemsize.SelectedItem = lista[i];
                if (lista[i].Contains("SKU"))
                    itemime.SelectedItem = lista[i];
                if (lista[i].Contains("SEASON"))
                    CollectionCategory.SelectedItem = lista[i];

            }
        }
    }
}
