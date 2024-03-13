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
    /// Interaction logic for ucSearchId.xaml
    /// </summary>
    public partial class ucSearchId : UserControl
    {
        private ReceiptViewModel receiptVM = new ReceiptViewModel();
        private DetailReceiptViewModel detailReceiptVM = new DetailReceiptViewModel();
        private Receipt receipt = new Receipt();
        private DetailReceipt detailreceipt = new DetailReceipt();
        private ObservableCollection<Receipt> lstReceipt = new ObservableCollection<Receipt>();
        private ObservableCollection<DetailReceipt> lstdetailReceipt = new ObservableCollection<DetailReceipt>();
        private ObservableCollection<DetailReceipt> lstdetailReceiptTemp { get; set; }

        private Invoice invoice = new Invoice();
        private InvoiceViewModel InvoiceVM = new InvoiceViewModel();
        private ObservableCollection<Invoice> lstInvoice = new ObservableCollection<Invoice>();
        private ObservableCollection<DetailInvoice> lstdetailInvoice = new ObservableCollection<DetailInvoice>();
        private ObservableCollection<DetailInvoice> lstdetailInvoiceTemp { get; set; }
        private DetailInvoiceViewModel detailInvoiceVM = new DetailInvoiceViewModel();

        private Order order = new Order();
        private OrderViewModel OrderVM = new OrderViewModel();
        private ObservableCollection<Order> lstOrder = new ObservableCollection<Order>();
        private ObservableCollection<DetailOrder> lstdetailOrder = new ObservableCollection<DetailOrder>();
        private ObservableCollection<DetailOrder> lstdetailOrderTemp { get; set; }
        private DetailOrderViewModel detailOrderVM = new DetailOrderViewModel();
        ucDetailReceipt ucdetailreceipt { get; set; }
        ucDetailInvoice ucdetailinvoice { get; set; }
        ucDetailOrder ucdetailorder { get; set; }
        private int option = 0;

        public ucSearchId(int op)
        {
            InitializeComponent();
            option = op;
            lstReceipt = receiptVM.getList("/Receipts/Receipt");
            lstdetailReceipt = detailReceiptVM.getListByID("/DetailReceipts/DetailReceipt");

            lstInvoice = InvoiceVM.getList("/Invoices/Invoice");
            lstdetailInvoice = detailInvoiceVM.getListByID("/DetailInvoices/DetailInvoice");

            lstOrder = OrderVM.getList("/Orders/Order");
            lstdetailOrder = detailOrderVM.getListByID("/DetailOrders/DetailOrder");
        }

        public void DisplayDetail()
        {
            switch (option)
            {
                case 1:
                    lstdetailReceiptTemp = new ObservableCollection<DetailReceipt>();
                    for (int i = 0; i < lstdetailReceipt.Count; i++)
                    {
                        if (txtid.Text == lstdetailReceipt[i].IdReceipt)
                        {
                            lstdetailReceiptTemp.Add(lstdetailReceipt[i]);
                        }
                    }
                    ucdetailreceipt = new ucDetailReceipt(lstdetailReceiptTemp);
                    stackpanel.Children.Add(ucdetailreceipt);
                    break;
                case 2:
                    lstdetailInvoiceTemp = new ObservableCollection<DetailInvoice>();
                    for (int i = 0; i < lstdetailInvoice.Count; i++)
                    {
                        if (txtid.Text == lstdetailInvoice[i].IdInvoice)
                        {
                            lstdetailInvoiceTemp.Add(lstdetailInvoice[i]);
                        }
                    }
                    ucdetailinvoice = new ucDetailInvoice(lstdetailInvoiceTemp);
                    stackpanel.Children.Add(ucdetailinvoice);
                    break;
                case 3:
                    lstdetailOrderTemp = new ObservableCollection<DetailOrder>();
                    for (int i = 0; i < lstdetailOrder.Count; i++)
                    {
                        if (txtid.Text == lstdetailOrder[i].IdOrder)
                        {
                            lstdetailOrderTemp.Add(lstdetailOrder[i]);
                        }
                    }
                    ucdetailorder = new ucDetailOrder(lstdetailOrderTemp);
                    stackpanel.Children.Add(ucdetailorder);
                    break;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtid.Text == string.Empty)
                return;
            DisplayDetail();
        }
    }
}
