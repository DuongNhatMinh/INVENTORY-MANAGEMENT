   M S B A M L   `   `   `  ����E  AMinh_C3_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Minh_C3_B1
Minh_C3_B1  5          Minh_C3_B1.ucViewOrder   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Minh_C3_B1     5        � 	Resources  5        Minh_C3_B1.ConverterPhay   	Converter��%!   &	          5	   
   5
      5      .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $	��430 �6    � ColumnDefinitions 5   
   �� 5      $	��720 �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��View List Order��5      $��25(�6*   $��Center=�5      
����ح�5      �� 5   
   -   5        $��
stackpanel��5      $��1��5      .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dtgOrder��5      $	��400��5      $	��700��6%   $
��Left=�5      $��
10,10,0,10q�5      $	��Top=�5         	RowHeight$ 20Q�5          ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5!         AutoGenerateColumns .     
IsReadOnly .    Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$	 Id ��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5&   %   �� *Id+  5'      $ 	User Name��6)   
   Width$	
 170 5)   %   	 5(   %   �� *
Username+5)   %     5*      $ Quantity��6)   $	
 100 5,   %   	 5+   %   �� *
Quantity+5,   %     5-      $ Amount��6)   $	
 100 5/   %   	 5.   %   �� *Total+ �� 	Converter# [  5/   %      RowDetailsTemplate 51      �� 52      .R�53        $	��200��6#   $��10q�54   #   $	��Top=�55   #   $ 20Q�57   #   $ 70 58   #    .   . ��56   #   �� *lstdetailOrder+ 5;        5<   "   $	 Id ��65   $
 50 5>   5   	 5=   5   �� *Id+5>   5     5?   "   $ 
Id Product��65   	 5@   5   �� *	IdProduct+  5A   "   $
 Name��65   $	
 170 5C   5   	 5B   5   �� *Name+5C   5     5D   "   $ 	Category ��65   	 5E   5   �� *
Categories+  5F   "   $ Price Output��65   $	
 100 5H   5   	 5G   5   �� *PriceOutput+# [  5H   5     5I   "   $ 	Quantity ��65   	 5J   5   �� *
Quantity+  5K   "   $ Amount��65   $	
 100 5M   5   	 5L   5   �� *Amount+# [  5M   5   5O      5P      5R      5S      5T      5U      