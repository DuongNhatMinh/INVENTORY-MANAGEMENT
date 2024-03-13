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
    /// Interaction logic for ucViewCustomer.xaml
    /// </summary>
    public partial class ucViewCustomer : UserControl
    {
        private Customer customer = new Customer();
        private List<Customer> lstCustomer = new List<Customer>();
        private CustomerViewModel CustomerVM = new CustomerViewModel();

        public ucViewCustomer()
        {
            InitializeComponent();
            lstCustomer = CustomerVM.getList("/Customers/Customer");
            dtgCustomer.ItemsSource = lstCustomer;
        }
    }
}
