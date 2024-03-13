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
    /// Interaction logic for ucHome.xaml
    /// </summary>
    public partial class ucHome : UserControl
    {
        private List<Account> lstacc = new List<Account>();
        private AccountViewModel accVM = new AccountViewModel();
        private ObservableCollection<Receipt> lstReceipt = new ObservableCollection<Receipt>();
        private ReceiptViewModel receiptVM = new ReceiptViewModel();
        private ObservableCollection<Invoice> lstInvoice = new ObservableCollection<Invoice>();
        private InvoiceViewModel InvoiceVM = new InvoiceViewModel();
        private ObservableCollection<Order> lstOrder = new ObservableCollection<Order>();
        private OrderViewModel OrderVM = new OrderViewModel();
        private ObservableCollection<ElectronicProduct> lstElec { get; set; }
        private ElectricViewModel electricVM = new ElectricViewModel();
        private ObservableCollection<FoodProduct> lstFood { get; set; }
        private FoodViewModel foodVM = new FoodViewModel();
        private ObservableCollection<PorcelainProduct> lstPorcelain { get; set; }
        private PorcelainViewModel porcelainVM = new PorcelainViewModel();
        private ObservableCollection<DetailOrder> lstdetailOrder = new ObservableCollection<DetailOrder>();
        private DetailOrderViewModel detailOrderVM = new DetailOrderViewModel();
        private ObservableCollection<DetailReceipt> lstdetailReceipt = new ObservableCollection<DetailReceipt>();
        private DetailReceiptViewModel detailReceiptVM = new DetailReceiptViewModel();
        private Utilities ult = new Utilities();
        private double Quantity = 0;
        private IFormatProvider culture;

        public ucHome()
        {
            InitializeComponent();
            lstacc = accVM.getList("/Accounts/Account");
            lstReceipt = receiptVM.getList("/Receipts/Receipt");
            lstInvoice = InvoiceVM.getList("/Invoices/Invoice");
            lstOrder = OrderVM.getList("/Orders/Order");
            lstdetailOrder = detailOrderVM.getListByID("/DetailOrders/DetailOrder");
            lstdetailReceipt = detailReceiptVM.getListByID("/DetailReceipts/DetailReceipt");
            electricVM.getList();
            lstElec = new ObservableCollection<ElectronicProduct>(electricVM.elecRepo.Items);
            foodVM.getList();
            lstFood = new ObservableCollection<FoodProduct>(foodVM.foodRepo.Items);
            porcelainVM.getList();
            lstPorcelain = new ObservableCollection<PorcelainProduct>(porcelainVM.porcelainRepo.Items);

            Quantity = lstElec.Count + lstFood.Count + lstPorcelain.Count;
            lbUser.Content = lstacc.Count.ToString();
            lbReceipt.Content = lstReceipt.Count.ToString();
            lbInvoice.Content = lstInvoice.Count.ToString();
            lbOrder.Content = lstOrder.Count.ToString();
            lbProduct.Content = Quantity.ToString();
            ThongKe();
        }

        public void ThongKe()
        {
            string[] date;
            string[] datenow;
            double Quantity = 0, revenue = 0, profit = 0;
            DateTime date2 = DateTime.Now;
            for (int i = 0; i < lstOrder.Count; i++)
            {
                //Quantity += lstOrder[i].Quantity;
                //revenue += lstOrder[i].Total;
                //for (int j = 0; j < lstdetailOrder.Count; j++)
                //{
                //    if (lstdetailOrder[j].IdOrder == lstOrder[i].Id)
                //    {
                //        profit += ult.getProfit(lstdetailOrder[j], lstdetailReceipt);
                //    }
                //}
                date = lstOrder[i].CreateAt.GetDateTimeFormats('d', culture);
                datenow = date2.GetDateTimeFormats('d', culture);
                if (date[0] == datenow[0])
                {
                    Quantity += lstOrder[i].Quantity;
                    revenue += lstOrder[i].Total;
                    for (int j = 0; j < lstdetailOrder.Count; j++)
                    {
                        if (lstdetailOrder[j].IdOrder == lstOrder[i].Id)
                        {
                            profit += ult.getProfit(lstdetailOrder[j], lstdetailReceipt);
                        }
                    }
                }
            } 
            lbDoanhThu.Content = ult.Convert(revenue);
            lbLoiNhuan.Content = ult.Convert(profit);
        }
    }
}
