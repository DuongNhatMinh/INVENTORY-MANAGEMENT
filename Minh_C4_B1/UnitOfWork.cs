using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_C3_B1
{
    class UnitOfWork
    {
        public RepositoryBase<Customer> customer;
        private CustomerViewModel customerVM = new CustomerViewModel();
        public RepositoryBase<Inventory> inventory;
        private InventoryViewModel inventoryVM = new InventoryViewModel();
        public RepositoryBase<Account> acc = new RepositoryBase<Account>();
        private AccountViewModel accVM = new AccountViewModel();
        public RepositoryBase<ElectronicProduct> electric = new RepositoryBase<ElectronicProduct>();
        private ElectricViewModel electricVM = new ElectricViewModel();
        public RepositoryBase<PorcelainProduct> porcelain = new RepositoryBase<PorcelainProduct>();
        private PorcelainViewModel porcelainVM = new PorcelainViewModel();
        public RepositoryBase<FoodProduct> food = new RepositoryBase<FoodProduct>();
        private FoodViewModel foodVM = new FoodViewModel();
        public RepositoryBase<Order> order = new RepositoryBase<Order>();
        private OrderViewModel orderVM = new OrderViewModel();
        public RepositoryBase<DetailOrder> detailOrder = new RepositoryBase<DetailOrder>();
        private DetailOrderViewModel detailOrderVM = new DetailOrderViewModel();
        public RepositoryBase<Receipt> receipt = new RepositoryBase<Receipt>();
        private ReceiptViewModel receiptVM = new ReceiptViewModel();
        public RepositoryBase<DetailReceipt> detailReceipt = new RepositoryBase<DetailReceipt>();
        private DetailReceiptViewModel detailRreceiptVM = new DetailReceiptViewModel();
        public RepositoryBase<Invoice> invoice = new RepositoryBase<Invoice>();
        private InvoiceViewModel invoiceVM = new InvoiceViewModel();
        public RepositoryBase<DetailInvoice> detailInvoice = new RepositoryBase<DetailInvoice>();
        private DetailInvoiceViewModel detaiInvoiceVM = new DetailInvoiceViewModel();

        public RepositoryBase<Account> GetRepositoryAcc
        {
            get
            {
                if (this.acc == null)
                    this.acc = new RepositoryBase<Account>();
                return acc;
            }
        }

        public RepositoryBase<Customer> GetRepositoryCustomer
        {
            get
            {
                if (this.customer == null)
                    this.customer = new RepositoryBase<Customer>();
                return customer;
            }
        }

        public RepositoryBase<Inventory> GetRepositoryInventory
        {
            get
            {
                if (this.inventory == null)
                    this.inventory = new RepositoryBase<Inventory>();
                return inventory;
            }
        }

        public RepositoryBase<ElectronicProduct> GetRepositoryElectric
        {
            get
            {
                if (this.electric == null)
                    this.electric = new RepositoryBase<ElectronicProduct>();
                return electric;
            }
        }

        public RepositoryBase<PorcelainProduct> GetRepositoryPorcelain
        {
            get
            {
                if (this.porcelain == null)
                    this.porcelain = new RepositoryBase<PorcelainProduct>();
                return porcelain;
            }
        }

        public RepositoryBase<FoodProduct> GetRepositoryFood
        {
            get
            {
                if (this.food == null)
                    this.food = new RepositoryBase<FoodProduct>();
                return food;
            }
        }

        public RepositoryBase<Order> GetRepositoryOrder
        {
            get
            {
                if (this.order == null)
                    this.order = new RepositoryBase<Order>();
                return order;
            }
        }

        public RepositoryBase<Receipt> GetRepositoryReceipt
        {
            get
            {
                if (this.receipt == null)
                    this.receipt = new RepositoryBase<Receipt>();
                return receipt;
            }
        }

        public RepositoryBase<Invoice> GetRepositoryInvoice
        {
            get
            {
                if (this.invoice == null)
                    this.invoice = new RepositoryBase<Invoice>();
                return invoice;
            }
        }
        public RepositoryBase<Account> GetRepositoryAccount
        {
            get
            {
                if (this.acc == null)
                    this.acc = new RepositoryBase<Account>();
                return acc;
            }
        }

        public UnitOfWork()
        {
            acc = new RepositoryBase<Account>();
            customer = new RepositoryBase<Customer>();
            inventory = new RepositoryBase<Inventory>();
            porcelain = new RepositoryBase<PorcelainProduct>();
            electric = new RepositoryBase<ElectronicProduct>();
            food = new RepositoryBase<FoodProduct>();
            receipt = new RepositoryBase<Receipt>();
            invoice = new RepositoryBase<Invoice>();
            order = new RepositoryBase<Order>();
            string xPath = "/Products/Product";

            // Get data;
            customer.BulkInsert(customerVM.getList("/Customers/Customer"));
            //inventory.BulkInsert(inventoryVM.getList("Movie"));
            acc.BulkInsert(accVM.getList("/Accounts/Account"));
            electric.BulkInsert(electricVM.getList(xPath));
            porcelain.BulkInsert(porcelainVM.getList(xPath));
            food.BulkInsert(foodVM.getList(xPath));
            order.BulkInsert(orderVM.getList2("/Orders/Order"));
        }
    }
}
