using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_C3_B1
{
    class DetailReceiptViewModel
    {
        public DetailReceipt detailReceipt = new DetailReceipt();
        public ObservableCollection<DetailReceipt> lstDetailReceipt = new ObservableCollection<DetailReceipt>();

        public ObservableCollection<DetailReceipt> getListByID(string xPath)
        {
            lstDetailReceipt = new ObservableCollection<DetailReceipt>();
            DataProvider.Instance.pathData = "data/Receipt/DetailReceipt.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            detailReceipt = null;
            int Id = 0;
            string IdReceipt = string.Empty;
            string IdProduct = string.Empty;
            string Name = string.Empty;
            string category = string.Empty;
            double PriceInput = 0;
            double Priceoutput = 0;
            double Quantity = 0;
            double Amount = 0;
            foreach (XmlNode node in lstNode)
            {
                Id = Int32.Parse(node.Attributes["Id"].Value);
                IdReceipt = node.Attributes["IdReceipt"].Value;
                IdProduct = node.Attributes["IdProduct"].Value;
                Name = node.Attributes["Name"].Value;
                category = node.Attributes["IdCategory"].Value;
                PriceInput = double.Parse(node.Attributes["PriceInput"].Value);
                Priceoutput = double.Parse(node.Attributes["PriceOutput"].Value);
                Quantity = double.Parse(node.Attributes["Quantity"].Value);
                Amount = double.Parse(node.Attributes["Amount"].Value);
                if(category == Category.Electronic.ToString())
                    detailReceipt = new DetailReceipt(Id, IdReceipt, IdProduct, Name, Category.Electronic, PriceInput, Priceoutput, Quantity, Amount);
                else if(category == Category.Food.ToString())
                    detailReceipt = new DetailReceipt(Id, IdReceipt, IdProduct, Name, Category.Food, PriceInput, Priceoutput, Quantity, Amount);
                else
                    detailReceipt = new DetailReceipt(Id, IdReceipt, IdProduct, Name, Category.Porcelain, PriceInput, Priceoutput, Quantity, Amount);
                lstDetailReceipt.Add(detailReceipt);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstDetailReceipt;
        }

        public void Create(ObservableCollection<DetailReceipt> lstdetailReceipt)
        {
            DataProvider.Instance.pathData = "data/Receipt/DetailReceipt.xml";
            for(int i = 0; i < lstdetailReceipt.Count; i++)
            {
                var newNode = DataProvider.Instance.createNode("DetailReceipt");
                var attr1 = DataProvider.Instance.createAttr("Id");
                attr1.Value = lstdetailReceipt[i].Id.ToString();
                var attr2 = DataProvider.Instance.createAttr("IdReceipt");
                attr2.Value = lstdetailReceipt[i].IdReceipt.ToString();
                var attr3 = DataProvider.Instance.createAttr("IdProduct");
                attr3.Value = lstdetailReceipt[i].IdProduct.ToString();
                var attr4 = DataProvider.Instance.createAttr("Name");
                attr4.Value = lstdetailReceipt[i].Name.ToString();
                var attr5 = DataProvider.Instance.createAttr("IdCategory");
                attr5.Value = lstdetailReceipt[i].Categories.ToString();
                var attr6 = DataProvider.Instance.createAttr("PriceInput");
                attr6.Value = lstdetailReceipt[i].PriceInput.ToString();
                var attr7 = DataProvider.Instance.createAttr("PriceOutput");
                attr7.Value = lstdetailReceipt[i].PriceOutput.ToString();
                var attr8 = DataProvider.Instance.createAttr("Quantity");
                attr8.Value = lstdetailReceipt[i].Quantity.ToString();
                var attr9 = DataProvider.Instance.createAttr("Amount");
                attr9.Value = lstdetailReceipt[i].Amount.ToString();
                newNode.Attributes.Append(attr1);
                newNode.Attributes.Append(attr2);
                newNode.Attributes.Append(attr3);
                newNode.Attributes.Append(attr4);
                newNode.Attributes.Append(attr5);
                newNode.Attributes.Append(attr6);
                newNode.Attributes.Append(attr7);
                newNode.Attributes.Append(attr8);
                newNode.Attributes.Append(attr9);
                newNode.InnerText = string.Empty;
                DataProvider.Instance.Open(); // Mở tài liệu Xml
                DataProvider.Instance.AppendNode(DataProvider.Instance.nodeRoot, newNode);
                DataProvider.Instance.Close(); // Đóng tài liệu Xml
            }
        }
    }
}
