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
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        private Account acc { get; set; }
        private AccountViewModel accVM { get; set; }
        private Utilities ult { get; set; }
        private frmStocker frmstocker { get; set; }
        private frmCashier frmcashier { get; set; }
        private frmAdmin frmadmin { get; set; }
        public frmLogin()
        {
            InitializeComponent();
            acc = new Account();
            accVM = new AccountViewModel();
            ult = new Utilities();
            accVM.getList("/Accounts/Account");
            this.txtUsername.Focus();
        }

        public void Login()
        {
            int check;
            check = accVM.Compare(txtUsername.Text, pwbPassword.Password);
            if (check == -1)
                ult.Notify();
            switch (check)
            {
                case 0:
                    frmadmin = new frmAdmin(txtUsername.Text);
                    frmadmin.Show();
                    this.Close();
                    break;
                case 1:
                    frmstocker = new frmStocker(txtUsername.Text);
                    frmstocker.Show();
                    this.Close();
                    break;
                case 2:
                    frmcashier = new frmCashier(txtUsername.Text);
                    frmcashier.Show();
                    this.Close();
                    break;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
            txtUsername.Text = acc.UserName;
            pwbPassword.Password = acc.Password;
            this.txtUsername.Focus();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
                txtUsername.Text = acc.UserName;
                pwbPassword.Password = acc.Password;
                this.txtUsername.Focus();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
