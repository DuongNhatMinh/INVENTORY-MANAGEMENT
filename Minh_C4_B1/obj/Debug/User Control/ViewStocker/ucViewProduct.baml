   M S B A M L   `   `   `  ����E  AMinh_C3_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Minh_C3_B1
Minh_C3_B1  5          Minh_C3_B1.ucViewProduct   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Minh_C3_B1     5        � 	Resources  5        Minh_C3_B1.ConverterPhay   ConverterPhay��%!   &	          5	   
   5
      5      .��5      � $	��230��6   $	��600��6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��45 �6   �� 5      $	��400 �6   .+�5   
   ��  �� CornerRadius$ 15��6   ._�5      �� $��0��6   $��25(�5      $��Center=�5      .��65   	Product5      5      �� 5   
   $��1��6   $	��800��5      $��10,0,0,0q�5      .+�5      �� $ 15��6   
�������
���   �$��1q�5       $	��150��5!      $��45��5"      $
��Left=�5#      ._�5$      �� -   5        $��btnElec��5*      $��0q�5$      $	��100��5%      $��35��5&      
�������$��
Electronic��5(      $��15(�5)        menuButtonStyle#��[ 5,      5-      5.      �� 50      $ 15��6   
�������
���   �$��1q�53      $	��150��54      $��45��55      $��20,-45,360,0q�56      ._�57      �� -   5        $��btnPorcelain��5<      $	��100��57      $��35��6%   $��	Porcelain��58      
�������$��0q�5:      $��15(�5;      #��[ 5>      5?      5@      �� 5B      $ 15��6   
�������
���   �$��1q�5E      $	��150��5F      $��45��5G      $��-30,-45,0,0q�5H      ._�5I      �� -   5        $��btnFood��5M      $	��100��5I      $��35��6%   
�������$
��Food��5K      $��15(�5L      $��0q�5N      #��[ 5P      5Q      5R      5S      &   System.Windows.Controls.DataGrid  5U   
   -   5        $��
dtgProduct��5U      $	��120��5V      $
��Left=�5W      $��
10,10,0,10q�5X      $	��Top=�5Y      $	��570��5Z      $��2��5[         	RowHeight$ 20Q�5\         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5]         AutoGenerateColumns .     
IsReadOnly .    Columns 5`      0  *System.Windows.Controls.DataGridTextColumn  5a      ,  &System.Windows.Controls.DataGridColumn   Header$	 Id ��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5b   %   �� *Id+  5c      $
 Name��6%   
   Width$	
 170 5e   %   	 5d   %   �� *Name+5e   %     5f      $ Producer��6%   $	
 100 5h   %   	 5g   %   �� *
Producer+5h   %     5i      $ Price Input��6%   $	
 100 5k   %   	 5j   %   �� *
PriceInput+ �� 	Converter# [  5k   %     5l      $ Price Output��6%   $	
 100 5n   %   	 5m   %   �� *PriceOutput+# [  5n   %   5p      5q      5r      