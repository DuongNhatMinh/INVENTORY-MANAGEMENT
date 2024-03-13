using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for ucInventoryInvoice.xaml
    /// </summary>
    public partial class ucInventoryInvoice : UserControl
    {
        private Inventory InventoryTemp { get; set; }
        private InventoryViewModel InventoryVM = new InventoryViewModel();
        
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

        private ObservableCollection<Inventory> _Inventory;
        private ObservableCollection<Inventory> Inventorys
        {
            get { return _Inventory; }
            set
            {
                _Inventory = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<DetailOrder> lstdetailOrder = new ObservableCollection<DetailOrder>();
        private ObservableCollection<DetailOrder> lstdetailOrderTemp { get; set; }
        private DetailOrderViewModel detailOrderVM = new DetailOrderViewModel();
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private Utilities ult = new Utilities();

        public ucInventoryInvoice()
        {
            InitializeComponent();
            lstdetailOrder = detailOrderVM.getListByID("/DetailOrders/DetailOrder");
            InventoryInvoice = InventoryVM.getList("/Inventorys/Inventory", "data/Inventory/InventoryInvoice.xml");
            Inventorys = new ObservableCollection<Inventory>();
            int idx = 0;
            double quantity = 0;
            if (InventoryInvoice.Count != 0)
            {
                for (int i = 0; i < InventoryInvoice.Count; i++)
                {
                    idx = ult.getIndex(lstdetailOrder, InventoryInvoice[i].Product);
                    quantity = ult.getQuantity(lstdetailOrder, InventoryInvoice[i].Product);
                    if (idx != -1)
                    {
                        InventoryTemp = new Inventory(InventoryInvoice[i].Id, InventoryInvoice[i].Product, InventoryInvoice[i].Quantity,
                            quantity, (InventoryInvoice[i].Quantity - quantity));
                    }
                    else
                    {
                        InventoryTemp = new Inventory(InventoryInvoice[i].Id, InventoryInvoice[i].Product, InventoryInvoice[i].Quantity,
                           0, InventoryInvoice[i].Quantity);
                    }
                    Inventorys.Add(InventoryTemp);
                }
            }
            dtgInventory.ItemsSource = Inventorys;
        }
    }
}
