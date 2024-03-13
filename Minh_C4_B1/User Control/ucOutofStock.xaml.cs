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
    /// Interaction logic for ucOutofStock.xaml
    /// </summary>
    public partial class ucOutofStock : UserControl
    {
        private InventoryViewModel InventoryVM = new InventoryViewModel();
        private ObservableCollection<Inventory> _InventoryReceipt;
        private ObservableCollection<Inventory> InventoryReceipt
        {
            get { return _InventoryReceipt; }
            set
            {
                _InventoryReceipt = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Inventory> _InventoryInvoice;
        private ObservableCollection<Inventory> InventoryInvoice
        {
            get { return _InventoryInvoice; }
            set
            {
                _InventoryInvoice = value;
                OnPropertyChanged();
            }
        }
        private Inventory InventoryReceiptTemp { get; set; }
        private Inventory InventoryInvoiceTemp { get; set; }
        private ObservableCollection<Inventory> InventoryTemp { get; set; }
        private Utilities ult = new Utilities();
        private ObservableCollection<DetailOrder> lstdetailOrder = new ObservableCollection<DetailOrder>();
        private ObservableCollection<DetailOrder> lstdetailOrderTemp { get; set; }
        private DetailOrderViewModel detailOrderVM = new DetailOrderViewModel();
        const int max = 5;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ucOutofStock(int op)
        {
            InitializeComponent();
            int idx = 0;
            switch (op)
            {
                case 1:
                    InventoryReceipt = InventoryVM.getList("/Inventorys/Inventory", "data/Inventory/InventoryReceipt.xml");
                    InventoryInvoice = InventoryVM.getList("/Inventorys/Inventory", "data/Inventory/InventoryInvoice.xml");
                    InventoryTemp = new ObservableCollection<Inventory>();
                    for (int i = 0; i < InventoryReceipt.Count; i++)
                    {
                        idx = ult.getIndex(InventoryInvoice, InventoryReceipt[i].Product);
                        if(idx == -1)
                        {
                            InventoryTemp.Add(InventoryReceipt[i]);
                        }
                        else
                        {
                            if ((InventoryReceipt[i].Quantity - InventoryInvoice[idx].Quantity) <= max)
                            {
                                InventoryReceiptTemp = new Inventory(InventoryReceipt[i].Id, InventoryReceipt[i].Product, 0, 0, (InventoryReceipt[i].Quantity - InventoryInvoice[idx].Quantity));
                                InventoryTemp.Add(InventoryReceiptTemp);
                            }
                        }
                        dtgInventory.ItemsSource = InventoryTemp;
                    }
                    break;
                case 2:
                    lstdetailOrder = detailOrderVM.getListByID("/DetailOrders/DetailOrder");
                    InventoryInvoice = InventoryVM.getList("/Inventorys/Inventory", "data/Inventory/InventoryInvoice.xml");
                    InventoryTemp = new ObservableCollection<Inventory>();
                    for (int i = 0; i < InventoryInvoice.Count; i++)
                    {
                        idx = ult.getIndex(lstdetailOrder, InventoryInvoice[i].Product);
                        if(idx == -1)
                        {
                            InventoryTemp.Add(InventoryInvoice[i]);
                        }
                        else
                        {
                            if ((InventoryInvoice[i].Quantity - lstdetailOrder[idx].Quantity) <= max)
                            {
                                InventoryInvoiceTemp = new Inventory(InventoryInvoice[i].Id, InventoryInvoice[i].Product, 0, 0, (InventoryInvoice[i].Quantity - lstdetailOrder[idx].Quantity));
                                InventoryTemp.Add(InventoryInvoiceTemp);
                            }
                        }
                        dtgInventory.ItemsSource = InventoryTemp;
                    }
                    break;
            }
            
        }
    }
}
