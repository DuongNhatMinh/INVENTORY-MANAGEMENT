using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_C3_B1
{
    class DetailOrderViewModel
    {
        public DetailOrder detailOrder = new DetailOrder();
        public ObservableCollection<DetailOrder> lstdetailOrder = new ObservableCollection<DetailOrder>();

        public ObservableCollection<DetailOrder> getListByID(string xPath)
        {
            lstdetailOrder = new ObservableCollection<DetailOrder>();
            DataProvider.Instance.pathData = "data/Order/DetailOrder.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            detailOrder = null;
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
                IdReceipt = node.Attributes["IdOrder"].Value;
                IdProduct = node.Attributes["IdProduct"].Value;
                Name = node.Attributes["Name"].Value;
                category = node.Attributes["IdCategory"].Value;
                Priceoutput = double.Parse(node.Attributes["PriceOutput"].Value);
                Quantity = double.Parse(node.Attributes["Quantity"].Value);
                Amount = double.Parse(node.Attributes["Amount"].Value);
                if (category == Category.Electronic.ToString())
                    detailOrder = new DetailOrder(Id, IdReceipt, IdProduct, Name, Category.Electronic, Priceoutput, Quantity, Amount);
                else if (category == Category.Food.ToString())
                    detailOrder = new DetailOrder(Id, IdReceipt, IdProduct, Name, Category.Food, Priceoutput, Quantity, Amount);
                else
                    detailOrder = new DetailOrder(Id, IdReceipt, IdProduct, Name, Category.Porcelain, Priceoutput, Quantity, Amount);
                lstdetailOrder.Add(detailOrder);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstdetailOrder;
        }


        public void Create(ObservableCollection<DetailOrder> lstdetailOrder)
        {
            DataProvider.Instance.pathData = "data/Order/DetailOrder.xml";
            for (int i = 0; i < lstdetailOrder.Count; i++)
            {
                var newNode = DataProvider.Instance.createNode("DetailOrder");
                var attr1 = DataProvider.Instance.createAttr("Id");
                attr1.Value = lstdetailOrder[i].Id.ToString();
                var attr2 = DataProvider.Instance.createAttr("IdOrder");
                attr2.Value = lstdetailOrder[i].IdOrder.ToString();
                var attr3 = DataProvider.Instance.createAttr("IdProduct");
                attr3.Value = lstdetailOrder[i].IdProduct.ToString();
                var attr4 = DataProvider.Instance.createAttr("Name");
                attr4.Value = lstdetailOrder[i].Name.ToString();
                var attr5 = DataProvider.Instance.createAttr("IdCategory");
                attr5.Value = lstdetailOrder[i].Categories.ToString();
                var attr6 = DataProvider.Instance.createAttr("PriceOutput");
                attr6.Value = lstdetailOrder[i].PriceOutput.ToString();
                var attr7 = DataProvider.Instance.createAttr("Quantity");
                attr7.Value = lstdetailOrder[i].Quantity.ToString();
                var attr8 = DataProvider.Instance.createAttr("Amount");
                attr8.Value = lstdetailOrder[i].Amount.ToString();
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
