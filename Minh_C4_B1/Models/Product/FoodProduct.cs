using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    class FoodProduct : Product
    {
        private DateTime _MfgDate;
        private DateTime _ExpDate;

        public DateTime MfgDate
        {
            get { return _MfgDate; }
            set
            {
                _MfgDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime ExpDate
        {
            get { return _ExpDate; }
            set
            {
                _ExpDate = value;
                OnPropertyChanged();
            }
        }

        public FoodProduct() { }

        public FoodProduct(string id, string name, string producer, double priceinput, double priceoutput, Category category, DateTime mfgdate, DateTime expdate) : base(id, name, producer, priceinput, priceoutput, category)
        {
            this.Id = id;
            this.Name = name;
            this.Producer = producer;
            this.PriceInput = priceinput;
            this.PriceOutput = priceoutput;
            this.Categories = category;
            this.MfgDate = mfgdate;
            this.ExpDate = expdate;
        }
        #region Methods
        public string getID()
        {
            return Id;
        }

        public string getName()
        {
            return Name;
        }

        public string getProduct()
        {
            return Producer;
        }

        public double getPriceInput()
        {
            return PriceInput;
        }

        public double getPriceOutput()
        {
            return PriceOutput;
        }

        public Category getCategory()
        {
            return Categories;
        }
        #endregion
    }
}
