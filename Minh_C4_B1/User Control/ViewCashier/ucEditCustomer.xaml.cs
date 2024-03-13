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
    /// Interaction logic for ucEditCustomer.xaml
    /// </summary>
    public partial class ucEditCustomer : UserControl
    {
        private Customer customer = new Customer();
        private List<Customer> lstCustomer = new List<Customer>();
        private CustomerViewModel CustomerVM = new CustomerViewModel();

        public ucEditCustomer()
        {
            InitializeComponent();
            lstCustomer = CustomerVM.getList("/Customers/Customer");
        }

        public int isExist()
        {
            for (int i = 0; i < lstCustomer.Count; i++)
            {
                if (txtId.Text == lstCustomer[i].CardID)
                    return 1;
            }
            return 2;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            int exist;
            exist = isExist();
            if(txtId.Text == string.Empty || txtName.Text == string.Empty || txtPhone.Text == string.Empty)
            {
                MessageBox.Show("Not Empty");
                return;
            }
            if (exist == 1)
            {
                MessageBox.Show("ID Already Exist");
                return;
            }
            else
            {
                string str = string.Format("You want Add {0} ?", customer.Name);
                MessageBoxResult result = MessageBox.Show(str, "Add", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (customer != null)
                        {
                            customer = new Customer(txtName.Text, txtPhone.Text, txtId.Text, 0, "None");
                            CustomerVM.Create(customer);
                            MessageBox.Show("Add Successfully");
                            txtId.Text = string.Empty;
                            txtName.Text = string.Empty;
                            txtPhone.Text = string.Empty;
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private void txtPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int key = (int)e.Key;

            e.Handled = !(key >= 34 && key <= 43 ||
                          key >= 74 && key <= 83 ||
                          key == 2);
        }
    }
}
