using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    class Product : INotifyPropertyChanged
    {
        #region Filed
        private string _id;
        private string _name;
        private string _producer;
        private double _priceinput;
        private double _priceoutput;
        #endregion

        #region Properties
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Producer
        {
            get { return _producer; }
            set
            {
                _producer = value;
                OnPropertyChanged();
            }
        }
        public double PriceInput
        {
            get { return _priceinput; }
            set
            {
                _priceinput = value;
                OnPropertyChanged();
            }
        }
        public double PriceOutput
        {
            get { return _priceoutput; }
            set
            {
                _priceoutput = value;
                OnPropertyChanged();
            }
        }
        public Category Categories { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Contructor
        public Product(string id, string name, string producer, double priceinput, double priceoutput, Category category)
        {
            this.Id = id;
            this.Name = name;
            this.Producer = producer;
            this.PriceInput = priceinput;
            this.PriceOutput = priceoutput;
            this.Categories = category;
        }

        public Product() { }
        #endregion
    }
}
