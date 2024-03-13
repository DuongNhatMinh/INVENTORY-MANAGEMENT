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
    /// Interaction logic for ucStatistical.xaml
    /// </summary>
    public partial class ucStatistical : UserControl
    {
        private DetailReceiptViewModel detailReceiptVM = new DetailReceiptViewModel();
        private ObservableCollection<DetailReceipt> lstdetailReceipt = new ObservableCollection<DetailReceipt>();

        private Order order = new Order();
        private OrderViewModel OrderVM = new OrderViewModel();
        private ObservableCollection<Order> lstOrder = new ObservableCollection<Order>();
        private ObservableCollection<DetailOrder> lstdetailOrder = new ObservableCollection<DetailOrder>();
        private ObservableCollection<DetailOrder> lstdetailOrderTemp { get; set; }
        private DetailOrderViewModel detailOrderVM = new DetailOrderViewModel();
        private Utilities ult = new Utilities();
        ucDetailOrder ucdetailorder { get; set; }

        public ucStatistical()
        {
            InitializeComponent();
            lstOrder = OrderVM.getList("/Orders/Order");
            lstdetailOrder = detailOrderVM.getListByID("/DetailOrders/DetailOrder");
            lstdetailReceipt = detailReceiptVM.getListByID("/DetailReceipts/DetailReceipt");
        }

        public void ThongKe()
        {
            lstdetailOrderTemp = new ObservableCollection<DetailOrder>();
            stackpanel.Children.Clear();
            string[] date;
            string[] dateinput;
            double Quantity = 0, revenue = 0, profit = 0;
            string str, str2;
            DateTime date2 = DateTime.Now;
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            do
            {
                date2 = Convert.ToDateTime(datesearch.SelectedDate);
            } while (date2.Year == 1900);
            Console.WriteLine("Id\tIdReceipt\tIdProduct\tName\t\tCategory\tPriceInput\tPriceOutput\tQuantity\tAmount");
            for (int i = 0; i < lstOrder.Count; i++)
            {
                date = lstOrder[i].CreateAt.GetDateTimeFormats('d', culture);
                dateinput = date2.GetDateTimeFormats('d', culture);
                if (date[0] == dateinput[0])
                {
                    Quantity += lstOrder[i].Quantity;
                    revenue += lstOrder[i].Total;
                    for (int j = 0; j < lstdetailOrder.Count; j++)
                    {
                        if (lstdetailOrder[j].IdOrder == lstOrder[i].Id)
                        {
                            profit += ult.getProfit(lstdetailOrder[j], lstdetailReceipt);
                            lstdetailOrderTemp.Add(lstdetailOrder[j]);
                        }

                    }
                }
            }
            ucdetailorder = new ucDetailOrder(lstdetailOrderTemp);
            stackpanel.Children.Add(ucdetailorder);
            str = string.Format("Revenue: {0}", ult.Convert(revenue));
            str2 = string.Format("Profit: {0}", ult.Convert(profit));
            txtblDoanhThu.Text = str;
            txtblLoiNhuan.Text = str2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThongKe();
        }
    }
}
