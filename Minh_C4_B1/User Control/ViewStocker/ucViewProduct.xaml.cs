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
    /// Interaction logic for ucViewProduct.xaml
    /// </summary>
    public partial class ucViewProduct : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<ElectronicProduct> _lstElec;
        private ObservableCollection<ElectronicProduct> lstElec { get; set; }
        private ObservableCollection<ElectronicProduct> lstElec2 {
            get { return _lstElec; }
            set
            {   
                _lstElec = value;
                OnPropertyChanged();
            }
        }
        private ElectricViewModel electricVM = new ElectricViewModel();

        private ObservableCollection<FoodProduct> _lstFood;
        private ObservableCollection<FoodProduct> lstFood { get; set; }
        private ObservableCollection<FoodProduct> lstFood2 {
            get { return _lstFood; }
            set
            {
                _lstFood = value;
                OnPropertyChanged();
            }
        }
        private FoodViewModel foodVM = new FoodViewModel();

        private ObservableCollection<PorcelainProduct> _lstPorcelain;
        private ObservableCollection<PorcelainProduct> lstPorcelain { get; set; }
        private ObservableCollection<PorcelainProduct> lstPorcelain2 {
            get { return _lstPorcelain; }
            set
            {
                _lstPorcelain = value;
                OnPropertyChanged();
            }
        }
        private PorcelainViewModel porcelainVM = new PorcelainViewModel();
        private Utilities ult = new Utilities();
        private double priceOutput = 0;
        public int option = 0;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ucViewProduct()
        {
            InitializeComponent();
            electricVM.getList();
            lstElec = new ObservableCollection<ElectronicProduct>(electricVM.elecRepo.Items);
            foodVM.getList();
            lstFood = new ObservableCollection<FoodProduct>(foodVM.foodRepo.Items);
            porcelainVM.getList();
            lstPorcelain = new ObservableCollection<PorcelainProduct>(porcelainVM.porcelainRepo.Items);
        }

        public void Display(int op)
        {
            switch (op)
            {
                case 1:
                    dtgProduct.ItemsSource = null;
                    lstElec2 = new ObservableCollection<ElectronicProduct>();
                    for (int i = 0; i < lstElec.Count; i++)
                    {
                        priceOutput = electricVM.PriceOutput(lstElec[i].PriceInput);
                        ElectronicProduct elec = new ElectronicProduct(lstElec[i].Id, lstElec[i].Name, lstElec[i].Producer,
                            lstElec[i].PriceInput, priceOutput, lstElec[i].Categories, lstElec[i].Warranty, lstElec[i].ElectricPower);
                        lstElec2.Add(elec);
                    }
                    option = 1;
                    dtgProduct.ItemsSource = lstElec2;
                    break;
                case 2:
                    dtgProduct.ItemsSource = null;
                    lstFood2 = new ObservableCollection<FoodProduct>();
                    for (int i = 0; i < lstFood.Count; i++)
                    {
                        priceOutput = foodVM.PriceOutput(lstFood[i].PriceInput);
                        FoodProduct food = new FoodProduct(lstFood[i].Id, lstFood[i].Name, lstFood[i].Producer,
                            lstFood[i].PriceInput, priceOutput, lstFood[i].Categories, lstFood[i].MfgDate, lstFood[i].ExpDate);
                        lstFood2.Add(food);
                    }
                    option = 2;
                    dtgProduct.ItemsSource = lstFood2;
                    break;
                case 3:
                    dtgProduct.ItemsSource = null;
                    lstPorcelain2 = new ObservableCollection<PorcelainProduct>();
                    for (int i = 0; i < lstPorcelain.Count; i++)
                    {
                        priceOutput = porcelainVM.PriceOutput(lstPorcelain[i].PriceInput);
                        PorcelainProduct porcelain = new PorcelainProduct(lstPorcelain[i].Id, lstPorcelain[i].Name, lstPorcelain[i].Producer,
                            lstPorcelain[i].PriceInput, priceOutput, lstPorcelain[i].Categories, lstPorcelain[i].Material);
                        lstPorcelain2.Add(porcelain);
                    }
                    option = 3;
                    dtgProduct.ItemsSource = lstPorcelain2;
                    break;
            }
        }
        private void btnElec_Click(object sender, RoutedEventArgs e)
        {
            Display(1);
        }

        private void btnPorcelain_Click(object sender, RoutedEventArgs e)
        {
            Display(3);
        }

        private void btnFood_Click(object sender, RoutedEventArgs e)
        {
            Display(2);
        }
    }
}
