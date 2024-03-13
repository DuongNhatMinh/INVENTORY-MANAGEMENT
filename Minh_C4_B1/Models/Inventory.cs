using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    class Inventory : INotifyPropertyChanged
    {
        private int _Id;
        private string _Product;
        private double _Previous;
        private double _AmountPrevious;
        private double _Recent;
        private double _AmountRecent;
        private DateTime _Date;
        private double _Quantity;
        private double _QuantityReceipt;
        private double _QuantityInvoice;
        private double _Amount;

        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }
        public string Product
        {
            get { return _Product; }
            set
            {
                _Product = value;
                OnPropertyChanged();
            }
        }
        public double Previous
        {
            get { return _Previous; }
            set
            {
                _Previous = value;
                OnPropertyChanged();
            }
        }
        public double AmountPrevious
        {
            get { return _AmountPrevious; }
            set
            {
                _AmountPrevious = value;
                OnPropertyChanged();
            }
        }
        public double Recent
        {
            get { return _Recent; }
            set
            {
                _Recent = value;
                OnPropertyChanged();
            }
        }
        public double AmountRecent
        {
            get { return _AmountRecent; }
            set
            {
                _AmountRecent = value;
                OnPropertyChanged();
            }
        }
        public DateTime Date
        {
            get { return _Date; }
            set
            {
                _Date = value;
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
        public double QuantityReceipt
        {
            get { return _QuantityReceipt; }
            set
            {
                _QuantityReceipt = value;
                OnPropertyChanged();
            }
        }
        public double QuantiyInvoice
        {
            get { return _QuantityInvoice; }
            set
            {
                _QuantityInvoice = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Inventory() { }

        public Inventory(int id, string product, double previous, double amountprevious, double recent, double amountrecent, DateTime date, double quantity, double amount)
        {
            this.Id = id;
            this.Product = product;
            this.Previous = previous;
            this.AmountPrevious = amountprevious;
            this.Recent = recent;
            this.AmountRecent = amountrecent;
            this.Date = date;
            this.Quantity = quantity;
            this.Amount = amount;
        }


        public Inventory(int id, string product, double quantiyreceipt, double quantityinvoice,  double quantity)
        {
            this.Id = id;
            this.Product = product;
            this.QuantityReceipt = quantiyreceipt;
            this.QuantiyInvoice = quantityinvoice;
            this.Quantity = quantity;
        }
    }
}
