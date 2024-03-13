using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_C3_B1
{
    class InventoryViewModel
    {
        public Inventory Inventory = new Inventory();
        public ObservableCollection<Inventory> lstInventory = new ObservableCollection<Inventory>();

        public ObservableCollection<Inventory> getList(string xPath, string pathdata)
        {
            ObservableCollection<Inventory> lstInventory2 = new ObservableCollection<Inventory>();
            int Id = 0;
            string Product = string.Empty;
            double Previous = 0;
            double AmountPrevious = 0;
            double Recent = 0;
            double AmountRecent = 0;
            DateTime Date;
            double Quantity;
            double Amount;
            DataProvider.Instance.pathData = pathdata;
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            foreach (XmlNode node in lstNode)
            {
                Id = Int32.Parse(node.Attributes["Id"].Value);
                Product = node.Attributes["Product"].Value;
                Previous = double.Parse(node.Attributes["Previous"].Value);
                AmountPrevious = double.Parse(node.Attributes["AmountPrevious"].Value);
                Recent = double.Parse(node.Attributes["Recent"].Value);
                AmountRecent = double.Parse(node.Attributes["AmountRecent"].Value);
                Date = Convert.ToDateTime(node.Attributes["Date"].Value);
                Quantity = double.Parse(node.Attributes["Quantity"].Value);
                Amount = double.Parse(node.Attributes["Amount"].Value);
                Inventory = new Inventory(Id, Product, Previous, AmountPrevious, Recent, AmountRecent, Date, Quantity, Amount);
                lstInventory2.Add(Inventory);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstInventory2;
        }

        private int check(ObservableCollection<Inventory> value1, string value2)
        {
            for (int j = 0; j < value1.Count; j++)
            {
                if (value1[j].Product == value2)
                {
                    return 1;
                }
            }
            return 0;
        }

        public void Add(DetailReceipt detailReceipt, string pathdata)
        {
            int id = 0;
            ObservableCollection<Inventory> Inventorys = new ObservableCollection<Inventory>();
            double previous = 0, amountprevious = 0, quantity = 0, amount = 0;
            DateTime dateinvoice = new DateTime(1900, 01, 01);
            Inventorys = getList("/Inventorys/Inventory", pathdata);
            for (int i = 0; i < Inventorys.Count; i++)
            {
                id = Int32.Parse(Inventorys[i].Id.ToString());
            }
            if (Inventorys.Count == 0)
            {
                quantity = previous + detailReceipt.Quantity;
                amount = amountprevious + (detailReceipt.PriceInput * detailReceipt.Quantity);
                Inventory = new Inventory(detailReceipt.Id, detailReceipt.Name, previous, amountprevious, detailReceipt.Quantity, (detailReceipt.PriceInput * detailReceipt.Quantity),
                DateTime.Now, quantity, amount);
            }
            else
            {
                for (int i = 0; i < Inventorys.Count; i++)
                {
                    if (Inventorys[i].Product == detailReceipt.Name)
                    {
                        previous = Inventorys[i].Quantity;
                        amountprevious = Inventorys[i].Amount;
                        quantity = previous + detailReceipt.Quantity;
                        amount = amountprevious + (detailReceipt.PriceInput * detailReceipt.Quantity);
                        Inventory = new Inventory(id++, detailReceipt.Name, previous, amountprevious, detailReceipt.Quantity, (detailReceipt.PriceInput * detailReceipt.Quantity),
                        DateTime.Now, quantity, amount);
                        break;
                    }
                }
                if(check(Inventorys, detailReceipt.Name) == 0)
                {
                    if (lstInventory.Count == 0)
                    {
                        id++;
                    }
                    else
                    {
                        for (int i = 0; i < lstInventory.Count; i++)
                        {
                            id = Int32.Parse(lstInventory[i].Id.ToString());
                            id++;
                        }
                    }
                    quantity = previous + detailReceipt.Quantity;
                    amount = amountprevious + (detailReceipt.PriceInput * detailReceipt.Quantity);
                    Inventory = new Inventory(id, detailReceipt.Name, previous, amountprevious, detailReceipt.Quantity, (detailReceipt.PriceInput * detailReceipt.Quantity),
                    DateTime.Now, quantity, amount);
                }
            }
            lstInventory.Add(Inventory);
        }

        public void Add(DetailInvoice detailInvoice, string pathdata)
        {
            int id = 0;
            ObservableCollection<Inventory> Inventorys = new ObservableCollection<Inventory>();
            double previous = 0, amountprevious = 0, quantity = 0, amount = 0;
            DateTime dateinvoice = new DateTime(1900, 01, 01);
            Inventorys = getList("/Inventorys/Inventory", pathdata);
            for (int i = 0; i < Inventorys.Count; i++)
            {
                id = Int32.Parse(Inventorys[i].Id.ToString());
            }
            if (Inventorys.Count == 0)
            {
                quantity = previous + detailInvoice.Quantity;
                amount = amountprevious + (detailInvoice.PriceOutput * detailInvoice.Quantity);
                Inventory = new Inventory(detailInvoice.Id, detailInvoice.Name, previous, amountprevious, detailInvoice.Quantity, (detailInvoice.PriceOutput * detailInvoice.Quantity),
                DateTime.Now, quantity, amount);
            }
            else
            {
                for (int i = 0; i < Inventorys.Count; i++)
                {
                    if (Inventorys[i].Product == detailInvoice.Name)
                    {
                        previous = Inventorys[i].Quantity;
                        amountprevious = Inventorys[i].Amount;
                        quantity = previous + detailInvoice.Quantity;
                        amount = amountprevious + (detailInvoice.PriceOutput * detailInvoice.Quantity);
                        Inventory = new Inventory(id++, detailInvoice.Name, previous, amountprevious, detailInvoice.Quantity, (detailInvoice.PriceOutput * detailInvoice.Quantity),
                        DateTime.Now, quantity, amount);
                        break;
                    }
                }
                if (check(Inventorys, detailInvoice.Name) == 0)
                {
                    if (lstInventory.Count == 0)
                    {
                        id++;
                    }
                    else
                    {
                        for (int i = 0; i < lstInventory.Count; i++)
                        {
                            id = Int32.Parse(lstInventory[i].Id.ToString());
                            id++;
                        }
                    }
                    quantity = previous + detailInvoice.Quantity;
                    amount = amountprevious + (detailInvoice.PriceOutput * detailInvoice.Quantity);
                    Inventory = new Inventory(id++, detailInvoice.Name, previous, amountprevious, detailInvoice.Quantity, (detailInvoice.PriceOutput * detailInvoice.Quantity),
                    DateTime.Now, quantity, amount);
                }
            }
            lstInventory.Add(Inventory);
        }

        public void Save(string pathdata)
        {
            ObservableCollection<Inventory> Inventorys = new ObservableCollection<Inventory>();
            Inventorys = getList("/Inventorys/Inventory", pathdata);
            if (Inventorys.Count == 0)
            {
                for (int i = 0; i < lstInventory.Count; i++)
                {
                    Create(lstInventory[i], pathdata);
                }
            }
            else
            {
                for (int i = 0; i < lstInventory.Count; i++)
                {
                    int flag = 0;
                    string xpath = string.Format("Inventory[@Product='{0}']", lstInventory[i].Product);
                    if (check(Inventorys, lstInventory[i].Product) == 1)
                    {
                        Update(xpath, lstInventory[i], pathdata);
                    }
                    else if (flag == 0)
                    {
                        Create(lstInventory[i], pathdata);
                        flag = 1;
                    }
                }
            }
        }

        public void Create(Inventory inventory, string pathdata)
        {
            string[] date;
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            date = inventory.Date.GetDateTimeFormats('d', culture);
            DataProvider.Instance.pathData = pathdata;
            var newNode = DataProvider.Instance.createNode("Inventory");
            var attr1 = DataProvider.Instance.createAttr("Id");
            attr1.Value = inventory.Id.ToString();
            var attr2 = DataProvider.Instance.createAttr("Product");
            attr2.Value = inventory.Product.ToString();
            var attr3 = DataProvider.Instance.createAttr("Previous");
            attr3.Value = inventory.Previous.ToString();
            var attr4 = DataProvider.Instance.createAttr("AmountPrevious");
            attr4.Value = inventory.AmountPrevious.ToString();
            var attr5 = DataProvider.Instance.createAttr("Recent");
            attr5.Value = inventory.Recent.ToString();
            var attr6 = DataProvider.Instance.createAttr("AmountRecent");
            attr6.Value = inventory.AmountRecent.ToString();
            var attr7 = DataProvider.Instance.createAttr("Date");
            attr7.Value = date[0];
            var attr8 = DataProvider.Instance.createAttr("Quantity");
            attr8.Value = inventory.Quantity.ToString();
            var attr9 = DataProvider.Instance.createAttr("Amount");
            attr9.Value = inventory.Amount.ToString();
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

        public void Update(string xPath, Inventory inventory, string pathdata)
        {
            string[] date;
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            date = inventory.Date.GetDateTimeFormats('d', culture);
            DataProvider.Instance.pathData = pathdata;
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node = DataProvider.Instance.getNode(xPath);
            node.Attributes["Previous"].Value = inventory.Previous.ToString();
            node.Attributes["AmountPrevious"].Value = inventory.AmountPrevious.ToString();
            node.Attributes["Recent"].Value = inventory.Recent.ToString();
            node.Attributes["AmountRecent"].Value = inventory.AmountRecent.ToString();
            node.Attributes["Date"].Value = date[0];
            node.Attributes["Quantity"].Value = inventory.Quantity.ToString();
            node.Attributes["Amount"].Value = inventory.Amount.ToString();
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }
    }
}
