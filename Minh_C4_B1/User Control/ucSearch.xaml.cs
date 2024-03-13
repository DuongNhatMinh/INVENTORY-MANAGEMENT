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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minh_C3_B1
{
    /// <summary>
    /// Interaction logic for ucSearch.xaml
    /// </summary>
    public partial class ucSearch : UserControl
    {
        ucSearchId ucsearchid { get; set; }
        ucSearchDate ucsearchdate { get; set; }
        private int option = 0;
        public ucSearch(int op)
        {
            InitializeComponent();
            cbChoose.Items.Add("Search By Id");
            cbChoose.Items.Add("Search By Date");
            cbChoose.SelectionChanged += CbChoose_SelectionChanged;
            option = op;
        }

        private void CbChoose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stackpanel.Children.Clear();
            if (cbChoose.SelectedIndex == 0)
            {
                ucsearchid = new ucSearchId(option);
                stackpanel.Children.Add(ucsearchid);
            }
            else
            {
                ucsearchdate = new ucSearchDate(option);
                stackpanel.Children.Add(ucsearchdate);
            }
        }
    }
}
