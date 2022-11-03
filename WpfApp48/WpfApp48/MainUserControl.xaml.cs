using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using WpfApp48.Modals;
using WpfApp48.Resources;
using WpfApp48.Services;
using WpfApp48.ViewModels;

namespace WpfApp48
{
    /// <summary>
    /// Interaction logic for MainUserControl.xaml
    /// </summary>
    /// 80582710408070
    public partial class MainUserControl : UserControl
    {
        public static ExcelDataService _objExcelSer;
        public static string excelFile;

        public static ArticleDisplayVM columns { get; set; }
        public static DiscountDisplayVM discounts { get; set; }


        public MainUserControl()
        {
            InitializeComponent();
            dataGridArticle.Visibility = Visibility.Hidden;
            datagrid1.Visibility = Visibility.Hidden;
            _objExcelSer = new ExcelDataService();
        }


        private void uploadFile_Click(object sender, RoutedEventArgs e)
        {
            bool excelFile = _objExcelSer.OpenDialog().Result;
            if (!excelFile)
                MessageBox.Show("Try again.");
        }

        private void mapData_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                ModalSheets modalSheets = new ModalSheets();
                modalSheets.ShowDialog();

                App.Current.Properties["SheetName"] = _objExcelSer.GetSheetName(modalSheets);

               if(App.Current.Properties["SheetName"] != null)
                {
                    Modal modal = new Modal();
                    modal.ShowDialog();

                    var columnItems = _objExcelSer.ManageModal(modal).Result;
                    if (columnItems != null)
                        columns = columnItems;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void displayData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGridArticle.ItemsSource = _objExcelSer.ReadFromExcel(columns).Result;
                dataGridArticle.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void importToDatabase_Click(object sender, RoutedEventArgs e)
        {
            datagrid1.Visibility = Visibility.Hidden;
            try
            {
                dataGridArticle.ItemsSource = _objExcelSer.ReadFromExcel(columns).Result;
                dataGridArticle.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if(dataGridArticle.ItemsSource != null)
            {
                try
                {
                    var counter = _objExcelSer.ImportToDatabase().Result;
                    if (counter > 0)
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

        private void generateDiscount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Discounts modal = new Discounts();
                modal.ShowDialog();

                var discountItems = _objExcelSer.ManageDiscount(modal);
                if (discountItems != null)
                    discounts = discountItems.Result;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addToDiscount_Click(object sender, RoutedEventArgs e)
        {
            List<ArticleDisplayVM> list = new List<ArticleDisplayVM>();
            string discName = String.Empty;

            if (dataGridArticle.SelectedItems.Count > 0)
            {
                for (int i = 0; i < dataGridArticle.SelectedItems.Count; i++)
                {
                    list.Add((ArticleDisplayVM)dataGridArticle.SelectedItems[i]);
                }

                RuleItems modal = new RuleItems();
                modal.ShowDialog();

                if (RuleItems.discountName != String.Empty)
                    discName = RuleItems.discountName;

                _objExcelSer.AddDiscountToArticle(list, discName);
            }

        }

        private void OnDataSelectAll(object sender, RoutedEventArgs e)
        {
            datagrid1.Focus();
            datagrid1.SelectAll();
        }

        private void showData_Click(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT Id, Name, Price, Barcode, ArticleNumber";

            try
            {
                using (SqlConnection conn = new SqlConnection(Translations.ConfigurationModel))
                using (SqlCommand cmd = new SqlCommand("select Id, Name, Price, BarCode from Articles", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        datagrid1.ItemsSource = dataTable.DefaultView;
                    }
                }

                datagrid1.Visibility = Visibility.Visible;
                dataGridArticle.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
