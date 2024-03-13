using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    class ChangePriceViewModel
    {
        private ElectricViewModel electricVM = new ElectricViewModel();
        private FoodViewModel foodVM = new FoodViewModel();
        private PorcelainViewModel porcelainVM = new PorcelainViewModel();

        public void Change(int op, double newprice, string id)
        {
            switch (op)
            {
                case 1:
                    string xpath = string.Format("Product[@Id='{0}']", id);
                    electricVM.Update(xpath, newprice);
                    break;
                case 2:
                    string xpath2 = string.Format("Product[@Id='{0}']", id);
                    foodVM.Update(xpath2, newprice);
                    break;
                case 3:
                    string xpath3 = string.Format("Product[@Id='{0}']", id);
                    porcelainVM.Update(xpath3, newprice);
                    break;
            }
        }
    }
}
