   M S B A M L   `   `   `  ����E  AMinh_C3_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Minh_C3_B1
Minh_C3_B1  5          Minh_C3_B1.ucDetailOrder   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Minh_C3_B1     5        � 	Resources  5        Minh_C3_B1.ConverterPhay   	Converter��%!   &	          5	   
   5
      5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dtgDetail��5      $	��200��5      $��10q�5      $	��Top=�5         	RowHeight$ 20Q�5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5         AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Id ��6%      Width$ 50 5   )   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5   )   �� *Id+5   )     5      $ Id Order��6%   	 5      �� *	IdOrder+  5      $ 
Id Product��6%   	 5   )   �� *	IdProduct+  5      $
 Name��6%   $	 170 5    )   	 5   )   �� *Name+5    )     5!      $ 	Category ��6%   	 5"   )   �� *
Categories+  5#      $ Price Output��6%   $	 100 5%   )   	 5$   )   �� *PriceOutput+
 �� 	Converter#
 [  5%   )     5&      $ 	Quantity ��6%   	 5'   )   �� *
Quantity+  5(      $ Amount��6%   $	 100 5*   )   	 5)   )   �� *Amount+#
 [  5*   )   5,      5-      5.      