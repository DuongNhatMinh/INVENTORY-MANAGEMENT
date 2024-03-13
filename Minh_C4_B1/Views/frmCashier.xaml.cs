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

namespace Minh_C3_B1
{
    /// <summary>
    /// Interaction logic for frmCashier.xaml
    /// </summary>
    public partial class frmCashier : Window
    {
        frmLogin frmlogin { get; set; }
        DisplayPhieu ucDisplayPhieu { get; set; }
        ucViewOrder ucvieworder { get; set; }
        ucViewCustomer ucviewcustomer { get; set; }
        ucOutofStock ucoutofstock { get; set; }
        ucInventoryInvoice ucinvoice { get; set; }
        ucSearch ucsearch { get; set; }
        frmMessage frmmess { get; set; }
        ucEditCustomer uccreatecustomer { get; set; }
        private string Name = string.Empty;

        public frmCashier(string name)
        {
            InitializeComponent();
            Name = name;
            string str = string.Format("Wellcome {0}", Name);
            lbTrang.Content = str;
        }

        public void SelectedUserControl(int option)
        {
            stackPanel.Children.Clear();
            switch (option)
            {
                case 1:
                    this.Visibility = Visibility.Hidden;
                    frmlogin = new frmLogin();
                    frmlogin.Show();
                    break;
                case 2:
                    ucDisplayPhieu = new DisplayPhieu(Name, 3);
                    stackPanel.Children.Add(ucDisplayPhieu);
                    break;
                case 3:
                    ucvieworder = new ucViewOrder();
                    stackPanel.Children.Add(ucvieworder);
                    break;
                case 4:
                    ucviewcustomer = new ucViewCustomer();
                    stackPanel.Children.Add(ucviewcustomer);
                    break;
                case 5:
                    ucoutofstock = new ucOutofStock(2);
                    stackPanel.Children.Add(ucoutofstock);
                    break;
                case 6:
                    ucinvoice = new ucInventoryInvoice();
                    stackPanel.Children.Add(ucinvoice);
                    break;
                case 7:
                    ucsearch = new ucSearch(3);
                    ucsearch.lbTrang.Content = "Search Detail Order";
                    stackPanel.Children.Add(ucsearch);
                    break;
                case 8:
                    uccreatecustomer = new ucEditCustomer();
                    stackPanel.Children.Add(uccreatecustomer);
                    break;
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(1);
        }

        private void createOrder_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(2);
        }

        private void viewlistorder_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(3);
        }

        private void lstCustomer_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(4);
        }

        private void outofstock_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(5);
        }

        private void inventoryInvoice_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(6);
        }

        private void searchorder_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(7);
        }

        private void Createcustomer_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(8);
        }
    }
}
