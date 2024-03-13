using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_C3_B1
{
    class PorcelainViewModel:IPriceOutput
    {
        private double VAT = 0.1, LoiNhuan = 0.3;
        public RepositoryBase<PorcelainProduct> porcelainRepo { get; set; }
        public PorcelainProduct porcelain = new PorcelainProduct();
        public List<PorcelainProduct> lstPorcelain = new List<PorcelainProduct>();
        AccountViewModel accVM
        {
            get; set;
        }
        public UnitOfWork unit { get; set; }
                private Utilities ult = new Utilities();

        public PorcelainViewModel()
        {
            accVM = new AccountViewModel();
            accVM.getList("/Accounts/Account");
        }

        public void getList()
        {
            unit = new UnitOfWork();
            accVM = new AccountViewModel();
            porcelainRepo = unit.GetRepositoryPorcelain;
            accVM.getList("/Accounts/Account");
            lstPorcelain = getList("/Products/Product");
        }

        public List<PorcelainProduct> getList(string xPath)
        {
            string Id = string.Empty;
            string Name = string.Empty;
            string Producer = string.Empty;
            double PriceInput = 0;
            double PriceOutput = 0;
            string category;
            string material = string.Empty;
            DataProvider.Instance.pathData = "data/Product/PorcelainProduct.xml";
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
                material = node.Attributes["Material"].Value;
                porcelain = new PorcelainProduct(Id, Name, Producer, PriceInput, PriceOutput, Category.Porcelain, material);
                lstPorcelain.Add(porcelain);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstPorcelain;
        }

        public double PriceOutput(double priceInput)
        {
            double priceoutput = 0;
            return priceoutput = priceInput + (priceInput * VAT) + (priceInput * LoiNhuan) + (priceInput * (accVM.lstAcc.Count * 0.012));
        }

        public void Update(string xPath, double newprice)
        {
            DataProvider.Instance.pathData = "data/Product/PorcelainProduct.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node = DataProvider.Instance.getNode(xPath);
            node.Attributes["PriceInput"].Value = newprice.ToString();
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }
    }
}
