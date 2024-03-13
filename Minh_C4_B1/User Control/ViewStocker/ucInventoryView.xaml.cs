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
    /// Interaction logic for ucInventoryView.xaml
    /// </summary>
    public partial class ucInventoryView : UserControl
    {
        private Inventory InventoryTemp { get; set; }
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private Utilities ult = new Utilities();

        public ucInventoryView()
        {
            InitializeComponent();
            InventoryReceipt = InventoryVM.getList("/Inventorys/Inventory", "data/Inventory/InventoryReceipt.xml");
            InventoryInvoice = InventoryVM.getList("/Inventorys/Inventory", "data/Inventory/InventoryInvoice.xml");
            Inventorys = new ObservableCollection<Inventory>();
            int idx = 0;
            if (InventoryInvoice.Count != 0)
            {
                for (int i = 0; i < InventoryReceipt.Count; i++)
                {
                    idx = ult.getIndex(InventoryInvoice, InventoryReceipt[i].Product);
                    if (idx != -1)
                    {
                        InventoryTemp = new Inventory(InventoryReceipt[i].Id, InventoryReceipt[i].Product, InventoryReceipt[i].Quantity,
                            InventoryInvoice[idx].Quantity, (InventoryReceipt[i].Quantity - InventoryInvoice[idx].Quantity));
                    }
                    else
                    {
                        InventoryTemp = new Inventory(InventoryReceipt[i].Id, InventoryReceipt[i].Product, InventoryReceipt[i].Quantity,
                           0, InventoryReceipt[i].Quantity);
                    }
                    Inventorys.Add(InventoryTemp);
                }
            }
            dtgInventory.ItemsSource = Inventorys;
        }
    }
}
