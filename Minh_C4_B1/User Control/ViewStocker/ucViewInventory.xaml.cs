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
    /// Interaction logic for ucViewInventory.xaml
    /// </summary>
    public partial class ucViewInventory : UserControl
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private int option;

        public ucViewInventory(int op)
        {
            InitializeComponent();
            InventoryReceipt = InventoryVM.getList("/Inventorys/Inventory", "data/Inventory/InventoryReceipt.xml");
            InventoryInvoice = InventoryVM.getList("/Inventorys/Inventory", "data/Inventory/InventoryInvoice.xml");
            option = op;
            Display();
        }

        public void Display()
        {
            dtgInventory.ItemsSource = null;
            switch (option)
            {
                case 1:
                    lbTrang.Content = "View Inventory Receipt";
                    dtgInventory.ItemsSource = InventoryReceipt;
                    break;
                case 2:
                    lbTrang.Content = "View Inventory Invoice";
                    dtgInventory.ItemsSource = InventoryInvoice;
                    break;
            }
        }
    }
}
