using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for frmMessage.xaml
    /// </summary>
    public partial class frmMessage : Window
    {
        private List<Account> lstacc { get; set; }
        private AccountViewModel accVM { get; set; }
        private List<Customer> lstCustomer = new List<Customer>();
        private CustomerViewModel CustomerVM = new CustomerViewModel();
        public ucEditUser ucedit { get; set; }
        object valuetemp;
        public int check = 0, option = 0;

        public frmMessage(object Value, int op)
        {
            InitializeComponent();
            option = op;
            lstacc = new List<Account>();
            accVM = new AccountViewModel();
            lstacc = accVM.getList("/Accounts/Account");
            lstCustomer = CustomerVM.getList("/Customers/Customer");
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            valuetemp = Value;
            SelectedUserControl(op);
        }

        public void SelectedUserControl(int option)
        {
            stackpanel.Children.Clear();
            switch (option)
            {
                case 1:
                    ucedit = new ucEditUser(valuetemp);
                    stackpanel.Children.Add(ucedit);
                    break;
            }
        }

        public int isExist(int op)
        {
            switch (op)
            {
                case 1:
                    for (int i = 0; i < lstacc.Count; i++)
                    {
                        if (ucedit.txtName.Text == lstacc[i].UserName /*|| ucedit.txtPass.Text == lstacc[i].Password*/)
                            return 1;
                    }
                    return 2;
            }
            return 0;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            int exist;
            switch (option)
            {
                case 1:
                    exist = isExist(1);
                    if (exist == 1)
                    {
                        MessageBox.Show("Already Exist");
                        return;
                    }
                    else
                    {
                        this.Close();
                        check = 1;
                    }
                    break;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            check = 2;
        }
    }
}
