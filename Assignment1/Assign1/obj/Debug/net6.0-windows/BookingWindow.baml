   M S B A M L   `   `   `  ����B  >Assign1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Assign1Assign1  5   	       Assign1.BookingWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Assign1     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      	BookingVM  � DataContext#  [  5	   	    � Title$ BookingWindow��5
   	   $	��550��6   $	��900��6,   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   � $��0��6   $��	50,15,0,0q�6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      6%   �� 5      6%   .+�5      �� $��0��6   $��0��6#   $	��150��63   $
��Left=�6?   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Booking ID��5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextBoxViewMargin$ 1 0 1 0q�5         FloatingScale$
 0.70Q�5       % !MaterialDesignFloatingHintTextBox#��[ 5       $��15(�5!      ��5      �� *	BookingId+ �� UpdateSourceTrigger$ PropertyChanged=�5!      �� 5$      $��0��6   $��1��6$   $
��Left=�64   $	��150��6O   $ Customer ID��5%       �� 
IsEditable$
 True��5'       & "MaterialDesignFloatingHintComboBox#��[ 5(      $��15(�5)      ��5*      �� *CustomerIds+	 �� SelectedItem	 5+      �� *
CustomerId+$ PropertyChanged=�
 �� Text
 5,      �� *
CustomerId+$ PropertyChanged=��� 5/      $��2��6   $��0��6$   $
��Left=�64   $	��150��6O   $��0,10,0,0q�6[   $ Room ID��50      $
 True��52      #��[ 53      $��15(�54      ��55      �� *	RoomIds+	 56      �� *RoomId+$ PropertyChanged=�
 57      �� *RoomId+$ PropertyChanged=�5:      (  "System.Windows.Controls.DatePicker  5<      $��1��6   $��0��6&   $
��Left=�66   $��0,10,0,0q�6Q   $	��150��5=      $ Checkin Date��5>       ( $MaterialDesignFloatingHintDatePicker#��[ 5?      $��15(�6Y      SelectedDate 5@      �� *CheckInDate+$ PropertyChanged=�  5A      $��1��6   $��1��6&   $
��Left=�66   $��0,10,0,0q�6Q   $	��150��5B      $ Checkout Date��5C      #��[ 5D      $��15(�6Y    5E      �� *CheckOutDate+$ PropertyChanged=��� 5G      $��2��6   $��1��6#   $	��150��63   $
��Left=�6?   $��0,10,0,0q�6Z   $ Total Price��5H      $ 1 0 1 0q�5I      $
 0.70Q�5J      #��[ 5L      $��15(�5M      ${�False��6!   ��5K      �� *
TotalPrice+$ PropertyChanged=�5M   !   5N      #  MaterialDesignThemes.Wpf.Card  5O   
   $��1��6   $��0,10,0,0q�6+   .��5P      � .+�5Q      �� $��Order��6;   $��5q�6K   $	��100��6V   ��6   �� *CreateCommand+6d   �� 5R      $��Update��6;   $��5q�6L   $	��100��6W   ��6   �� *UpdateCommand+6e   �� 5S      -   5        $��Cancel��5S   ;   $��5q�6L   $	��100��6W   ��6   �� *CancelCommand+6z   �� 5T      $��Refresh��6<   $��5q�6N   $	��100��6Y   ��6   �� *RefreshCommand+6g   �� 5U      $��Search��6C   $��5q�6T   $	��100��6_   ��6   �� *SearchCustomerCommand+6m   5V      5W      � 5X   
   $��2��6   .+�5Y      �� -   5         ��Name$ lvCustomers��5Y      $��Center=�6,   $	��Top=�6I   $	��273��6�   ��6a   �� *List+	 6~   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5Z      �� 5[      .P�5\      �� $��
Booking ID��6)    �� Width$	 130��6=    �� DisplayMemberBinding 6I   ��  �� Path$ 	BookingId��� 5]      $��Room ID��6)   $	 130��6:    6F   �� $ RoomId��� 5^      $��Customer ID��6)   $	 138��6>    6J   �� $ 
CustomerId��� 5_      $��Checkin Date��6)   $	 150��6?    6K   �� $ CheckInDate� �� StringFormat$ {0:dd-MM-yyyy}���� 5`      $��Checkout Date��6)   $	 150��6@    6L   �� $ CheckOutDate�$ {0:dd-MM-yyyy}���� 5a      $��Total Price��6)   $	 150��6>    6J   �� $ 
TotalPrice�5b      5d      5e      5g      5h      