using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_C3_B1
{
    class DetailInvoiceViewModel
    {
        public DetailInvoice detailInvoice = new DetailInvoice();
        public ObservableCollection<DetailInvoice> lstDetailInvoice = new ObservableCollection<DetailInvoice>();

        public ObservableCollection<DetailInvoice> getListByID(string xPath)
        {
            lstDetailInvoice = new ObservableCollection<DetailInvoice>();
            DataProvider.Instance.pathData = "data/Invoice/DetailInvoice.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            detailInvoice = null;
            int Id = 0;
            string IdReceipt = string.Empty;
            string IdProduct = string.Empty;
            string Name = string.Empty;
            string category = string.Empty;
            double Priceoutput = 0;
            double Quantity = 0;
            double Amount = 0;
            foreach (XmlNode node in lstNode)
            {
                Id = Int32.Parse(node.Attributes["Id"].Value);
                IdReceipt = node.Attributes["IdInvoice"].Value;
                IdProduct = node.Attributes["IdProduct"].Value;
                Name = node.Attributes["Name"].Value;
                category = node.Attributes["IdCategory"].Value;
                Priceoutput = double.Parse(node.Attributes["PriceOutput"].Value);
                Quantity = double.Parse(node.Attributes["Quantity"].Value);
                Amount = double.Parse(node.Attributes["Amount"].Value);
                if (category == Category.Electronic.ToString())
                    detailInvoice = new DetailInvoice(Id, IdReceipt, IdProduct, Name, Category.Electronic, Priceoutput, Quantity, Amount);
                else if (category == Category.Food.ToString())
                    detailInvoice = new DetailInvoice(Id, IdReceipt, IdProduct, Name, Category.Food, Priceoutput, Quantity, Amount);
                else
                    detailInvoice = new DetailInvoice(Id, IdReceipt, IdProduct, Name, Category.Porcelain, Priceoutput, Quantity, Amount);
                lstDetailInvoice.Add(detailInvoice);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstDetailInvoice;
        }


        public void Create(ObservableCollection<DetailInvoice> lstdetailInvoice)
        {
            DataProvider.Instance.pathData = "data/Invoice/DetailInvoice.xml";
            for (int i = 0; i < lstdetailInvoice.Count; i++)
            {
                var newNode = DataProvider.Instance.createNode("DetailInvoice");
                var attr1 = DataProvider.Instance.createAttr("Id");
                attr1.Value = lstdetailInvoice[i].Id.ToString();
                var attr2 = DataProvider.Instance.createAttr("IdInvoice");
                attr2.Value = lstdetailInvoice[i].IdInvoice.ToString();
                var attr3 = DataProvider.Instance.createAttr("IdProduct");
                attr3.Value = lstdetailInvoice[i].IdProduct.ToString();
                var attr4 = DataProvider.Instance.createAttr("Name");
                attr4.Value = lstdetailInvoice[i].Name.ToString();
                var attr5 = DataProvider.Instance.createAttr("IdCategory");
                attr5.Value = lstdetailInvoice[i].Categories.ToString();
                var attr6 = DataProvider.Instance.createAttr("PriceOutput");
                attr6.Value = lstdetailInvoice[i].PriceOutput.ToString();
                var attr7 = DataProvider.Instance.createAttr("Quantity");
                attr7.Value = lstdetailInvoice[i].Quantity.ToString();
                var attr8 = DataProvider.Instance.createAttr("Amount");
                attr8.Value = lstdetailInvoice[i].Amount.ToString();
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
        }
    }
}
