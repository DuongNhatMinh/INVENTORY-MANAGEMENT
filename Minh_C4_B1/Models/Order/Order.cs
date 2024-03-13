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
    class Order : INotifyPropertyChanged
    {
        public string _Id;
        public string _Username;
        public double _Quantity;
        public double _Total;
        public DateTime _CreateAt;
        public ObservableCollection<DetailOrder> _lstdetailOrder;

        public string Id {
            get { return _Id; }
            set
            {
                _Id = value;
                OnPropertyChanged();
            }
        }
        public string Username {
            get { return _Username; }
            set
            {
                _Username = value;
                OnPropertyChanged();
            }
        }
        public double Quantity {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
                OnPropertyChanged();
            }
        }
        public double Total {
            get { return _Total; }
            set
            {
                _Total = value;
                OnPropertyChanged();
            }
        }
        public DateTime CreateAt {
            get { return _CreateAt; }
            set
            {
                _CreateAt = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<DetailOrder> lstdetailOrder
        {
            get { return _lstdetailOrder; }
            set
            {
                _lstdetailOrder = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Order() { }

        public Order(string id, string name, double quantity, double total, DateTime createat)
        {
            this.Id = id;
            this.Username = name;
            this.Quantity = quantity;
            this.Total = total;
            this.CreateAt = createat;
        }

        public Order(string id, string name, double quantity, double total, DateTime createat, ObservableCollection<DetailOrder> lstdetailorder)
        {
            this.Id = id;
            this.Username = name;
            this.Quantity = quantity;
            this.Total = total;
            this.CreateAt = createat;
            this.lstdetailOrder = lstdetailorder;
        }
    }
}
