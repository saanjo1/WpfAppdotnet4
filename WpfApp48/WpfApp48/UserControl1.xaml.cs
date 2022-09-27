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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp48.Resources;
using WpfApp48.Services;
using WpfApp48.ViewModels;

namespace WpfApp48
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        ExcelDataService _objExcelSer;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void Prikaz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _objExcelSer = new ExcelDataService();
                dataGridArticle.ItemsSource = _objExcelSer.ReadFromExcel().Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImportCat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExportCat_Click(object sender, RoutedEventArgs en)
        {

        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            _objExcelSer = new ExcelDataService();
            try
            {
                var counter = _objExcelSer.ImportToDatabase();
                if(counter>0)
                {
                    MessageBox.Show(counter + Translations.AddedArticlesMessage);
                }
                else
                {
                    MessageBox.Show(Translations.NoArticlesAdded);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
