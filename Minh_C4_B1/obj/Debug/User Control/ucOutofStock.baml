   M S B A M L   `   `   `  ����E  AMinh_C3_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Minh_C3_B1
Minh_C3_B1  5          Minh_C3_B1.ucOutofStock   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Minh_C3_B1     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��45 �6   �� 5      $	��250 �6    � ColumnDefinitions 5   
   �� 5      $	��720 �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��View Out of Stock��5      $��Center=�5      �� 5   
   -   5        $��
stackpanel��5      $��1��5      .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgInventory��5      $	��200��5      $��10q�5      $	��Top=�5         	RowHeight$ 20Q�5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5         AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$	 Id ��6)   	   Width$	 50 5"      1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5!      �� *Id+5"        5#      $ Product��6)   $		 170 5$   /   
 6   �� *	Product+6/     5%      $ 	Quantity ��6)   
 5&      �� *
Quantity+5(      5)      5*      5+      