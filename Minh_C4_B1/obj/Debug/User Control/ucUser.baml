   M S B A M L   `   `   `  ����E  AMinh_C3_B1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Minh_C3_B1
Minh_C3_B1  5          Minh_C3_B1.ucUser   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Minh_C3_B1     5        � 	Resources  5      (   "Minh_C3_B1.StatusToStringConverter   statusToStringConverter��%   &	          5	   
   6(   5
      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��30 �6   �� 5      $	��245 �6   .+�5   
   �� $��0��6   .+�5      �� 
�������$��Center=�5      .��68   Manage User5      5      �� 5   
   $��1��6   $
��Left=�5      .+�5      �� -   5        $��btnAdd��5       
����� �$	��Add��5      $��50��5      $��30��5      $��10,0,0,0q�5      5!      5"      &   System.Windows.Controls.DataGrid  5#   
   -   5        $��
dtgAccount��5#      $	��210��5$      $
��Left=�5%      $��
10,10,0,10q�5&      $	��Top=�5'      $	��410��5(      $��2��5)         	RowHeight$ 30Q�5*         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 65 5+         AutoGenerateColumns .     
IsReadOnly .  �� DisplayMemberPath$ UserName��5.         Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ 	UserName ��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 51   %   �� *
UserName+
 �� UpdateSourceTrigger$
 PropertyChanged=�  52      $ Password��6%   	 53   %   �� *
Password+$
 PropertyChanged=�  54      $ Status��6%   	 55   &   �� *Status+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  56      $
 Edit��6)      
IsReadOnly .    Width$ 50 58   )      CellTemplate 59      �� 5:      .R�5;      �� $��btnEdit��5<   %   -   5        $
��Edit��5;   %   
����� �5>   %   5?      5A        5C      $
 Lock��6)    . $ 50 5E   )    5F      �� 5G      .R�5H      �� $��	btnDelete��5I   %   -   5        $
��Lock��5H   %   
����� �5K   %   5L      5N        5P      $ UnLock��6)    . $ 50 5R   )    5S      �� 5T      .R�5U      �� $��	btnUnLock��5V   %   -   5        $��UnLock��5U   %   
����� �5X   %   5Y      5[      5^      5_      5`      