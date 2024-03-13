using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    class DetailOrder : INotifyPropertyChanged
    {
        public int _Id;
        public string _IdOrder;
        public string _IdProduct;
        public string _Name;
        public Category _Categories;
        public double _PriceOutput;
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
        public string IdOrder
        {
            get { return _IdOrder; }
            set
            {
                _IdOrder = value;
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

        public DetailOrder() { }

        public DetailOrder(int id, string idorder, string idproduct, string name, Category category, double priceoutput, double quantity, double amount)
        {
            this.Id = id;
            this.IdOrder = idorder;
            this.IdProduct = idproduct;
            this.Name = name;
            this.Categories = category;
            this.PriceOutput = priceoutput;
            this.Quantity = quantity;
            this.Amount = amount;
        }
    }
}
