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
    /// Interaction logic for ucDisplayExp.xaml
    /// </summary>
    public partial class ucDisplayExp : UserControl
    {
        private List<FoodProduct> lstFoodExp = new List<FoodProduct>();
        private FoodViewModel foodVM = new FoodViewModel();

        public ucDisplayExp()
        {
            InitializeComponent();
            OutputExp();
        }

        public void OutputExp()
        {
            lstFoodExp = foodVM.getItemEXp("/ExpDates/ExpDate");
            dtgProductExp.ItemsSource = lstFoodExp;
        }
    }
}
