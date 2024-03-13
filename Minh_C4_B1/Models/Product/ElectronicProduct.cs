using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    class ElectronicProduct : Product
    {
        public double Warranty;
        public double ElectricPower;

        public ElectronicProduct() { }

        public ElectronicProduct(string id, string name, string producer, double priceinput, double priceoutput, Category category, double warranty, double electricpower) : base(id, name, producer, priceinput, priceoutput, category)
        {
            this.Id = id;
            this.Name = name;
            this.Producer = producer;
            this.PriceInput = priceinput;
            this.PriceOutput = priceoutput;
            this.Categories = category;
            this.Warranty = warranty;
            this.ElectricPower = electricpower;
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
        #endregion
    }
}
