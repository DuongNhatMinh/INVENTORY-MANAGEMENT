using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    class PorcelainProduct : Product
    {
        public string Material;

        public PorcelainProduct() { }

        public PorcelainProduct(string id, string name, string producer, double priceinput, double priceoutput, Category category, string material) : base(id, name, producer, priceinput, priceoutput, category)
        {
            this.Id = id;
            this.Name = name;
            this.Producer = producer;
            this.PriceInput = priceinput;
            this.PriceOutput = priceoutput;
            this.Categories = category;
            this.Material = material;
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
