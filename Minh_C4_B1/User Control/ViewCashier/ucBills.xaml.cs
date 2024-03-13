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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minh_C3_B1
{
    /// <summary>
    /// Interaction logic for ucBills.xaml
    /// </summary>
    public partial class ucBills : UserControl
    {
        private List<Order> lstOrder = new List<Order>();
        private ObservableCollection<DetailOrder> lstdetailOrder = new ObservableCollection<DetailOrder>();
        private Customer customer = new Customer();
        private Utilities ult = new Utilities();
        private double total = 0;
        public ucBills(object item, object item2, object item3)
        {
            InitializeComponent();
            lstOrder = item2 as List<Order>;
            lstdetailOrder = item as ObservableCollection<DetailOrder>;
            customer = item3 as Customer;
            DisplayCashier();
            DisplayCustomer();
            DisplayDetailOrder();
        }

        public void DisplayCashier()
        {
            string str;
            for (int i = 0; i < lstOrder.Count; i++)
            {
                lbName.Content = str = string.Format("Name: {0}", lstOrder[i].Username);
                lbDate.Content = str = string.Format("Date: {0}", lstOrder[i].CreateAt);
            }
        }

        public void DisplayCustomer()
        {
            string namecus = string.Format("Name: {0}", customer.Name);
            string phone = string.Format("Phone: {0}", customer.Phone.ToString());
            string point = string.Format("Point: {0}", customer.Point.ToString());
            string type = string.Format("Type: {0}", customer.CardType);
            lbcusname.Content = namecus;
            lbcusphone.Content = phone;
            lbcuspoint.Content = point;
            lbcustype.Content = type;
        }

        public void DisplayDetailOrder()
        {
            dtgBill.ItemsSource = lstdetailOrder;
            for (int i = 0; i < lstdetailOrder.Count; i++)
            {
                total += lstdetailOrder[i].Amount;
            }
            string str2 = string.Format("Total: {0}", ult.Convert(total));
            lbtotal.Content = str2;
        }
    }
}
