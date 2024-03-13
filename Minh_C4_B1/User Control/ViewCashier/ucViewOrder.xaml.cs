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
    /// Interaction logic for ucViewOrder.xaml
    /// </summary>
    public partial class ucViewOrder : UserControl
    {
        private Order order { get; set; }
        private OrderViewModel OrderVM = new OrderViewModel();
        private ObservableCollection<Order> lstOrder = new ObservableCollection<Order>();
        private ObservableCollection<Order> lstOrdertemp
        {
            get; set;
        }
        private ObservableCollection<DetailOrder> lstdetailOrder = new ObservableCollection<DetailOrder>();
        private ObservableCollection<DetailOrder> lstdetailOrderTemp { get; set; }
        private DetailOrderViewModel detailOrderVM = new DetailOrderViewModel();

        public ucViewOrder()
        {
            InitializeComponent();
            lstOrder = OrderVM.getList("/Orders/Order");
            lstdetailOrder = detailOrderVM.getListByID("/DetailOrders/DetailOrder");
            DisplayDetail();
        }

        public void DisplayDetail()
        {
            lstOrdertemp = new ObservableCollection<Order>();
            for(int j = 0; j < lstOrder.Count; j++)
            {
                lstdetailOrderTemp = new ObservableCollection<DetailOrder>();
                for (int i = 0; i < lstdetailOrder.Count; i++)
                {
                    if (lstOrder[j].Id == lstdetailOrder[i].IdOrder)
                    {
                        lstdetailOrderTemp.Add(lstdetailOrder[i]);
                        order = new Order(lstOrder[j].Id, lstOrder[j].Username, lstOrder[j].Quantity, lstOrder[j].Total, lstOrder[j].CreateAt, lstdetailOrderTemp);
                    }
                }
                lstOrdertemp.Add(order);
            }
            dtgOrder.ItemsSource = lstOrdertemp;
        }
    }
}
