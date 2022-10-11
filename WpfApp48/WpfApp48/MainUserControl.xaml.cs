﻿using System;
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
    /// Interaction logic for MainUserControl.xaml
    /// </summary>
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
            _objExcelSer = new ExcelDataService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void uploadFile_Click(object sender, RoutedEventArgs e)
        {
            bool excelFile = _objExcelSer.OpenDialog();
            if (!excelFile)
                MessageBox.Show("Try again.");
        }

        private void mapData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Modal modal = new Modal();
                modal.ShowDialog();

                var columnItems = _objExcelSer.ManageModal(modal);
                if (columnItems != null)
                 columns = columnItems;

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
            try
            {
                var counter = _objExcelSer.ImportToDatabase();
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

        private void generateDiscount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Discounts modal = new Discounts();
                modal.ShowDialog();

                var discountItems = _objExcelSer.ManageDiscount(modal);
                if (discountItems != null)
                    discounts = discountItems;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}