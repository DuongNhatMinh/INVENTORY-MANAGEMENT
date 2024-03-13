using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_C3_B1
{
    class OrderViewModel: IDoDiscount
    {
        public Order order = new Order();
        public List<Order> lstOrder = new List<Order>();
        public ObservableCollection<Order> lstOrder2 = new ObservableCollection<Order>();

        public ObservableCollection<Order> getList(string xPath)
        {
            lstOrder2 = new ObservableCollection<Order>();
            DataProvider.Instance.pathData = "data/Order/Order.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            order = null;
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
                order = new Order(Id, UserName, Quantity, Total, CreateAt);
                lstOrder2.Add(order);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstOrder2;

        }
        public List<Order> getList2(string xPath)
        {
            lstOrder = new List<Order>();
            DataProvider.Instance.pathData = "data/Order/Order.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            order = null;
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
                order = new Order(Id, UserName, Quantity, Total, CreateAt);
                lstOrder.Add(order);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstOrder;
        }

        public void Create(Order Order)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            string[] date = Order.CreateAt.GetDateTimeFormats(culture);
            DataProvider.Instance.pathData = "data/Order/Order.xml";
            var newNode = DataProvider.Instance.createNode("Order");
            var attr1 = DataProvider.Instance.createAttr("Id");
            attr1.Value = Order.Id.ToString();
            var attr2 = DataProvider.Instance.createAttr("UserName");
            attr2.Value = Order.Username.ToString();
            var attr3 = DataProvider.Instance.createAttr("Quantity");
            attr3.Value = Order.Quantity.ToString();
            var attr4 = DataProvider.Instance.createAttr("Total");
            attr4.Value = Order.Total.ToString();
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

        public double DiscountFood(double quantity, double amount)
        {
            double discount;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                discount = amount * 0.25;
                return discount * quantity;
            }
            else
                return 0;
        }

        public double DiscountElectric(double quantity, double amount)
        {
            double discount;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {
                discount = amount * 0.15;
                return discount * quantity;
            }
            else
                return 0;
        }

        public double DiscountPorcelain(double quantity, double amount)
        {
            double discount;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                discount = amount * 0.30;   
                return discount * quantity;
            }
            else
                return 0;
        }
    }
}
