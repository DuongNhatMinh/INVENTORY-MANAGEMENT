using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Minh_C3_B1
{
    /// <summary>
    /// Interaction logic for frmBill.xaml
    /// </summary>
    public partial class frmBill : Window
    {
        public ucBills ucbill { get; set; }
        object valuetemp, value2temp, value3temp;
        public int check = 0;

        public frmBill(object Value, object value2, object value3, int op)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            valuetemp = Value;
            value2temp = value2;
            value3temp = value3;
            SelectedUserControl(op);
        }

        public void SelectedUserControl(int option)
        {
            stackpanel.Children.Clear();
            switch (option)
            {
                case 1:
                    ucbill = new ucBills(valuetemp, value2temp, value3temp);
                    stackpanel.Children.Add(ucbill);
                    break;
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            check = 1;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            check = 2;
        }
    }
}
