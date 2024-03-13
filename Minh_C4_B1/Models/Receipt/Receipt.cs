
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    class Receipt : INotifyPropertyChanged
    {
        #region Filed
        private string _id;
        private string _name;
        private double _quantity;
        private double _total;
        public ObservableCollection<DetailReceipt> _lstdetailReceipt;
        #endregion

        public string Id {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Username {
            get { return _name; }
            set
            {
                _name = value;
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
        public double Total {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged();
            }
        }
        public DateTime CreateAt { get; set; }
        public ObservableCollection<DetailReceipt> lstdetailReceipt
        {
            get { return _lstdetailReceipt; }
            set
            {
                _lstdetailReceipt = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Receipt() { }

        public Receipt(string id, string name, double quantity, double total, DateTime createat)
        {
            this.Id = id;
            this.Username = name;
            this.Quantity = quantity;
            this.Total = total;
            this.CreateAt = createat;
        }

        public Receipt(string id, string name, double quantity, double total, DateTime createat, ObservableCollection<DetailReceipt> lstdetailreceipt)
        {
            this.Id = id;
            this.Username = name;
            this.Quantity = quantity;
            this.Total = total;
            this.CreateAt = createat;
            this.lstdetailReceipt = lstdetailreceipt;
        }
    }
}
