using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Minh_C3_B1
{
    class Utilities
    {
        private List<DetailOrder> lstdetailOrder { get; set; }
        private ObservableCollection<Order> lstOrder = new ObservableCollection<Order>();
        private Order order = new Order();
        private OrderViewModel OrderVM = new OrderViewModel();

        private List<DetailReceipt> lstdetailReceipt { get; set; }
        private ObservableCollection<Receipt> lstReceipt = new ObservableCollection<Receipt>();
        private ReceiptViewModel receiptVM = new ReceiptViewModel();
        private Receipt receipt = new Receipt();

        private List<DetailInvoice> lstdetailInvoice { get; set; }
        private ObservableCollection<Invoice> lstInvoice = new ObservableCollection<Invoice>();
        private InvoiceViewModel invoiceVM = new InvoiceViewModel();
        private Invoice invoice = new Invoice();
        private AccountViewModel accVM { get; set; }
        private double VAT = 0.1, LoiNhuan = 0.3;
        private object resultString;

        #region Methods
        public double PriceOutput(double priceInput)
        {
            accVM = new AccountViewModel();
            accVM.getList("/Accounts/Account");
            double priceoutput = 0;
            return priceoutput = priceInput + (priceInput * VAT) + (priceInput * LoiNhuan) + (priceInput * (accVM.lstAcc.Count * 0.012));
        }

        public Receipt getReceipt(string name)
        {
            lstdetailReceipt = new List<DetailReceipt>();
            lstReceipt = receiptVM.getList("/Receipts/Receipt");
            int id = 0;
            for (int i = 0; i < lstReceipt.Count; i++)
            {
                resultString = Regex.Match(lstReceipt[i].Id, @"\d+").Value;
                id = Int32.Parse(resultString.ToString());
            }
            if (id != 1)
                id++;
            else

                id++;
            return receipt = new Receipt("PNK" + id, name, 0, 0, DateTime.Now);
        }

        public Invoice getInvoice(string name)
        {
            lstdetailInvoice = new List<DetailInvoice>();
            lstInvoice = invoiceVM.getList("/Invoices/Invoice");
            int id = 0;
            for (int i = 0; i < lstInvoice.Count; i++)
            {
                resultString = Regex.Match(lstInvoice[i].Id, @"\d+").Value;
                id = Int32.Parse(resultString.ToString());
            }
            if (id != 1)
                id++;
            else

                id++;
            return invoice = new Invoice("PXK" + id, name, 0, 0, DateTime.Now);
        }

        public Order getOrder(string name)
        {
            lstdetailOrder = new List<DetailOrder>();
            lstOrder = OrderVM.getList("/Orders/Order");
            int id = 0;
            for (int i = 0; i < lstOrder.Count; i++)
            {
                resultString = Regex.Match(lstOrder[i].Id, @"\d+").Value;
                id = Int32.Parse(resultString.ToString());
            }
            if (id != 1)
                id++;
            else

                id++;
            return order = new Order("PBH" + id, name, 0, 0, DateTime.Now);
        }

        public int Convert(int value)
        {
            string str;
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.NumberDecimalSeparator = ",";
            str = value.ToString("N0", culture);
            return Int32.Parse(str);
            //Console.Write(str + "VND\n");
        }

        public string Convert(double value)
        {
            string str;
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.NumberDecimalSeparator = ",";
            str = value.ToString("N0", culture);
            return str;
            //Console.Write(str + "VND");
        }

        public void Output()
        {
            //Console.WriteLine("This Product ExpDate");
            //Console.ReadKey();
            MessageBox.Show("This Product ExpDate");
        }

        public void Notify()
        {
            MessageBox.Show("Login Fail");
        }


        public void Notify1()
        {
            //Console.WriteLine("Successfuly");
            //Console.ReadKey();
        }

        public int check(List<FoodProduct> lstFood)
        {
            for (int i = 0; i < lstFood.Count; i++)
            {
                if (lstFood[i].ExpDate < DateTime.Now)
                    return 1;
            }
            return -1;
        }

        public int check(FoodProduct Food)
        {
            if (Food.ExpDate < DateTime.Now)
                return 1;
            return -1;
        }

        public int check(FoodProduct Food, List<FoodProduct> lstFood)
        {
            for (int i = 0; i < lstFood.Count; i++)
            {
                if (lstFood[i].getID() == Food.getID())
                    return 1;
            }
            return 0;
        }

        public double getTotal(ObservableCollection<DetailReceipt> lstdetailReceipt, double total)
        {
            for (int i = 0; i < lstdetailReceipt.Count; i++)
            {
                total += lstdetailReceipt[i].PriceOutput * lstdetailReceipt[i].Quantity;
            }
            return total;
        }

        public double getTotal(ObservableCollection<DetailOrder> lstdetailOrder, double total)
        {
            double discount = 0;
            for (int i = 0; i < lstdetailOrder.Count; i++)
            {
                if (lstdetailOrder[i].Categories == Category.Food)
                    discount = OrderVM.DiscountFood(lstdetailOrder[i].Quantity, lstdetailOrder[i].PriceOutput);
                else if (lstdetailOrder[i].Categories == Category.Electronic)
                    discount = OrderVM.DiscountElectric(lstdetailOrder[i].Quantity, lstdetailOrder[i].PriceOutput);
                else
                    discount = OrderVM.DiscountPorcelain(lstdetailOrder[i].Quantity, lstdetailOrder[i].PriceOutput);
                total += (lstdetailOrder[i].PriceOutput * lstdetailOrder[i].Quantity - discount);
            }
            return total;
        }

        public double getTotal(ObservableCollection<DetailInvoice> lstdetailInvoice, double total)
        {
            for (int i = 0; i < lstdetailInvoice.Count; i++)
            {
                total += lstdetailInvoice[i].PriceOutput * lstdetailInvoice[i].Quantity;
            }
            return total;
        }

        public int getIndex(ObservableCollection<DetailReceipt> lstdetailReceipt)
        {
            for (int i = 0; i < lstdetailReceipt.Count; i++)
            {
                if (lstdetailReceipt[i].Categories == Category.Electronic)
                    return 1;
                else if (lstdetailReceipt[i].Categories == Category.Food)
                    return 2;
                else
                    return 3;
            }
            return -1;
        }

        public int getIndex(ObservableCollection<DetailInvoice> lstdetailInvoice)
        {
            for (int i = 0; i < lstdetailInvoice.Count; i++)
            {
                if (lstdetailInvoice[i].Categories == Category.Electronic)
                    return 1;
                else if (lstdetailInvoice[i].Categories == Category.Food)
                    return 2;
                else
                    return 3;
            }
            return -1;
        }

        public string getId(ObservableCollection<DetailReceipt> lstdetailReceipt, Inventory inventory)
        {
            for (int i = 0; i < lstdetailReceipt.Count; i++)
            {
                if (lstdetailReceipt[i].Name == inventory.Product)
                    return lstdetailReceipt[i].IdProduct;
            }
            return "a";
        }

        public string getId(ObservableCollection<DetailInvoice> lstdetailInvoice, Inventory inventory)
        {
            for (int i = 0; i < lstdetailInvoice.Count; i++)
            {
                if (lstdetailInvoice[i].Name == inventory.Product)
                    return lstdetailInvoice[i].IdProduct;
            }
            return "a";
        }

        public Category getCategory(ObservableCollection<DetailReceipt> lstdetailReceipt, Inventory inventory)
        {
            for (int i = 0; i < lstdetailReceipt.Count; i++)
            {
                if (lstdetailReceipt[i].Name == inventory.Product)
                    return lstdetailReceipt[i].Categories;
            }
            return Category.Electronic;
        }

        public Category getCategory(ObservableCollection<DetailInvoice> lstdetailInvoice, Inventory inventory)
        {
            for (int i = 0; i < lstdetailInvoice.Count; i++)
            {
                if (lstdetailInvoice[i].Name == inventory.Product)
                    return lstdetailInvoice[i].Categories;
            }
            return Category.Electronic;
        }

        public int getIndex(ObservableCollection<DetailReceipt> lstdetailReceipt, Inventory inventory)
        {
            for (int i = 0; i < lstdetailReceipt.Count; i++)
            {
                if (lstdetailReceipt[i].Name == inventory.Product)
                    return i;
            }
            return -1;
        }

        public int getIndex(ObservableCollection<DetailInvoice> lstdetailInvoice, Inventory inventory)
        {
            for (int i = 0; i < lstdetailInvoice.Count; i++)
            {
                if (lstdetailInvoice[i].Name == inventory.Product)
                    return i;
            }
            return -1;
        }

        public int getIndex(ObservableCollection<DetailOrder> lstdetailOrder, Inventory inventory)
        {
            for (int i = 0; i < lstdetailOrder.Count; i++)
            {
                if (lstdetailOrder[i].Name == inventory.Product)
                    return i;
            }
            return -1;
        }

        public int getIndex(DetailInvoice detailInvoice, ObservableCollection<Inventory> inventory)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Product == detailInvoice.Name)
                    return i;
            }
            return -1;
        }

        public int getIndex(DetailOrder detailOrder, ObservableCollection<Inventory> inventory)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].Product == detailOrder.Name)
                    return i;
            }
            return -1;
        }

        public int getIndex(ObservableCollection<Inventory> Receipt, Inventory Invoice)
        {
            for (int i = 0; i < Receipt.Count; i++)
            {
                if (Receipt[i].Product == Invoice.Product)
                    return i;
            }
            return -1;
        }

        public double getquantity(ObservableCollection<DetailOrder> lstdetailOrder, Inventory inventory, double quantity)
        {
            for (int i = 0; i < lstdetailOrder.Count; i++)
            {
                if (lstdetailOrder[i].Name == inventory.Product)
                {
                    quantity += lstdetailOrder[i].Quantity;
                }
            }
            return quantity;
        }

        public int getIndex(ObservableCollection<Inventory> lstInventory, string Product)
        {
            for (int i = 0; i < lstInventory.Count; i++)
            {
                if (lstInventory[i].Product == Product)
                    return i;
            }
            return -1;
        }

        public int getIndex(ObservableCollection<DetailOrder> lstdetailOrder, string Product)
        {
            for (int i = 0; i < lstdetailOrder.Count; i++)
            {
                if (lstdetailOrder[i].Name == Product)
                    return i;
            }
            return -1;
        }

        public double getQuantity(ObservableCollection<DetailOrder> lstdetailOrder, string Product)
        {
            double quantity = 0;
            for (int i = 0; i < lstdetailOrder.Count; i++)
            {
                if (lstdetailOrder[i].Name == Product)
                {
                    quantity += lstdetailOrder[i].Quantity;
                }
            }
            return quantity;
        }

        public int getIndex(DetailInvoice detailInvoice, List<DetailReceipt> lstdetailReceipt)
        {
            for (int i = 0; i < lstdetailReceipt.Count; i++)
            {
                if (lstdetailReceipt[i].Name == detailInvoice.Name)
                    return i;
            }
            return -1;
        }

        public double getPriceInput(ObservableCollection<DetailReceipt> lstdetailReceipt, string name)
        {
            for (int i = 0; i < lstdetailReceipt.Count; i++)
            {
                if (lstdetailReceipt[i].Name == name)
                {
                    return lstdetailReceipt[i].PriceInput;
                }
            }
            return 0;
        }

        public double getProfit(DetailOrder detailOrder, ObservableCollection<DetailReceipt> lstdetailReceipt)
        {
            double profit = 0, revenue = 0, discount = 0, priceinput = 0;

            priceinput = getPriceInput(lstdetailReceipt, detailOrder.Name);
            if (detailOrder.Categories == Category.Porcelain)
                discount = OrderVM.DiscountPorcelain(detailOrder.Quantity, detailOrder.PriceOutput);
            else if (detailOrder.Categories == Category.Electronic)
                discount = OrderVM.DiscountElectric(detailOrder.Quantity, detailOrder.PriceOutput);
            else
                discount = OrderVM.DiscountFood(detailOrder.Quantity, detailOrder.PriceOutput);
            revenue += detailOrder.Quantity * detailOrder.PriceOutput - discount;
            profit += revenue - (detailOrder.Quantity * priceinput);
            revenue = 0;
            return profit;
        }
        #endregion
    }
}
