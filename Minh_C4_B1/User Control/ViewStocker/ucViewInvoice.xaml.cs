using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minh_C3_B1
{
    /// <summary>
    /// Interaction logic for ucViewInvoice.xaml
    /// </summary>
    public partial class ucViewInvoice : UserControl
    {
        private Invoice invoice = new Invoice();
        private InvoiceViewModel InvoiceVM = new InvoiceViewModel();
        private ObservableCollection<Invoice> lstInvoice = new ObservableCollection<Invoice>();
        private ObservableCollection<DetailInvoice> lstdetailInvoice = new ObservableCollection<DetailInvoice>();
        private ObservableCollection<DetailInvoice> lstdetailInvoiceTemp { get; set; }
        private ObservableCollection<Invoice> lstInvoicetemp { get; set; }
        private DetailInvoiceViewModel detailInvoiceVM = new DetailInvoiceViewModel();

        public ucViewInvoice()

        {
            InitializeComponent();
            lstInvoice = InvoiceVM.getList("/Invoices/Invoice");
            lstdetailInvoice = detailInvoiceVM.getListByID("/DetailInvoices/DetailInvoice");
            DisplayDetail();
        }

        public void DisplayDetail()
        {
            lstInvoicetemp = new ObservableCollection<Invoice>();
            for (int j = 0; j < lstInvoice.Count; j++)
            {
                lstdetailInvoiceTemp = new ObservableCollection<DetailInvoice>();
                for (int i = 0; i < lstdetailInvoice.Count; i++)
                {
                    if (lstInvoice[j].Id == lstdetailInvoice[i].IdInvoice)
                    {
                        lstdetailInvoiceTemp.Add(lstdetailInvoice[i]);
                        invoice = new Invoice(lstInvoice[j].Id, lstInvoice[j].Username, lstInvoice[j].Quantity, lstInvoice[j].Total, lstInvoice[j].CreateAt,
                            lstdetailInvoiceTemp);
                    }
                }
                lstInvoicetemp.Add(invoice);
            }
            dtgInvoice.ItemsSource = lstInvoicetemp;
        }
    }
}
