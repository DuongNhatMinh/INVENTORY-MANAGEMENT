using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_C3_B1
{
    class FoodViewModel: IPriceOutput
    {
        private double VAT = 0.1, LoiNhuan = 0.3;
        public RepositoryBase<FoodProduct> foodRepo { get; set; }
        public FoodProduct food = new FoodProduct();
        public List<FoodProduct> lstFood = new List<FoodProduct>();
        public List<FoodProduct> lstFoodExp = new List<FoodProduct>();
        AccountViewModel accVM = new AccountViewModel();
        public UnitOfWork unit { get; set; }
        private Utilities ult = new Utilities();

        public FoodViewModel()
        {
        }

        public void getList()
        {
            unit = new UnitOfWork();
            foodRepo = unit.GetRepositoryFood;
            accVM.getList("/Accounts/Account");
            lstFood = getList("/Products/Product");
        }

        public List<FoodProduct> getList(string xPath)
        {
            string Id = string.Empty;
            string Name = string.Empty;
            string Producer = string.Empty;
            double PriceInput = 0;
            double PriceOutput = 0;
            string category;
            DateTime MfgDate;
            DateTime ExpDate;
            DataProvider.Instance.pathData = "data/Product/FoodProduct.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            foreach (XmlNode node in lstNode)
            {
                Id = node.Attributes["Id"].Value;
                Name = node.Attributes["Name"].Value;
                category = node.Attributes["Category"].Value;
                Producer = node.Attributes["Producer"].Value;
                PriceInput = double.Parse(node.Attributes["PriceInput"].Value);
                PriceOutput = double.Parse(node.Attributes["PriceOutput"].Value);
                MfgDate = DateTime.Parse(node.Attributes["MfgDate"].Value);
                ExpDate = DateTime.Parse(node.Attributes["ExpDate"].Value);
                food = new FoodProduct(Id, Name, Producer, PriceInput, PriceOutput, Category.Food, MfgDate, ExpDate);
                lstFood.Add(food);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstFood;
        }

        public List<FoodProduct> getItemEXp(string xPath)
        {
            string Id = string.Empty;
            string Name = string.Empty;
            string Producer = string.Empty;
            double PriceInput = 0;
            double PriceOutput = 0;
            string category;
            DateTime MfgDate;
            DateTime ExpDate;
            DataProvider.Instance.pathData = "data/Inventory/ExpDate.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            foreach (XmlNode node in lstNode)
            {
                Id = node.Attributes["Id"].Value;
                Name = node.Attributes["Name"].Value;
                category = node.Attributes["Category"].Value;
                Producer = node.Attributes["Producer"].Value;
                PriceInput = double.Parse(node.Attributes["PriceInput"].Value);
                PriceOutput = double.Parse(node.Attributes["PriceOutput"].Value);
                MfgDate = DateTime.Parse(node.Attributes["MfgDate"].Value);
                ExpDate = DateTime.Parse(node.Attributes["ExpDate"].Value);
                food = new FoodProduct(Id, Name, Producer, PriceInput, PriceOutput, Category.Food, MfgDate, ExpDate);
                lstFoodExp.Add(food);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstFoodExp;
        }

        public double PriceOutput(double priceInput)
        {
            double priceoutput = 0;
            return priceoutput = priceInput + (priceInput * VAT) + (priceInput * LoiNhuan) + (priceInput * (accVM.lstAcc.Count * 0.012));
        }

        public void Create(FoodProduct food)
        {
            string[] mfgdate;
            string[] expdate;
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            mfgdate = food.MfgDate.GetDateTimeFormats('d', culture);
            expdate = food.ExpDate.GetDateTimeFormats('d', culture);
            double priceOutput = PriceOutput(food.getPriceInput());
            DataProvider.Instance.pathData = "data/Inventory/ExpDate.xml";
            var newNode = DataProvider.Instance.createNode("ExpDate");
            var attr1 = DataProvider.Instance.createAttr("Id");
            attr1.Value = food.getID().ToString();
            var attr2 = DataProvider.Instance.createAttr("Name");
            attr2.Value = food.getName().ToString();
            var attr3 = DataProvider.Instance.createAttr("Category");
            attr3.Value = food.getCategory().ToString();
            var attr4 = DataProvider.Instance.createAttr("Producer");
            attr4.Value = food.getProduct().ToString();
            var attr5 = DataProvider.Instance.createAttr("PriceInput");
            attr5.Value = food.getPriceInput().ToString();
            var attr6 = DataProvider.Instance.createAttr("PriceOutput");
            attr6.Value = priceOutput.ToString();
            var attr7 = DataProvider.Instance.createAttr("MfgDate");
            attr7.Value = mfgdate[0];
            var attr8 = DataProvider.Instance.createAttr("ExpDate");
            attr8.Value = expdate[0];
            newNode.Attributes.Append(attr1);
            newNode.Attributes.Append(attr2);
            newNode.Attributes.Append(attr3);
            newNode.Attributes.Append(attr4);
            newNode.Attributes.Append(attr5);
            newNode.Attributes.Append(attr6);
            newNode.Attributes.Append(attr7);
            newNode.Attributes.Append(attr8);
            newNode.InnerText = string.Empty;
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            DataProvider.Instance.AppendNode(DataProvider.Instance.nodeRoot, newNode);
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }

        public void Update(string xPath, double newprice)
        {
            DataProvider.Instance.pathData = "data/Product/FoodProduct.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node = DataProvider.Instance.getNode(xPath);
            node.Attributes["PriceInput"].Value = newprice.ToString();
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }
    }
}
