using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    class DetailInvoice : INotifyPropertyChanged
    {
        private int _Id;
        private string _IdInvoice;
        private string _IdProduct;
        private string _Name;
        private Category _Categories;
        private double _PriceOutput;
        public double _Quantity;
        public double _Amount;

        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }
        public string IdInvoice
        {
            get { return _IdInvoice; }
            set
            {
                _IdInvoice = value;
                OnPropertyChanged();
            }
        }
        public string IdProduct
        {
            get { return _IdProduct; }
            set
            {
                _IdProduct = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        public Category Categories
        {
            get { return _Categories; }
            set
            {
                _Categories = value;
                OnPropertyChanged();
            }
        }
        public double PriceOutput
        {
            get { return _PriceOutput; }
            set
            {
                _PriceOutput = value;
                OnPropertyChanged();
            }
        }
        public double Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
                OnPropertyChanged();
            }
        }
        public double Amount
        {
            get { return _Amount; }
            set
            {
                _Amount = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public DetailInvoice() { }

        public DetailInvoice(int id, string idinvoice, string idproduct, string name, Category category, double priceoutput, double quantity, double amount)
        {
            this.Id = id;
            this.IdInvoice = idinvoice;
            this.IdProduct = idproduct;
            this.Name = name;
            this.Categories = category;
            this.PriceOutput = priceoutput;
            this.Quantity = quantity;
            this.Amount = amount;
        }
    }
}
