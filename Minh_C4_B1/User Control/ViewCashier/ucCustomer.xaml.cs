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

namespace Minh_C3_B1
{
    /// <summary>
    /// Interaction logic for ucCustomer.xaml
    /// </summary>
    public partial class ucCustomer : UserControl
    {
        private Customer customer = new Customer();
        private List<Customer> lstCustomer = new List<Customer>();
        private CustomerViewModel CustomerVM = new CustomerViewModel();
        private Order order = new Order();
        ucCreateOrder uccreateOrder { get; set; }
        public string id, name;

        public ucCustomer(string Id, string Name, object item)
        {
            InitializeComponent();
            id = Id;
            name = Name;
            order = item as Order;
            lstCustomer = CustomerVM.getList("/Customers/Customer");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i <lstCustomer.Count; i++)
            {
                if(lstCustomer[i].CardID == "000")
                {
                    stackpanel.Children.Clear();
                    uccreateOrder = new ucCreateOrder(id, name, lstCustomer[i], order);
                    stackpanel.Children.Add(uccreateOrder);
                }
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < lstCustomer.Count; i++)
            {
                if (lstCustomer[i].CardID == txtID.Text)
                {
                    stackpanel.Children.Clear();
                    uccreateOrder = new ucCreateOrder(id, name, lstCustomer[i], order);
                    stackpanel.Children.Add(uccreateOrder);
                }
            }
        }
    }
}
