﻿using System;
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
    /// Interaction logic for frmStocker.xaml
    /// </summary>
    public partial class frmStocker : Window
    {
        frmLogin frmlogin { get; set; }
        ucViewProduct ViewProduct { get; set; }
        DisplayPhieu ucDisplay { get; set; }
        ucCreateReceipt uccreateReceipt { get; set; }
        uccreateInvoice ucCreateInvoice { get; set; }
        ucChangePrice ucchangePrice { get; set; }
        ucDisplayExp ucdisplayExp { get; set; }
        ucViewReceipt ucviewReceipt { get; set; }
        ucViewInvoice ucviewInvoice { get; set; }
        ucViewInventory ucviewInven { get; set; }
        ucInventoryView ucInvenView { get; set; }
        ucOutofStock ucOutofStock { get; set; }
        ucHome uchome { get; set; }
        ucSearch ucsearch { get; set; }
        ucStatistical ucthongke { get; set; }
        private string Name = string.Empty;

        public frmStocker(string name)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Name = name;
            string str = string.Format("Wellcome {0}", Name);
            lbTrang.Content = str;
        }

        public void SelectedUserControl(int option)
        {
            stackPanel.Children.Clear();
            switch (option)
            {
                case 1:
                    ViewProduct = new ucViewProduct();
                    stackPanel.Children.Add(ViewProduct);
                    break;
                case 2:
                    ucDisplay = new DisplayPhieu(Name, 1);
                    stackPanel.Children.Add(ucDisplay);
                    break;
                case 3:
                    this.Visibility = Visibility.Hidden;
                    frmlogin = new frmLogin();
                    frmlogin.Show();
                    break;
                case 4:
                    ucchangePrice = new ucChangePrice();
                    stackPanel.Children.Add(ucchangePrice);
                    break;
                case 5:
                    ucDisplay = new DisplayPhieu(Name, 2);
                    stackPanel.Children.Add(ucDisplay);
                    break;
                case 6:
                    ucdisplayExp = new ucDisplayExp();
                    stackPanel.Children.Add(ucdisplayExp);
                    break;
                case 7:
                    ucviewReceipt = new ucViewReceipt();
                    stackPanel.Children.Add(ucviewReceipt);
                    break;
                case 8:
                    ucviewInvoice = new ucViewInvoice();
                    stackPanel.Children.Add(ucviewInvoice);
                    break;
                case 9:
                    ucviewInven = new ucViewInventory(1);
                    stackPanel.Children.Add(ucviewInven);
                    break;
                case 10:
                    ucviewInven = new ucViewInventory(2);
                    stackPanel.Children.Add(ucviewInven);
                    break;
                case 11:
                    ucInvenView = new ucInventoryView();
                    stackPanel.Children.Add(ucInvenView);
                    break;
                case 12:
                    ucOutofStock = new ucOutofStock(1);
                    stackPanel.Children.Add(ucOutofStock);
                    break;
                case 13:
                    uchome = new ucHome();
                    stackPanel.Children.Add(uchome);
                    break;
                case 14:
                    ucsearch = new ucSearch(1);
                    ucsearch.lbTrang.Content = "Search Detail Receipt";
                    stackPanel.Children.Add(ucsearch);
                    break;
                case 15:
                    ucsearch = new ucSearch(2);
                    ucsearch.lbTrang.Content = "Search Detail Invoice";
                    stackPanel.Children.Add(ucsearch);
                    break;
                case 16:
                    ucthongke = new ucStatistical();
                    stackPanel.Children.Add(ucthongke);
                    break;
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(3);
        }

        private void tvproduct_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(1);
        }

        private void createReceipt_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(2);
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(4);
        }

        private void createInvoice_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(5);
        }

        private void TreeViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(6);
        }

        private void viewlistreceipt_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(7);
        }

        private void viewInvoice_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(8);
        }

        private void Invenreceipt_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(9);
        }

        private void InvenInvoice_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(10);
        }

        private void Inventory_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(11);
        }

        private void outofstock_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(12);
        }

        private void tvHome_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(13);
        }

        private void SearchReceipt_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(14);
        }

        private void SearchInvoice_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(15);
        }

        private void statistical_Selected(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(16);
        }
    }
}
