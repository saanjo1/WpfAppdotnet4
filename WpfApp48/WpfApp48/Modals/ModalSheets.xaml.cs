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

namespace WpfApp48.Modals
{
    /// <summary>
    /// Interaction logic for ModalSheets.xaml
    /// </summary>
    public partial class ModalSheets : Window
    {
        public static ExcelDataService _objDataService;
        public static string sheetName;

        public ModalSheets()
        {
            _objDataService = new ExcelDataService();
            InitializeComponent();
        }

        private void saveSheet_click(object sender, RoutedEventArgs e)
        {
            sheetName = cmbSheet.Text;
            Close();
        }

        private void closeModal_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cmbSheet_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> sheetList = _objDataService.ListSheetInExcel().Result;

            if (sheetList != null)
            {
                cmbSheet.ItemsSource = sheetList;
                cmbSheet.SelectedItem = sheetList[0];
            }
              
        }
    }
}
