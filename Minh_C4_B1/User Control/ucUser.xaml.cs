using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for ucUser.xaml
    /// </summary>
    public partial class ucUser : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<Account> _Account;
        private ObservableCollection<Account> lstAcc
        {
            get { return _Account; }
            set
            {
                _Account = value;
                OnPropertyChanged();
            }
        }

        private AccountViewModel accVM { get; set; }
        frmMessage frmmess { get; set; }

        public ucUser()
        {
            InitializeComponent();
            accVM = new AccountViewModel();
            accVM.getList();
            lstAcc = new ObservableCollection<Account>(accVM.accRepo.Items);
            dtgAccount.ItemsSource = lstAcc;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Account;
            if(item.UserName != "admin")
            {
                frmmess = new frmMessage(item, 1);
                frmmess.ShowDialog();
                if (frmmess.check == 1)
                {
                    string xpath = string.Format("Account[@Username='{0}']", item.UserName);
                    Account newacc = new Account(frmmess.ucedit.txtName.Text, frmmess.ucedit.txtPass.Text, item.Status);
                    accVM.Update(xpath, newacc);
                    lstAcc[dtgAccount.SelectedIndex].UserName = frmmess.ucedit.txtName.Text;
                    lstAcc[dtgAccount.SelectedIndex].Password = frmmess.ucedit.txtPass.Text;
                }
                else
                {
                    return;
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Account;
            string str = string.Format("You want Lock {0} ?", item.UserName);
            if (item.Status != 1 && item.UserName != "admin")
            {
                MessageBoxResult result = MessageBox.Show(str, "Delete", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (item != null)
                        {
                            string xpath = string.Format("Account[@Username='{0}']", item.UserName);
                            accVM.Update(xpath, 1);
                            lstAcc[dtgAccount.SelectedIndex].Status = 1;
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            frmmess = new frmMessage(0, 1);
            frmmess.ShowDialog();
            if (frmmess.check == 1)
            {
                Account newacc = new Account(frmmess.ucedit.txtName.Text, frmmess.ucedit.txtPass.Text, 0);
                accVM.Create(newacc);
                lstAcc.Add(newacc);
            }
            else
            {
                return;
            }
        }

        private void btnUnLock_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Account;
            string str = string.Format("You want Unlock {0} ?", item.UserName);
            if (item.Status != 0 && item.UserName != "admin")
            {
                MessageBoxResult result = MessageBox.Show(str, "Delete", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (item != null)
                        {
                            string xpath = string.Format("Account[@Username='{0}']", item.UserName);
                            accVM.Update(xpath, 0);
                            lstAcc[dtgAccount.SelectedIndex].Status = 0;
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
           
        }
    }
}
