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
    /// Interaction logic for DisplayPhieu.xaml
    /// </summary>
    public partial class DisplayPhieu : UserControl
    {
        const int op = 0;
        ucCreateReceipt uccreateRecept { get; set; }
        uccreateInvoice ucCreateInvoice { get; set; }
        ucCustomer uccustomer { get; set; }
        Receipt receipt { get; set; }
        Invoice invoice { get; set; }
        Order order { get; set; }
        private Utilities ult = new Utilities();
        public string id, name, date;
        public string Idtemp, Nametemp;
        public int option;

        public DisplayPhieu(string Name, int op)
        {
            InitializeComponent();
            receipt = ult.getReceipt(Name);
            invoice = ult.getInvoice(Name);
            order = ult.getOrder(Name);
            option = op;
            switch (op)
            {
                case 1:
                    id = string.Format("Id: {0}", receipt.Id);
                    name = string.Format("Name: {0}", receipt.Username);
                    date = string.Format("Date: {0}", receipt.CreateAt);
                    Idtemp = receipt.Id;
                    Nametemp = receipt.Username;
                    break;
                case 2:
                    id = string.Format("Id: {0}", invoice.Id);
                    name = string.Format("Name: {0}", invoice.Username);
                    date = string.Format("Date: {0}", invoice.CreateAt);
                    Idtemp = invoice.Id;
                    Nametemp = invoice.Username;
                    break;
                case 3:
                    id = string.Format("Id: {0}", order.Id);
                    name = string.Format("Name: {0}", order.Username);
                    date = string.Format("Date: {0}", order.CreateAt);
                    Idtemp = order.Id;
                    Nametemp = order.Username;
                    break;
            }
            lbId.Content = id;
            lbName.Content = name;
            lbDate.Content = date;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            stackpanel.Children.Clear();
            switch (option)
            {
                case 1:
                    uccreateRecept = new ucCreateReceipt(Idtemp, Nametemp, receipt);
                    stackpanel.Children.Add(uccreateRecept);
                    break;
                case 2:
                    ucCreateInvoice = new uccreateInvoice(Idtemp, Nametemp, invoice);
                    stackpanel.Children.Add(ucCreateInvoice);
                    break;
                case 3:
                    uccustomer = new ucCustomer(Idtemp, Nametemp, order);
                    stackpanel.Children.Add(uccustomer);
                    break;
            }
        }
    }
}
