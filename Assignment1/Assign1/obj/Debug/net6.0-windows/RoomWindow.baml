   M S B A M L   `   `   `  ����B  >Assign1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Assign1Assign1  5   	   7 clr-namespace:Assign1.ValidationAssign1.Validation  5   	       Assign1.RoomWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Assign1     5   	   7
validation clr-namespace:Assign1.Validation     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	    
  RoomVM  � DataContext#  [  5
   	    � Title$ Room Management��5   	   $	��550��6!   $	��800��6.   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   .+�5   
   � $��0��6   $��	50,15,0,0q�6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      6%   �� 5      6%   .+�5      �� $��0��6   $��0��6#   $	��150��63   $
��Left=�6?   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Room Id��5      .  (MaterialDesignThemes.Wpf.TextFieldAssist   TextBoxViewMargin$ 1 0 1 0q�5         FloatingScale$
 0.70Q�5       % !MaterialDesignFloatingHintTextBox#��[ 5       $��15(�5!      .��6"   ��5"      �� 5#       �� Path$ RoomId�6    �� UpdateSourceTrigger$ PropertyChanged=�6,   	 �� ValidatesOnDataErrors$
	 True��6R   
 �� ValidationRules
 5$      .   (Assign1.Validation.NumericValidationRule  5%      5'      .��5(       5)      �� 5*      $��0��6   $��1��6#   $	��150��63   $
��Left=�6?   $ 	Room Type��5+      $ 1 0 1 0q�5,      $
 0.70Q�5-      #��[ 5/      $��15(�50      ��5.      �� *
RoomType+$ PropertyChanged=�50      �� 52      $��1��6   $��0��6#   $	��150��63   $
��Left=�6?   $��0,10,0,0q�6Z   $ Status��53      $ 1 0 1 0q�54      $
 0.70Q�55      #��[ 57      $��15(�58      ��56      �� *Status+$ PropertyChanged=�58      �� 59      $��1��6   $��1��6#   $	��150��63   $
��Left=�6?   $��0,10,0,0q�6Z   $ Price��5:      $ 1 0 1 0q�5;      $
 0.70Q�5<      #��[ 5=      $��15(�5>      .��6"   ��5?      �� 5@      $ Price�6   $ PropertyChanged=�6+   $
	 True��6Q   
 5A      -   'Assign1.Validation.DoubleValidationRule  5B      5D      .��5E       5F      5G      #  MaterialDesignThemes.Wpf.Card  5H   
   $��1��6   $��0,10,0,0q�6+   .��5I      � .+�5J      �� $	��Add��68   $��5q�6F   $	��100��6Q   ��6   �� *
AddCommand+6_   �� 5K      $��Update��6;   $��5q�6L   $	��100��6W   ��6   �� *UpdateCommand+6e   �� 5L      $��Delete��6;   $��5q�6L   $	��100��6W   ��6   �� *DeleteCommand+6e   �� 5M      $��Refresh��6<   $��5q�6N   $	��100��6Y   ��6   �� *RefreshCommand+6g   5O      5P      � 5Q   
   $��2��6   $��0,10,0,0q�6   .+�5R      � .+�5S      �� $��0��6   $��1��6'   $	��150��67   $
��Left=�6C   $��5q�6^   $
 Type��5T      $ 1 0 1 0q�5U      $
 0.70Q�5V      #��[ 5X      $��15(�5Y      ��5W      �� *
SearchType+$ PropertyChanged=�5Y      �� 5Z      $��0��6   $��1��6'   $	��150��67   $
��Left=�6C   $��10,5,5,5q�6^   $ Status��5[      $ 1 0 1 0q�5\      $
 0.70Q�5]      #��[ 5_      $��15(�5`      ��5^      �� *SearchStatus+$ PropertyChanged=�5`      �� 5a      $��1��6   $��1��6'   $	��150��67   $
��Left=�6C   $��5q�6^   $ 	FromPrice��5b      $ 1 0 1 0q�5c      $
 0.70Q�5d      #��[ 5e      $��15(�5f      .��6"   ��5g      �� 5h      $ 	FromPrice�6"   $ PropertyChanged=�63   $
	 True��6Y   
 5i        5j   "   5l      .��5m   $   5n      �� 5o      $��1��6   $��1��6'   $	��150��67   $
��Left=�6C   $��10,5,5,5q�6^   $ ToPrice��5p      $ 1 0 1 0q�5q      $
 0.70Q�5r      #��[ 5s      $��15(�5t      .��6"   ��5u      �� 5v      $ ToPrice�6"   $ PropertyChanged=�61   $
	 True��6W   
 5w        5x   "   5z      .��5{   $   5|      �� 5}      $��Search��6;   $��5q�6L   $	��100��6W   ��6   �� *SearchCommand+6e   5~      5      � 5�   
   $��3��6   $��0,10,0,0q�6   .+�5�      �� -   5         ��Name$ lvCustomers��5�      $��Center=�6,   $	��Top=�6I   $	��273��6�   ��6a   �� *List+ �� SelectedItem 6~   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5�      �� 5�      .P�5�      �� $��Room ID��6)    �� Width$	 140��6:    �� DisplayMemberBinding 6F   �� $ RoomId��� 5�      $
��Type��6)   $	 130��67    6C   �� $ RoomType��� 5�      $��Status��6)   $	 100��69    6E   �� $ Status��� 5�      $��Price��6)   $	 150��68    6D   �� $ Price�5�      5�      5�      5�      5�      