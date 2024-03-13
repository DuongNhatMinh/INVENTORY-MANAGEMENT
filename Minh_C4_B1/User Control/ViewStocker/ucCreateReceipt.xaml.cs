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
    /// Interaction logic for ucCreateReceipt.xaml
    /// </summary>
    public partial class ucCreateReceipt : UserControl
    {
        private ReceiptViewModel receiptVM = new ReceiptViewModel();
        private DetailReceiptViewModel detailReceiptVM = new DetailReceiptViewModel();
        private InventoryViewModel InventoryVM = new InventoryViewModel();
        private Receipt receipt = new Receipt();
        private DetailReceipt detailreceipt = new DetailReceipt();
        private List<Receipt> lstReceipt = new List<Receipt>();
        private List<FoodProduct> lstFoodExp = new List<FoodProduct>();
        private ObservableCollection<DetailReceipt> lstdetailReceipt = new ObservableCollection<DetailReceipt>();
        private ObservableCollection<ElectronicProduct> _lstElec;
        private ObservableCollection<ElectronicProduct> lstElec
        {
            get { return _lstElec; }
            set
            {
                _lstElec = value;
                OnPropertyChanged();
            }
        }
        private ElectricViewModel electricVM = new ElectricViewModel();

        private ObservableCollection<FoodProduct> _lstFood;
        private ObservableCollection<FoodProduct> lstFood
        {
            get { return _lstFood; }
            set
            {
                _lstFood = value;
                OnPropertyChanged();
            }
        }
        private FoodViewModel foodVM = new FoodViewModel();

        private ObservableCollection<PorcelainProduct> _lstPorcelain;
        private ObservableCollection<PorcelainProduct> lstPorcelain
        {
            get { return _lstPorcelain; }
            set
            {
                _lstPorcelain = value;
                OnPropertyChanged();
            }
        }
        private PorcelainViewModel porcelainVM = new PorcelainViewModel();
        private Utilities ult = new Utilities();
        private ChangePriceViewModel changepriceVM = new ChangePriceViewModel();
        private Receipt receipttemp = new Receipt();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        DisplayPhieu ucDisplay { get; set; }
        ucViewProduct ucProduct { get; set; }
        private object resultString;
        private double quantity = 0, total = 0, totalquantity = 0;
        public int id2 = 1, id = 0;
        public int option = 0;
        public string idPNK, name;

        public ucCreateReceipt(string Id, string Name, object item)
        {
            InitializeComponent();
            electricVM.getList();
            lstElec = new ObservableCollection<ElectronicProduct>(electricVM.elecRepo.Items);
            foodVM.getList();
            lstFood = new ObservableCollection<FoodProduct>(foodVM.foodRepo.Items);
            porcelainVM.getList();
            lstPorcelain = new ObservableCollection<PorcelainProduct>(porcelainVM.porcelainRepo.Items);
            idPNK = Id;
            name = Name;
            receipttemp = item as Receipt;
            string strid = string.Format("Id: {0}", receipttemp.Id);
            string strname = string.Format("Name: {0}", receipttemp.Username);
            string strdate = string.Format("Date: {0}", receipttemp.CreateAt);
            lbid.Content = strid;
            lbname.Content = strname;
            lbdate.Content = strdate;
            getId();
            ucProduct = new ucViewProduct();
            stackpanel.Children.Add(ucProduct);
        }

        public void getId()
        {
            resultString = Regex.Match(idPNK, @"\d+").Value;
            id = Int32.Parse(resultString.ToString());
        }

        public int getName(string name)
        {
            for (int i = 0; i < lstdetailReceipt.Count; i++)
            {
                if (name == lstdetailReceipt[i].Name)
                {
                    return 1;
                }
            }
            return 2;
        }

        public int getIndex(string name)
        {
            for (int i = 0; i < lstdetailReceipt.Count; i++)
            {
                if (name == lstdetailReceipt[i].Name)
                {
                    return i;
                }
            }
            return -1;
        }

        public void AddDetail(int id, int id2)
        {
            int check = 0, idx = 0;
            switch (ucProduct.option)
            {
                case 1:
                    idx = getIndex(lstElec[ucProduct.dtgProduct.SelectedIndex].getName());
                    if (getName(lstElec[ucProduct.dtgProduct.SelectedIndex].getName()) == 1)
                    {
                        detailreceipt = new DetailReceipt(lstdetailReceipt[idx].Id, lstdetailReceipt[idx].IdReceipt, lstElec[ucProduct.dtgProduct.SelectedIndex].getID(),
                    lstElec[ucProduct.dtgProduct.SelectedIndex].getName(), Category.Electronic,
                    lstElec[ucProduct.dtgProduct.SelectedIndex].getPriceInput(),
                    electricVM.PriceOutput(lstElec[ucProduct.dtgProduct.SelectedIndex].getPriceInput()), double.Parse(txtQuantity.Text) + lstdetailReceipt[idx].Quantity,
                    (electricVM.PriceOutput(lstElec[ucProduct.dtgProduct.SelectedIndex].getPriceInput()) * double.Parse(txtQuantity.Text) + lstdetailReceipt[idx].Quantity));
                        lstdetailReceipt.Add(detailreceipt);
                        lstdetailReceipt.Remove(lstdetailReceipt[idx]);
                    }
                    else
                    {
                        detailreceipt = new DetailReceipt(id2, "PNK" + id, lstElec[ucProduct.dtgProduct.SelectedIndex].getID(),
                        lstElec[ucProduct.dtgProduct.SelectedIndex].getName(), Category.Electronic,
                        lstElec[ucProduct.dtgProduct.SelectedIndex].getPriceInput(),
                        electricVM.PriceOutput(lstElec[ucProduct.dtgProduct.SelectedIndex].getPriceInput()), double.Parse(txtQuantity.Text),
                        (electricVM.PriceOutput(lstElec[ucProduct.dtgProduct.SelectedIndex].getPriceInput()) * double.Parse(txtQuantity.Text)));
                        lstdetailReceipt.Add(detailreceipt);
                    }
                    break;
                case 2:
                    do
                    {
                        check = ult.check(lstFood[ucProduct.dtgProduct.SelectedIndex]);
                        if (check == 1)
                        {
                            lstFoodExp = foodVM.getItemEXp("/ExpDates/ExpDate");
                            if (ult.check(lstFood[ucProduct.dtgProduct.SelectedIndex], lstFoodExp) != 1)
                                foodVM.Create(lstFood[ucProduct.dtgProduct.SelectedIndex]);
                            ult.Output();
                            return;
                        }
                    } while (check == 1);
                    idx = getIndex(lstFood[ucProduct.dtgProduct.SelectedIndex].getName());
                    if (getName(lstFood[ucProduct.dtgProduct.SelectedIndex].getName()) == 1)
                    {
                        detailreceipt = new DetailReceipt(lstdetailReceipt[idx].Id, lstdetailReceipt[idx].IdReceipt, lstFood[ucProduct.dtgProduct.SelectedIndex].getID(),
                            lstFood[ucProduct.dtgProduct.SelectedIndex].getName(), Category.Food,
                            lstFood[ucProduct.dtgProduct.SelectedIndex].getPriceInput(),
                            foodVM.PriceOutput(lstFood[ucProduct.dtgProduct.SelectedIndex].getPriceInput()), double.Parse(txtQuantity.Text) + lstdetailReceipt[idx].Quantity,
                            (foodVM.PriceOutput(lstFood[ucProduct.dtgProduct.SelectedIndex].getPriceInput()) * double.Parse(txtQuantity.Text) + lstdetailReceipt[idx].Quantity));
                        lstdetailReceipt.Add(detailreceipt);
                        lstdetailReceipt.Remove(lstdetailReceipt[idx]);
                    }
                    else
                    {
                        detailreceipt = new DetailReceipt(id2, "PNK" + id, lstFood[ucProduct.dtgProduct.SelectedIndex].getID(),
                        lstFood[ucProduct.dtgProduct.SelectedIndex].getName(), Category.Food,
                        lstFood[ucProduct.dtgProduct.SelectedIndex].getPriceInput(),
                        foodVM.PriceOutput(lstFood[ucProduct.dtgProduct.SelectedIndex].getPriceInput()), double.Parse(txtQuantity.Text),
                        (foodVM.PriceOutput(lstFood[ucProduct.dtgProduct.SelectedIndex].getPriceInput()) * double.Parse(txtQuantity.Text)));
                        lstdetailReceipt.Add(detailreceipt);
                    }
                    break;
                case 3:
                    idx = getIndex(lstPorcelain[ucProduct.dtgProduct.SelectedIndex].getName());
                        if (getName(lstPorcelain[ucProduct.dtgProduct.SelectedIndex].getName()) == 1)
                    {
                        detailreceipt = new DetailReceipt(lstdetailReceipt[idx].Id, lstdetailReceipt[idx].IdReceipt, lstPorcelain[ucProduct.dtgProduct.SelectedIndex].getID(),
                  lstPorcelain[ucProduct.dtgProduct.SelectedIndex].getName(), Category.Porcelain,
                  lstPorcelain[ucProduct.dtgProduct.SelectedIndex].getPriceInput(),
                  porcelainVM.PriceOutput(lstPorcelain[ucProduct.dtgProduct.SelectedIndex].getPriceInput()), double.Parse(txtQuantity.Text) + lstdetailReceipt[idx].Quantity,
                  (porcelainVM.PriceOutput(lstPorcelain[ucProduct.dtgProduct.SelectedIndex].getPriceInput()) * double.Parse(txtQuantity.Text) + lstdetailReceipt[idx].Quantity));
                        lstdetailReceipt.Add(detailreceipt);
                        lstdetailReceipt.Remove(lstdetailReceipt[idx]);
                    }
                    else
                    {
                        detailreceipt = new DetailReceipt(id2, "PNK" + id, lstPorcelain[ucProduct.dtgProduct.SelectedIndex].getID(),
                  lstPorcelain[ucProduct.dtgProduct.SelectedIndex].getName(), Category.Porcelain,
                  lstPorcelain[ucProduct.dtgProduct.SelectedIndex].getPriceInput(),
                  porcelainVM.PriceOutput(lstPorcelain[ucProduct.dtgProduct.SelectedIndex].getPriceInput()), double.Parse(txtQuantity.Text),
                  (porcelainVM.PriceOutput(lstPorcelain[ucProduct.dtgProduct.SelectedIndex].getPriceInput()) * double.Parse(txtQuantity.Text)));
                        lstdetailReceipt.Add(detailreceipt);
                    }
                    break;
            }
            dtgDetailReceipt.ItemsSource = lstdetailReceipt;
        }

        private void btnCong_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuantity.Text == string.Empty)
                txtQuantity.Text = quantity.ToString();
            quantity = double.Parse(txtQuantity.Text);
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
            var item = lstdetailReceipt[dtgDetailReceipt.SelectedIndex];
            totalquantity -= lstdetailReceipt[dtgDetailReceipt.SelectedIndex].Quantity;
            string str = string.Format("You want Delete {0} ?", item.Name);
            MessageBoxResult result = MessageBox.Show(str, "Delete", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (item != null)
                    {
                        lstdetailReceipt.Remove(item);
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            ucDisplay = new DisplayPhieu(name, 1);
            Stackpanel.Children.Clear();
            Stackpanel.Children.Add(ucDisplay);
        }

        public void SaveReceipt()
        {        
            total = ult.getTotal(lstdetailReceipt, total);
            receipt = new Receipt("PNK" + id, name, totalquantity, total, DateTime.Now);
            lstReceipt.Add(receipt);
            MessageBoxResult result = MessageBox.Show("Save Receipt?", "Save", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                for(int i = 0; i < lstdetailReceipt.Count; i++)
                {
                    InventoryVM.Add(lstdetailReceipt[i], "data/Inventory/InventoryReceipt.xml");
                }
                receiptVM.Create(receipt);
                detailReceiptVM.Create(lstdetailReceipt);
                InventoryVM.Save("data/Inventory/InventoryReceipt.xml");
            }
            else
            {
                lstReceipt = new List<Receipt>();
                lstdetailReceipt = new ObservableCollection<DetailReceipt>();
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
            AddDetail(id, id2++);
            totalquantity += double.Parse(txtQuantity.Text);
            txtQuantity.Text = string.Empty;
            quantity = 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (lstdetailReceipt.Count == 0)
                return;
            SaveReceipt();
            dtgDetailReceipt.ItemsSource = null;
            ucDisplay = new DisplayPhieu(name, 1);
            Stackpanel.Children.Clear();
            Stackpanel.Children.Add(ucDisplay);
        }
    }
}
