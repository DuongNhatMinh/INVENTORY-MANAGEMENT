using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_C3_B1
{
    class InvoiceViewModel
    {
        public Invoice invoice = new Invoice();
        public ObservableCollection<Invoice> lstInvoice = new ObservableCollection<Invoice>();

        public ObservableCollection<Invoice> getList(string xPath)
        {
            lstInvoice = new ObservableCollection<Invoice>();
            DataProvider.Instance.pathData = "data/Invoice/Invoice.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            invoice = null;
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
                invoice = new Invoice(Id, UserName, Quantity, Total, CreateAt);
                lstInvoice.Add(invoice);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstInvoice;
        }

        public void Create(Invoice Invoice)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            string[] date = Invoice.CreateAt.GetDateTimeFormats(culture);
            DataProvider.Instance.pathData = "data/Invoice/Invoice.xml";
            var newNode = DataProvider.Instance.createNode("Invoice");
            var attr1 = DataProvider.Instance.createAttr("Id");
            attr1.Value = Invoice.Id.ToString();
            var attr2 = DataProvider.Instance.createAttr("UserName");
            attr2.Value = Invoice.Username.ToString();
            var attr3 = DataProvider.Instance.createAttr("Quantity");
            attr3.Value = Invoice.Quantity.ToString();
            var attr4 = DataProvider.Instance.createAttr("Total");
            attr4.Value = Invoice.Total.ToString();
            var attr5 = DataProvider.Instance.createAttr("CreateAt");
            attr5.Value = date[30].ToString();
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
