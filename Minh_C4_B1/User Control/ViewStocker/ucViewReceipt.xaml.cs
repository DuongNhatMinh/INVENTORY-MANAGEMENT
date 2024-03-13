using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// Interaction logic for ucViewReceipt.xaml
    /// </summary>
    public partial class ucViewReceipt : UserControl
    {
        private ReceiptViewModel receiptVM = new ReceiptViewModel();
        private DetailReceiptViewModel detailReceiptVM = new DetailReceiptViewModel();
        private Receipt receipt = new Receipt();
        private DetailReceipt detailreceipt = new DetailReceipt();
        private ObservableCollection<Receipt> lstReceipt = new ObservableCollection<Receipt>();
        private ObservableCollection<DetailReceipt> lstdetailReceipt = new ObservableCollection<DetailReceipt>();
        private ObservableCollection<DetailReceipt> lstdetailReceiptTemp { get; set; }
        private ObservableCollection<Receipt> lstReceipttemp { get; set; }

        public ucViewReceipt()
        {
            InitializeComponent();
            lstdetailReceipt = detailReceiptVM.getListByID("/DetailReceipts/DetailReceipt");
            lstReceipt = receiptVM.getList("/Receipts/Receipt");
            DisplayDetail();
        }

        public void DisplayDetail()
        {
            lstReceipttemp = new ObservableCollection<Receipt>();
            for (int j = 0; j < lstReceipt.Count; j++)
            {
                double total = 0;
                lstdetailReceiptTemp = new ObservableCollection<DetailReceipt>();
                for (int i = 0; i < lstdetailReceipt.Count; i++)
                {
                    if (lstReceipt[j].Id == lstdetailReceipt[i].IdReceipt)
                    {
                        detailreceipt = new DetailReceipt(lstdetailReceipt[i].Id, lstdetailReceipt[i].IdReceipt, lstdetailReceipt[i].IdProduct,
                            lstdetailReceipt[i].Name, lstdetailReceipt[i].Categories, lstdetailReceipt[i].PriceInput, lstdetailReceipt[i].PriceOutput,
                            lstdetailReceipt[i].Quantity, (lstdetailReceipt[i].PriceInput * lstdetailReceipt[i].Quantity));
                        total += (lstdetailReceipt[i].PriceInput * lstdetailReceipt[i].Quantity);
                        lstdetailReceiptTemp.Add(detailreceipt);
                    }
                    receipt = new Receipt(lstReceipt[j].Id, lstReceipt[j].Username, lstReceipt[j].Quantity, total, lstReceipt[j].CreateAt,
                           lstdetailReceiptTemp);
                }
                lstReceipttemp.Add(receipt);
            }
            dtgReceipt.ItemsSource = lstReceipttemp;
        }
    }
}
