using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    class Customer : INotifyPropertyChanged
    {
        public string _Name;
        public string _Phone;
        public string _CardID;
        public double _Point;
        public string _cardtype;

        public string Name {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        public string Phone {
            get { return _Phone; }
            set
            {
                _Phone = value;
                OnPropertyChanged();
            }
        }
        public string CardID {
            get { return _CardID; }
            set
            {
                _CardID = value;
                OnPropertyChanged();
            }
        }
        public double Point {
            get { return _Point; }
            set
            {
                _Point = value;
                OnPropertyChanged();
            }
        }
        public string CardType
        {
            get { return _cardtype; }
            set
            {
                _cardtype = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Customer() { }

        public Customer(string name, string phone, string cardid, double point, string cardtype)
        {
            this.Name = name;
            this.Phone = phone;
            this.CardID = cardid;
            this.Point = point;
            this.CardType = cardtype;
        }
    }
}
