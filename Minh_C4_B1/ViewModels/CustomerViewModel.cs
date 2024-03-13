using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_C3_B1
{
    class CustomerViewModel
    {
        public Customer customer = new Customer();
        public Customer customertemp = new Customer();
        public List<Customer> lstCustomer = new List<Customer>();

        public List<Customer> getList(string xPath)
        {
            string Name = string.Empty;
            string Phone = string.Empty;
            string CardID = string.Empty;
            double Point = 0;
            string CardType = string.Empty;
            DataProvider.Instance.pathData = "data/Customer/Customer.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            foreach (XmlNode node in lstNode)
            {
                Name = node.Attributes["Name"].Value;
                Phone = node.Attributes["Phone"].Value;
                CardID = node.Attributes["CardID"].Value;
                Point = Int32.Parse(node.Attributes["Point"].Value);
                CardType = node.Attributes["CardType"].Value;
                customer = new Customer(Name, Phone, CardID, Point, CardType);
                lstCustomer.Add(customer);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstCustomer;
        }

        public double TotalPoint(double amount)
        {
            int point = (int)(amount * 0.001);
            return customer.Point += point;
        }

        public void CardType(Customer customer)
        {
            if (customer.Point > 10000)
                customertemp = new Customer(customer.Name, customer.Phone, customer.CardID, customer.Point, "Platinum");
            else if (customer.Point > 5000 && customer.Point < 10000)
                customertemp = new Customer(customer.Name, customer.Phone, customer.CardID, customer.Point, "Gold");
            else
                customertemp = new Customer(customer.Name, customer.Phone, customer.CardID, customer.Point, "None");
        }

        public void Update(Customer customer, string pathdata)
        {
            string xpath = string.Format("Customer[@CardID='{0}']", customer.CardID);
            DataProvider.Instance.pathData = pathdata;
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node = DataProvider.Instance.getNode(xpath);
            node.Attributes["Point"].Value = customer.Point.ToString();
            if (customer.Point > 10000)
                node.Attributes["CardType"].Value = "Platium";
            else if (customer.Point > 5000 && customer.Point < 10000)
                node.Attributes["CardType"].Value = "Gold";
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }

        public void Create(Customer customer)
        {
            DataProvider.Instance.pathData = "data/Customer/Customer.xml";
            var newNode = DataProvider.Instance.createNode("Customer");
            var attr1 = DataProvider.Instance.createAttr("Name");
            attr1.Value = customer.Name;
            var attr2 = DataProvider.Instance.createAttr("Phone");
            attr2.Value = customer.Phone;
            var attr3 = DataProvider.Instance.createAttr("CardID");
            attr3.Value = customer.CardID;
            var attr4 = DataProvider.Instance.createAttr("Point");
            attr4.Value = customer.Point.ToString();
            var attr5 = DataProvider.Instance.createAttr("CardType");
            attr5.Value = customer.CardType;
            newNode.Attributes.Append(attr1);
            newNode.Attributes.Append(attr2);
            newNode.Attributes.Append(attr3);
            newNode.Attributes.Append(attr4);
            newNode.Attributes.Append(attr5);
            //newNode.InnerText = string.Empty;
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            DataProvider.Instance.AppendNode(DataProvider.Instance.nodeRoot, newNode);
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }
    }
}
