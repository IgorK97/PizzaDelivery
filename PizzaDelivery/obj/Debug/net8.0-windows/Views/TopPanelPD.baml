   M S B A M L   `   `   `  ����H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  5      O,clr-namespace:PizzaDelivery.State.NavigatorsPizzaDelivery.State.Navigators  5      $    PizzaDelivery.Views.TopPanelPD   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PizzaDelivery.Views     5      <nav,clr-namespace:PizzaDelivery.State.Navigators     5      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6    �� 
IsReadOnly$
 True��6   $��Пиццерия��61   $��30(�6A   $
��Bold"�6O   
���  ��$��10q�6r   $
��Left=�6   � 5   
   $��1��6   ���	#FFEE3B3B$��80��63   .+�5      �  � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      $��* �6'   �� 5      $
��auto �6'   �� 5      $
��auto �6'   �� 5      $
��auto �6'   .+�5'      �� $��0��6   $��80��6)   $��10q�64   
�������$
��Left=�6S   -   'PizzaDelivery.State.Navigators.ViewType   Shop#��Z 5)      ��5(      �� *UpdateCurrentViewModelCommand+.��5+      �� $%��/ImagesForProject/pizzaicon.png��6   ��5,      �� 5-       �� 
TargetType" ��6     �� Triggers 5.      �� 5/   "    �� Binding 6.   �� *
IsClient+ �� Value	 false6K   .a�50   &   ��  �� Property � y�	 �� Value$	 	Collapsed=�6C   51   #   �� 52   "    6.   �� *
IsClient+ true6K   .a�53   &   ��  � y�$	 Visible=�6C   54   #   56      58      �� 59      $��3��6   $��80��6)   $��10q�64   
�������$��Right=�6S   ��5:      �� *UpdateCurrentViewModelCommand+.��5;      �� ��5<      �� 5=      " ��6$    5>   "   �� 5?   &    62   �� *
IsClient+ true6O   .a�5@   *   ��  � ��$"	 /ImagesForProject/basket.png��6C   5A   '   �� 5B   &    62   �� *	IsManager+ true6P   .a�5C   *   ��  � ��$"	 /ImagesForProject/report.png��6C   5D   '   5F      5H      ��5I      �� 5J      " ��6     5K      �� 5L   "    6.   �� *
IsClient+ true6K   .a�5M   &   ��  � ��
   Basket#	 Z
 6I   �� 5N   &    � y�$	 Visible=�6C   5O   #   �� 5P   "    6.   �� *	IsManager+ true6L   .a�5Q   &   ��  � ��   ReportsManager#	 Z 6I   �� 5R   &    � y�$	 Visible=�6C   5S   #   �� 5T   "    6.   �� *	IsCourier+ true6L   .a�5U   &   ��  � y�$	 	Collapsed=�6C   5V   #   5^      5a      �� 5b      $��2��6   $��80��6)   $��10q�64   
�������$��Right=�6S   ��5c      �� *UpdateCurrentViewModelCommand+��5d      �� 5e      " ��6     5f      �� 5h   "    6.   �� *
IsClient+ true6K   .a�5i   &   ��  � ��   OrderHistory#	 Z 6I   5j   #   �� 5k   "    6.   �� *	IsCourier+ true6L   .a�5l   &   ��  � ��   OrdersCourier#	 Z 6I   5m   #   �� 5n   "    6.   �� *	IsManager+ true6L   .a�5o   &   ��  � ��   OrdersManager#	 Z 6I   5p   #   5r      .��5t      �� $&�� /ImagesForProject/ordersicon.png��6   5u      �� 5v      $��4��6   $��80��6)   $��10q�64   
�������$��Right=�6S   ��5w      �� *UpdateCurrentViewModelCommand+.��5z      �� $#��/ImagesForProject/profile.png��6   ��5{      �� 5|      " ��6     5}      �� 5   "    6.   �� *
IsClient+ true6K   .a�5�   &   ��  � ��   Profile#	 Z 6I   5�   #   �� 5�   "    6.   �� *	IsCourier+ true6L   .a�5�   &   ��  � ��   ProfileCourier#	 Z 6I   5�   #   �� 5�   "    6.   �� *	IsManager+ true6L   .a�5�   &   ��  � ��   ProfileManager#	 Z 6I   5�   #   5�      5�      5�      5�      5�      5�      