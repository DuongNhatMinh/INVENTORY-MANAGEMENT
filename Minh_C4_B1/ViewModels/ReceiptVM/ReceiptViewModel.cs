using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_C3_B1
{
    class ReceiptViewModel
    {
        public Receipt receipt = new Receipt();
        public ObservableCollection<Receipt> lstReceipt = new ObservableCollection<Receipt>();

        public ObservableCollection<Receipt> getList(string xPath)
        {
            lstReceipt = new ObservableCollection<Receipt>();
            DataProvider.Instance.pathData = "data/Receipt/Receipt.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            receipt = null;
            string Id = string.Empty;
            string UserName = string.Empty;
            DateTime CreateAt = DateTime.Now;
            double Total = 0;
            double Quantity = 0;
            foreach (XmlNode node in lstNode)
            {
                Id = node.Attributes["Id"].Value;
                UserName = node.Attributes["UserName"].Value;
                CreateAt = Convert.ToDateTime(node.Attributes["CreateAt"].Value);
                Total = double.Parse(node.Attributes["Total"].Value);
                Quantity = double.Parse(node.Attributes["Quantity"].Value);
                receipt = new Receipt(Id, UserName, Quantity, Total, CreateAt);
                lstReceipt.Add(receipt);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstReceipt;
        }

        public void Create(Receipt Receipt)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            // Get the short date formats using the "fr-FR" culture.
            string[] date = Receipt.CreateAt.GetDateTimeFormats(culture);
            DataProvider.Instance.pathData = "data/Receipt/Receipt.xml";
            var newNode = DataProvider.Instance.createNode("Receipt");
            var attr1 = DataProvider.Instance.createAttr("Id");
            attr1.Value = Receipt.Id.ToString();
            var attr2 = DataProvider.Instance.createAttr("UserName");
            attr2.Value = Receipt.Username.ToString();
            var attr3 = DataProvider.Instance.createAttr("Quantity");
            attr3.Value = Receipt.Quantity.ToString();
            var attr4 = DataProvider.Instance.createAttr("Total");
            attr4.Value = Receipt.Total.ToString();
            var attr5 = DataProvider.Instance.createAttr("CreateAt");
            attr5.Value = date[30];
            newNode.Attributes.Append(attr1);
            newNode.Attributes.Append(attr2);
            newNode.Attributes.Append(attr3);
            newNode.Attributes.Append(attr4);
            newNode.Attributes.Append(attr5);
            newNode.InnerText = string.Empty;
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            DataProvider.Instance.AppendNode(DataProvider.Instance.nodeRoot, newNode);
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }
    }
}
