   M S B A M L   `   `   `  ����B  >Assign1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Assign1Assign1  5   	   7 clr-namespace:Assign1.ValidationAssign1.Validation  5   	       Assign1.CustomerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Assign1     5   	   7
validation clr-namespace:Assign1.Validation     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      
CustomerVM  � DataContext#  [  5
   	    � Title$ Customer Management��5   	   $	��550��6%   $	��800��62   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   � $��0��6   $��	50,15,0,0q�6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      6%   �� 5      6%   .+�5      �� $��0��6   $��0��6#   $	��150��63   $
��Left=�6?   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Customer ID��5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextBoxViewMargin$ 1 0 1 0q�5         FloatingScale$
 0.70Q�5        % !MaterialDesignFloatingHintTextBox#��[ 5"      $��15(�5#      ��5!      �� *
CustomerId+ �� UpdateSourceTrigger$ PropertyChanged=�5#      �� 5$      $��1��6   $��0��6#   $	��150��63   $
��Left=�6?   $��0,10,0,0q�6Z   $ Customer Name��5%      $ 1 0 1 0q�5&      $
 0.70Q�5'      #��[ 5)      $��15(�5*      ��5(      �� *Name+5*      �� 5+      $��1��6   $��1��6#   $	��150��63   $
��Left=�6?   $��0,10,0,0q�6Z   $ Phone��5,      $ 1 0 1 0q�5-      $
 0.70Q�5.      #��[ 50      $��15(�51      .��6"   ��52      �� 53       �� Path$ PhoneNumber�6   $ PropertyChanged=�61   	 �� ValidatesOnDataErrors$
	 True��6W   
 �� ValidationRules
 54      .   (Assign1.Validation.NumericValidationRule  55      57      .��58       59      �� 5;      $��2��6   $��0��6#   $	��150��63   $
��Left=�6?   $��0,10,0,0q�6Z   $ Address��5<      $ 1 0 1 0q�5=      $
 0.70Q�5>      #��[ 5@      $��15(�5A      ��5?      �� *	Address+5A      �� 5B      $��2��6   $��1��6#   $	��150��63   $
��Left=�6?   $��0,10,0,0q�6Z   $ Email��5C      $ 1 0 1 0q�5D      $
 0.70Q�5E      #��[ 5G      $��15(�5H      ��5F      �� *Email+5H      5I      #  MaterialDesignThemes.Wpf.Card  5J   
   $��1��6   $��0,10,0,0q�6+   .��5K      � .+�5L      �� $��Register��6E   $��5q�6X   $	��100��6c   ��6   �� *RegisterCustomerCommand+6q   �� 5M      $��Update��6C   $��5q�6T   $	��100��6_   ��6   �� *UpdateCustomerCommand+6m   �� 5N      $��Delete��6C   $��5q�6T   $	��100��6_   ��6   �� *DeleteCustomerCommand+6m   �� 5O      $��Refresh��6<   $��5q�6N   $	��100��6Y   ��6   �� *RefreshCommand+6g   �� 5P      $��Search��6C   $��5q�6T   $	��100��6_   ��6   �� *SearchCustomerCommand+6m   5Q      5R      � 5S   
   $��2��6   .+�5T      �� -   5         ��Name$ lvCustomers��5T      $��Center=�6,   $	��Top=�6I   $	��273��6�   ��6a   �� *List+ �� SelectedItem 6~   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5U      �� 5V      .P�5W      �� $��Customer ID��6)    �� Width$	 140��6>    �� DisplayMemberBinding 6J   �� $ 
CustomerId��� 5X      $
��Name��6)   $	 130��67    6C   �� $
 Name��� 5Y      $��Phone��6)   $	 100��68    6D   �� $ PhoneNumber��� 5Z      $��Email��6)   $	 150��68    6D   �� $ Email��� 5[      $��Address��6)   $	 150��6:    6F   �� $ Address�5\      5^      5_      5a      5b      