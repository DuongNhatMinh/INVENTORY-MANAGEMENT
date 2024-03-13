using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    class DetailReceipt : INotifyPropertyChanged
    {
        public int _id;
        public string _idReceipt;
        public string _idProduct;
        public string _name;
        public double _priceInput;
        public double _priceOutput;
        public double _quantity;
        public double _amount;

        public int Id {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string IdReceipt {
            get { return _idReceipt; }
            set
            {
                _idReceipt = value;
                OnPropertyChanged();
            }
        }
        public string IdProduct {
            get { return _idProduct; }
            set
            {
                _idProduct = value;
                OnPropertyChanged();
            }
        }
        public string Name {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public Category Categories { get; set; }
        public double PriceInput {
            get { return _priceInput; }
            set
            {
                _priceInput = value;
                OnPropertyChanged();
            }
        }
        public double PriceOutput {
            get { return _priceOutput; }
            set
            {
                _priceOutput = value;
                OnPropertyChanged();
            }
        }
        public double Quantity {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }
        public double Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public DetailReceipt() { }

        public DetailReceipt(int id, string idreceipt, string idproduct, string name, Category category, double priceintput, double priceoutput, double quantity, double amount)
        {
            this.Id = id;
            this.IdReceipt = idreceipt;
            this.IdProduct = idproduct;
            this.Name = name;
            this.Categories = category;
            this.PriceInput = priceintput;
            this.PriceOutput = priceoutput;
            this.Quantity = quantity;
            this.Amount = amount;
        }
    }
}
