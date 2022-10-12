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

namespace WpfApp48
{
    /// <summary>
    /// Interaction logic for RuleItems.xaml
    /// </summary>
    public partial class RuleItems : Window
    {

        public static string discountName = String.Empty;
        public RuleItems()
        {
            InitializeComponent();
        }

        private void btnCloseItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSaveItem_Click(object sender, RoutedEventArgs e)
        {
            discountName = discount.Text;

            Close();
        }
    }
}
