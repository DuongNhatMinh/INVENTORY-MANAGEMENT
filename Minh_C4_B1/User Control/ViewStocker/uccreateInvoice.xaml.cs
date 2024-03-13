
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for uccreateInvoice.xaml
    /// </summary>
    public partial class uccreateInvoice : UserControl
    {
        private Invoice invoice = new Invoice();
        private List<Invoice> lstInvoice = new List<Invoice>();
        private DetailInvoice detailInvoice = new DetailInvoice();
        private List<FoodProduct> lstFoodExp = new List<FoodProduct>();
        private ObservableCollection<DetailInvoice> _lstdetailInvoice;
        private ObservableCollection<DetailInvoice> lstdetailInvoice
        {
            get { return _lstdetailInvoice; }
            set
            {
                _lstdetailInvoice = value;
                OnPropertyChanged();
            }
        }
        private Utilities ult = new Utilities();
        private DetailInvoiceViewModel detailInvoiceVM = new DetailInvoiceViewModel();
        private DetailReceiptViewModel detailReceiptVM = new DetailReceiptViewModel();
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
        private ObservableCollection<Inventory> InventoryReceiptTemp = new ObservableCollection<Inventory>();
        private FoodViewModel foodVM = new FoodViewModel();
        private InvoiceViewModel InvoiceVM = new InvoiceViewModel();
        private ObservableCollection<DetailReceipt> lstdetailReceipt = new ObservableCollection<DetailReceipt>();
        private ObservableCollection<Inventory> InventoryInvoice = new ObservableCollection<Inventory>();
        private Invoice invoicetemp = new Invoice();
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private object resultString;
        DisplayPhieu ucDisplay { get; set; }
        private double quantity = 0, total = 0, totalquantity = 0;
        public int id2 = 1, id = 0;
        public int option = 0;
        public string idPNK, name;

        public uccreateInvoice(string Id, string Name, object item)
        {
            InitializeComponent();
            idPNK = Id;
            name = Name;
            invoicetemp = item as Invoice;
            string strid = string.Format("Id: {0}", invoicetemp.Id);
            string strname = string.Format("Name: {0}", invoicetemp.Username);
            string strdate = string.Format("Date: {0}", invoicetemp.CreateAt);
            lbid.Content = strid;
            lbname.Content = strname;
            lbdate.Content = strdate;
            getId();
            lstdetailReceipt = detailReceiptVM.getListByID("/DetailReceipts/DetailReceipt");
            InventoryReceipt = InventoryVM.getList("/Inventorys/Inventory", "data/Inventory/InventoryReceipt.xml");
            InventoryInvoice = InventoryVM.getList("/Inventorys/Inventory", "data/Inventory/InventoryInvoice.xml");
            lstdetailInvoice = new ObservableCollection<DetailInvoice>();
            Display();
        }

        public void getId()
        {
            resultString = Regex.Match(idPNK, @"\d+").Value;
            id = Int32.Parse(resultString.ToString());
        }

        public void Display()
        {
            double amount;
            int idx = 0;
            Inventory inventorytemp = new Inventory();
            if (InventoryInvoice.Count != 0)
            {
                for (int i = 0; i < InventoryReceipt.Count; i++)
                {
                    idx = ult.getIndex(InventoryInvoice, InventoryReceipt[i].Product);
                    double price = ult.PriceOutput((InventoryReceipt[i].AmountRecent / InventoryReceipt[i].Recent));
                    if (idx != -1)
                    {
                        //amount = (InventoryReceipt[i].AmountRecent / InventoryReceipt[i].Recent) * (InventoryReceipt[i].Quantity - InventoryInvoice[idx].Quantity);
                        inventorytemp = new Inventory(InventoryReceipt[i].Id, InventoryReceipt[i].Product, InventoryReceipt[i].Previous, InventoryReceipt[i].AmountPrevious
                            , InventoryReceipt[i].Recent, InventoryReceipt[i].AmountRecent, InventoryReceipt[i].Date, (InventoryReceipt[i].Quantity - InventoryInvoice[idx].Quantity), price);
                        InventoryReceiptTemp.Add(inventorytemp);
                        dtgProduct.ItemsSource = InventoryReceiptTemp;
                    }
                    else
                    {
                        //amount = (InventoryReceipt[i].AmountRecent / InventoryReceipt[i].Recent) * InventoryReceipt[i].Quantity;
                        inventorytemp = new Inventory(InventoryReceipt[i].Id, InventoryReceipt[i].Product, InventoryReceipt[i].Previous, InventoryReceipt[i].AmountPrevious
                            , InventoryReceipt[i].Recent, InventoryReceipt[i].AmountRecent, InventoryReceipt[i].Date, InventoryReceipt[i].Quantity, price);
                        InventoryReceiptTemp.Add(inventorytemp);
                        dtgProduct.ItemsSource = InventoryReceiptTemp;
                    }
                }
            }
            else
            {
                for (int i = 0; i < InventoryReceipt.Count; i++)
                {
                    double price = ult.PriceOutput((InventoryReceipt[i].AmountRecent / InventoryReceipt[i].Recent));
                    inventorytemp = new Inventory(InventoryReceipt[i].Id, InventoryReceipt[i].Product, InventoryReceipt[i].Previous, InventoryReceipt[i].AmountPrevious
                           , InventoryReceipt[i].Recent, InventoryReceipt[i].AmountRecent, InventoryReceipt[i].Date, InventoryReceipt[i].Quantity, price);
                    InventoryReceiptTemp.Add(inventorytemp);
                    dtgProduct.ItemsSource = InventoryReceiptTemp;
                }
                dtgProduct.ItemsSource = InventoryReceipt;
            }
        }

        public int getName()
        {
            for (int i = 0; i < lstdetailInvoice.Count; i++)
            {

                if (InventoryReceipt[dtgProduct.SelectedIndex].Product == lstdetailInvoice[i].Name)
                {
                    return 1;
                }
            }
            return 2;
        }

        public int getIndex()
        {
            for (int i = 0; i < lstdetailInvoice.Count; i++)
            {

                if (InventoryReceipt[dtgProduct.SelectedIndex].Product == lstdetailInvoice[i].Name)
                {
                    return i;
                }
            }
            return -1;
        }

        public void AddDetail(int id, int id2)
        {
            int idx = 0;
            string idproduct = string.Empty;
            double amount = 0, price = 0;
            Category category;

            idx = getIndex();
            if (getName() == 1)
            {
                price = ult.PriceOutput((InventoryReceipt[dtgProduct.SelectedIndex].AmountRecent / InventoryReceipt[dtgProduct.SelectedIndex].Recent));
                //InventoryReceipt[dtgProduct.SelectedIndex].Quantity -= lstdetailInvoice[idx].Quantity;
                amount = price * lstdetailInvoice[idx].Quantity;
                InventoryReceipt[dtgProduct.SelectedIndex].Amount -= amount;
                idproduct = ult.getId(lstdetailReceipt, InventoryReceipt[dtgProduct.SelectedIndex]);
                category = ult.getCategory(lstdetailReceipt, InventoryReceipt[dtgProduct.SelectedIndex]);

                detailInvoice = new DetailInvoice(lstdetailInvoice[idx].Id, lstdetailInvoice[idx].IdInvoice, idproduct, InventoryReceipt[dtgProduct.SelectedIndex].Product,
                    category, price, double.Parse(txtQuantity.Text) + lstdetailInvoice[idx].Quantity, (price * double.Parse(txtQuantity.Text) + lstdetailInvoice[idx].Quantity));
                lstdetailInvoice.Add(detailInvoice);
                InventoryReceipt[dtgProduct.SelectedIndex].Quantity -= double.Parse(txtQuantity.Text);
                InventoryReceiptTemp[dtgProduct.SelectedIndex].Quantity -= double.Parse(txtQuantity.Text);
                lstdetailInvoice.Remove(lstdetailInvoice[idx]);
            }
            else
            {
                price = ult.PriceOutput((InventoryReceipt[dtgProduct.SelectedIndex].AmountRecent / InventoryReceipt[dtgProduct.SelectedIndex].Recent));
                //InventoryReceipt[dtgProduct.SelectedIndex].Quantity -= double.Parse(txtQuantity.Text);
                amount = price * double.Parse(txtQuantity.Text);
                InventoryReceipt[dtgProduct.SelectedIndex].Amount -= amount;
                idproduct = ult.getId(lstdetailReceipt, InventoryReceipt[dtgProduct.SelectedIndex]);
                category = ult.getCategory(lstdetailReceipt, InventoryReceipt[dtgProduct.SelectedIndex]);

                detailInvoice = new DetailInvoice(id2, "PXK" + id, idproduct, InventoryReceipt[dtgProduct.SelectedIndex].Product,
                    category, price, double.Parse(txtQuantity.Text), (price * double.Parse(txtQuantity.Text)));
                lstdetailInvoice.Add(detailInvoice);
                InventoryReceipt[dtgProduct.SelectedIndex].Quantity -= double.Parse(txtQuantity.Text);
                InventoryReceiptTemp[dtgProduct.SelectedIndex].Quantity -= double.Parse(txtQuantity.Text);
            }
            dtgDetailInvoice.ItemsSource = lstdetailInvoice;
        }

        private void btnCong_Click(object sender, RoutedEventArgs e)
        {
            int idx = ult.getIndex(InventoryInvoice, InventoryReceipt[dtgProduct.SelectedIndex]);
            if (txtQuantity.Text == string.Empty)
                txtQuantity.Text = quantity.ToString();
            quantity = double.Parse(txtQuantity.Text);
            if(idx == -1)
            {
                if (quantity == InventoryReceiptTemp[dtgProduct.SelectedIndex].Quantity)
                    return;
            }
            else
            {
                if (quantity == (InventoryReceipt[dtgProduct.SelectedIndex].Quantity - InventoryInvoice[idx].Quantity))
                    return;
            }
            quantity++;
            txtQuantity.Text = quantity.ToString();
        }

        private void btnTru_Click(object sender, RoutedEventArgs e)
        {
            quantity = double.Parse(txtQuantity.Text);
            if (quantity == 0)
                return;
            quantity--;
            txtQuantity.Text = quantity.ToString();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idx = ult.getIndex(lstdetailInvoice[dtgDetailInvoice.SelectedIndex], InventoryReceipt);
            totalquantity -= lstdetailInvoice[dtgDetailInvoice.SelectedIndex].Quantity;
            var item = lstdetailInvoice[dtgDetailInvoice.SelectedIndex];
            string str = string.Format("You want Delete {0} ?", item.Name);
            MessageBoxResult result = MessageBox.Show(str, "Delete", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (item != null)
                    {
                        lstdetailInvoice.Remove(item);
                        InventoryReceipt[idx].Quantity += item.Quantity;
                        InventoryReceiptTemp[idx].Quantity += item.Quantity;
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            ucDisplay = new DisplayPhieu(name, 2);
            Stackpanel.Children.Clear();
            Stackpanel.Children.Add(ucDisplay);
        }

        public void SaveInvoice()
        {
            total = ult.getTotal(lstdetailInvoice, total);
            invoice = new Invoice("PXK" + id, name, totalquantity, total, DateTime.Now);
            lstInvoice.Add(invoice);
            MessageBoxResult result = MessageBox.Show("Save Invoice?", "Save", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                for (int i = 0; i < lstdetailInvoice.Count; i++)
                {
                    InventoryVM.Add(lstdetailInvoice[i], "data/Inventory/InventoryInvoice.xml");
                }
                InvoiceVM.Create(invoice);
                detailInvoiceVM.Create(lstdetailInvoice);
                InventoryVM.Save("data/Inventory/InventoryInvoice.xml");
            }
            else
            {
                lstInvoice = new List<Invoice>();
                lstdetailInvoice = new ObservableCollection<DetailInvoice>();
                txtQuantity.Text = string.Empty;
            }
        }

        private void txtQuantity_PreviewKeyDown(object sender, KeyEventArgs e)
        {
           
            int key = (int)e.Key;
            e.Handled = !(key >= 34 && key <= 43 ||
                          key >= 74 && key <= 83 ||
                          key == 2);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuantity.Text == "")
                return;
            if (double.Parse(txtQuantity.Text) == 0)
                return;
            if (double.Parse(txtQuantity.Text) > InventoryReceipt[dtgProduct.SelectedIndex].Quantity)
                return;
            AddDetail(id, id2++);
            totalquantity += double.Parse(txtQuantity.Text);
            txtQuantity.Text = string.Empty;
            quantity = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (lstdetailInvoice.Count == 0)
                return;
            SaveInvoice();
            dtgDetailInvoice.ItemsSource = null;
            ucDisplay = new DisplayPhieu(name, 2);
            Stackpanel.Children.Clear();
            Stackpanel.Children.Add(ucDisplay);
        }
    }
}
