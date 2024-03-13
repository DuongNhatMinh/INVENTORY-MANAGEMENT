using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_C3_B1
{
    class ElectricViewModel : IPriceOutput
    {
        private double VAT = 0.1, LoiNhuan = 0.3;
        AccountViewModel accVM = new AccountViewModel();
        public RepositoryBase<ElectronicProduct> elecRepo { get; set; }
        public ElectronicProduct electronic = new ElectronicProduct();
        public List<ElectronicProduct> lstElectronic = new List<ElectronicProduct>();
        public UnitOfWork unit { get; set; }

        public ElectricViewModel()
        {
            
        }

        public void getList()
        {
            unit = new UnitOfWork();
            elecRepo = unit.GetRepositoryElectric;
            accVM.getList("/Accounts/Account");
            lstElectronic = getList("/Products/Product");
        }

        public List<ElectronicProduct> getList(string xPath)
        {
            string Id = string.Empty;
            string Name = string.Empty;
            string Producer = string.Empty;
            double PriceInput = 0;
            double PriceOutput = 0;
            string category;
            double warranty = 0;
            double electricpower = 0;
            DataProvider.Instance.pathData = "data/Product/ElectronicProduct.xml";
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
                warranty = double.Parse(node.Attributes["Warranty"].Value);
                electricpower = double.Parse(node.Attributes["ElectricPower"].Value);
                electronic = new ElectronicProduct(Id, Name, Producer, PriceInput, PriceOutput, Category.Electronic, warranty, electricpower);
                lstElectronic.Add(electronic);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstElectronic;
        }

        public double PriceOutput(double priceInput)
        {
            double priceoutput = 0;
            return priceoutput = priceInput + (priceInput * VAT) + (priceInput * LoiNhuan) + (priceInput * (accVM.lstAcc.Count * 0.012));
        }

        public void Update(string xPath, double newprice)
        {
            DataProvider.Instance.pathData = "data/Product/ElectronicProduct.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node = DataProvider.Instance.getNode(xPath);
            node.Attributes["PriceInput"].Value = newprice.ToString();
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }
    }
}
