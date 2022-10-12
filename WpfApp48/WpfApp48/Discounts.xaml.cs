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
    /// Interaction logic for Discounts.xaml
    /// </summary>
    public partial class Discounts : Window
    {
        public static DiscountDisplayVM viewmodel;
        public static ExcelDataService _objDataService;
        public Discounts()
        {
            InitializeComponent();
            _objDataService = new ExcelDataService();
        }

        private void btnSaveDiscount_Click(object sender, RoutedEventArgs e)
        {
            viewmodel = new DiscountDisplayVM
            {
                Id = Guid.NewGuid(),
                Value = discountName.Text,
                Type = type.Text,
                isActive = Active.IsChecked,
                isExecuted = Executed.IsChecked,
                validFrom = validFrom.SelectedDate.Value,
                validTo = validTo.SelectedDate.Value
            };

            if (viewmodel != null)
                _objDataService.SaveDiscountToDatabase(viewmodel);
        }

        private void btnCloseDiscount_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
