using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Minh_C3_B1
{
    class ConverterPhay : IValueConverter
    {
        // Chuyển đổi giá trị 0 - Windows Authentication thành false 
        // 1- sẽ trở thành true
        // Dùng cho combobox Authentication và Textbox Username / Pass
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double item = (double)value;
            string str;
            var Culture = new CultureInfo("en-US");
            Culture.NumberFormat.NumberDecimalSeparator = ",";
            return str = item.ToString("N0", Culture);
            //return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
