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
    /// Interaction logic for ucDetailReceipt.xaml
    /// </summary>
    public partial class ucDetailInvoice : UserControl
    {
        private ObservableCollection<DetailInvoice> lstdetailInvoiceTemp { get; set; }

        public ucDetailInvoice(object item)
        {
            InitializeComponent();
            lstdetailInvoiceTemp = item as ObservableCollection<DetailInvoice>;
            dtgDetail.ItemsSource = lstdetailInvoiceTemp;
        }
    }
}
