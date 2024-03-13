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
    /// Interaction logic for ucCreateOrder.xaml
    /// </summary>
    public partial class ucCreateOrder : UserControl
    {
        private Order order = new Order();
        private List<Order> lstOrder = new List<Order>();
        private DetailOrder detailOrder = new DetailOrder();
        private ObservableCollection<DetailOrder> _lstdetaiOrder;
        private ObservableCollection<DetailOrder> lstdetailOrder
        {
            get { return _lstdetaiOrder; }
            set
            {
                _lstdetaiOrder = value;
                OnPropertyChanged();
            }
        }
        private Utilities ult = new Utilities();
        private DetailInvoiceViewModel detailInvoiceVM = new DetailInvoiceViewModel();
        private DetailOrderViewModel detailOrderVM = new DetailOrderViewModel();
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
        private ObservableCollection<Inventory> InventoryInvoiceTemp = new ObservableCollection<Inventory>();
        private InvoiceViewModel InvoiceVM = new InvoiceViewModel();
        private ObservableCollection<Inventory> InventoryOrder = new ObservableCollection<Inventory>();
        private ObservableCollection<DetailInvoice> lstdetailInvoice = new ObservableCollection<DetailInvoice>();
        private Customer customer = new Customer();
        private List<Customer> lstCustomer = new List<Customer>();
        private CustomerViewModel CustomerVM = new CustomerViewModel();
        private OrderViewModel OrderVM = new OrderViewModel();
        private ObservableCollection<DetailOrder> lstdetaiOrder2 = new ObservableCollection<DetailOrder>();
        private Order ordertemp = new Order();
        private frmBill frmbill { get; set; }
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

        public ucCreateOrder(string Id, string Name, object item, object item2)
        {
            InitializeComponent();
            idPNK = Id;
            name = Name;
            customer = item as Customer;
            ordertemp = item2 as Order;

            string id = string.Format("ID: {0}", customer.CardID);
            string namecus = string.Format("Name: {0}", customer.Name);
            string phone = string.Format("Phone: {0}", customer.Phone.ToString());
            string point = string.Format("Point: {0}", customer.Point.ToString());
            string type = string.Format("Type: {0}", customer.CardType);
            string strid = string.Format("Id: {0}", ordertemp.Id);
            string strname = string.Format("Name: {0}", ordertemp.Username);
            string strdate = string.Format("Date: {0}", ordertemp.CreateAt);
            lbid.Content = strid;
            lbname.Content = strname;
            lbdate.Content = strdate;
            lbcusid.Content = id;
            lbcusname.Content = namecus;
            lbcusphone.Content = phone;
            lbcuspoint.Content = point;
            lbcustype.Content = type;
            getId();
            lstCustomer = CustomerVM.getList("/Customers/Customer");
            lstdetailInvoice = detailInvoiceVM.getListByID("/DetailInvoices/DetailInvoice");
            InventoryInvoice = InventoryVM.getList("/Inventorys/Inventory", "data/Inventory/InventoryInvoice.xml");
            lstdetaiOrder2 = detailOrderVM.getListByID("/DetailOrders/DetailOrder");
            lstdetailOrder = new ObservableCollection<DetailOrder>();
            Display();
        }

        public void getId()
        {
            resultString = Regex.Match(idPNK, @"\d+").Value;
            id = Int32.Parse(resultString.ToString());
        }

        public void Display()
        {
            Inventory inventorytemp = new Inventory();
            double quantity = 0;
            for (int i = 0; i < InventoryInvoice.Count; i++)
            {
                quantity = ult.getquantity(lstdetaiOrder2, InventoryInvoice[i], 0);
                double price = (InventoryInvoice[i].AmountRecent / InventoryInvoice[i].Recent);
                if (quantity != -1)
                {
                    if ((InventoryInvoice[i].Quantity - quantity) != 0)
                    {
                        inventorytemp = new Inventory(InventoryInvoice[i].Id, InventoryInvoice[i].Product, InventoryInvoice[i].Previous, InventoryInvoice[i].AmountPrevious
                           , InventoryInvoice[i].Recent, InventoryInvoice[i].AmountRecent, InventoryInvoice[i].Date, (InventoryInvoice[i].Quantity - quantity), price);
                        InventoryInvoiceTemp.Add(inventorytemp);
                        dtgProduct.ItemsSource = InventoryInvoiceTemp;
                    }
                }
                else
                {
                    inventorytemp = new Inventory(InventoryInvoice[i].Id, InventoryInvoice[i].Product, InventoryInvoice[i].Previous, InventoryInvoice[i].AmountPrevious
                           , InventoryInvoice[i].Recent, InventoryInvoice[i].AmountRecent, InventoryInvoice[i].Date, InventoryInvoice[i].Quantity, price);
                    InventoryInvoiceTemp.Add(inventorytemp);
                    dtgProduct.ItemsSource = InventoryInvoiceTemp;
                }
            }
        }

        public int getName()
        {
            for (int i = 0; i < lstdetailOrder.Count; i++)
            {

                if (InventoryInvoice[dtgProduct.SelectedIndex].Product == lstdetailOrder[i].Name)
                {
                    return 1;
                }
            }
            return 2;
        }

        public int getIndex()
        {
            for (int i = 0; i < lstdetailOrder.Count; i++)
            {

                if (InventoryInvoice[dtgProduct.SelectedIndex].Product == lstdetailOrder[i].Name)
                {
                    return i;
                }
            }
            return -1;
        }

        public void AddDetail(int id, int id2)
        {
            int idx = 0;
            string idproduct = "a";
            double amount = 0, price = 0;
            Category category;
            for (int i = 0; i < lstCustomer.Count; i++)
            {
                if (lstCustomer[i].CardID == customer.CardID)
                {
                    idx = getIndex();
                    if (getName() == 1)
                    {
                        idx = ult.getIndex(lstdetailInvoice, InventoryInvoice[dtgProduct.SelectedIndex]);
                        price = (InventoryInvoice[dtgProduct.SelectedIndex].AmountRecent / InventoryInvoice[dtgProduct.SelectedIndex].Recent);
                        amount = price * double.Parse(txtQuantity.Text);
                        InventoryInvoice[dtgProduct.SelectedIndex].Amount -= amount;
                        idproduct = ult.getId(lstdetailInvoice, InventoryInvoice[dtgProduct.SelectedIndex]);
                        category = ult.getCategory(lstdetailInvoice, InventoryInvoice[dtgProduct.SelectedIndex]);
                        detailOrder = new DetailOrder(lstdetailOrder[idx].Id, lstdetailOrder[idx].IdOrder, idproduct, InventoryInvoice[dtgProduct.SelectedIndex].Product,
                            category, price, double.Parse(txtQuantity.Text) + lstdetailOrder[idx].Quantity, (price * double.Parse(txtQuantity.Text) + lstdetailOrder[idx].Quantity));
                        InventoryInvoice[dtgProduct.SelectedIndex].Quantity -= double.Parse(txtQuantity.Text);
                        InventoryInvoiceTemp[dtgProduct.SelectedIndex].Quantity -= double.Parse(txtQuantity.Text);
                        lstdetailOrder.Remove(lstdetailOrder[idx]);
                        lstdetailOrder.Add(detailOrder);
                    }
                    else
                    {
                        idx = ult.getIndex(lstdetailInvoice, InventoryInvoice[dtgProduct.SelectedIndex]);
                        price = (InventoryInvoice[dtgProduct.SelectedIndex].AmountRecent / InventoryInvoice[dtgProduct.SelectedIndex].Recent);
                        amount = price * double.Parse(txtQuantity.Text);
                        InventoryInvoice[dtgProduct.SelectedIndex].Amount -= amount;
                        idproduct = ult.getId(lstdetailInvoice, InventoryInvoice[dtgProduct.SelectedIndex]);
                        category = ult.getCategory(lstdetailInvoice, InventoryInvoice[dtgProduct.SelectedIndex]);
                        detailOrder = new DetailOrder(id2, "PBH" + id, idproduct, InventoryInvoice[dtgProduct.SelectedIndex].Product, category, price, double.Parse(txtQuantity.Text), (price * double.Parse(txtQuantity.Text)));
                        InventoryInvoice[dtgProduct.SelectedIndex].Quantity -= double.Parse(txtQuantity.Text);
                        InventoryInvoiceTemp[dtgProduct.SelectedIndex].Quantity -= double.Parse(txtQuantity.Text);
                        lstdetailOrder.Add(detailOrder);
                    }
                    dtgDetailOrder.ItemsSource = lstdetailOrder;
                }
            }
        }

        public void SaveOrder()
        {
            total = ult.getTotal(lstdetailOrder, total);
            order = new Order("PBH" + id, name, totalquantity, total, DateTime.Now);
            lstOrder.Add(order);
            MessageBoxResult result = MessageBox.Show("Save Order?", "Save", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                frmbill = new frmBill(lstdetailOrder, lstOrder, customer, 1);
                frmbill.ShowDialog();

                OrderVM.Create(order);
                detailOrderVM.Create(lstdetailOrder);
                for (int i = 0; i < lstCustomer.Count; i++)
                {
                    if (customer.CardID == "000")
                        break;
                    else
                    {
                        if (lstCustomer[i].CardID == customer.CardID)
                        {
                            lstCustomer[i].Point = CustomerVM.TotalPoint(total);
                            CustomerVM.Update(lstCustomer[i], "data/Customer/Customer.xml");
                        }
                    }
                }
            }
            else
            {
                lstOrder = new List<Order>();
                lstdetailOrder = new ObservableCollection<DetailOrder>();
                lstCustomer = new List<Customer>();
                CustomerVM.customer = new Customer();
                CustomerVM.lstCustomer = new List<Customer>();
                txtQuantity.Text = string.Empty;
            }
        }

        private void btnCong_Click(object sender, RoutedEventArgs e)
        {
            int idx = ult.getIndex(lstdetailOrder, InventoryInvoiceTemp[dtgProduct.SelectedIndex]);
            if (txtQuantity.Text == string.Empty)
                txtQuantity.Text = quantity.ToString();
            quantity = double.Parse(txtQuantity.Text);
            if (idx == -1)
            {
                if (quantity == InventoryInvoiceTemp[dtgProduct.SelectedIndex].Quantity)
                    return;
            }
            else
            {
                if (quantity == (InventoryInvoiceTemp[dtgProduct.SelectedIndex].Quantity - lstdetailOrder[idx].Quantity))
                    return;
            }
            quantity++;
            txtQuantity.Text = quantity.ToString();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int idx = ult.getIndex(lstdetailOrder[dtgDetailOrder.SelectedIndex], InventoryInvoice);
            totalquantity -= lstdetailOrder[dtgDetailOrder.SelectedIndex].Quantity;
            var item = lstdetailOrder[dtgDetailOrder.SelectedIndex];
            string str = string.Format("You want Delete {0} ?", item.Name);
            MessageBoxResult result = MessageBox.Show(str, "Delete", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (item != null)
                    {
                        lstdetailOrder.Remove(item);
                        InventoryInvoice[idx].Quantity += item.Quantity;
                        InventoryInvoiceTemp[idx].Quantity += item.Quantity;
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            ucDisplay = new DisplayPhieu(name, 3);
            Stackpanel.Children.Clear();
            Stackpanel.Children.Add(ucDisplay);
        }

        private void btnTru_Click(object sender, RoutedEventArgs e)
        {
            quantity = double.Parse(txtQuantity.Text);
            if (quantity == 0)
                return;
            quantity--;
            txtQuantity.Text = quantity.ToString();
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
            if (double.Parse(txtQuantity.Text) > InventoryInvoice[dtgProduct.SelectedIndex].Quantity)
                return;
            AddDetail(id, id2++);
            totalquantity += double.Parse(txtQuantity.Text);
            txtQuantity.Text = string.Empty;
            quantity = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (lstdetailOrder.Count == 0)
                return;
            SaveOrder();
            dtgDetailOrder.ItemsSource = null;
            ucDisplay = new DisplayPhieu(name, 3);
            Stackpanel.Children.Clear();
            Stackpanel.Children.Add(ucDisplay);
        }
    }
}
