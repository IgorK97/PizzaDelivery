   M S B A M L   `   `   `  ���� H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  O,clr-namespace:PizzaDelivery.State.NavigatorsPizzaDelivery.State.Navigators  $    PizzaDelivery.Views.TopPanelPD   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:PizzaDelivery.Views     <nav,clr-namespace:PizzaDelivery.State.Navigators     .���   � RowDefinitions  �� $
��auto ��� $
��auto �.+��� $��0�� �� 
IsReadOnly$
 True��$��Пиццерия��$��30(�$
��Bold"�
���  ��$��10q�$
��Left=�� $��1�����	#FFEE3B3B$��80��.+��  � ColumnDefinitions �� $
��auto ��� $��* ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$��80��$��10q�
�������$
��Left=�-   'PizzaDelivery.State.Navigators.ViewType   Shop#��Z ���� *UpdateCurrentViewModelCommand+.���� $%��/ImagesForProject/pizzaicon.png������  �� 
TargetType" �� �� Triggers ��  �� Binding �� *
IsClient+ �� Value	 false.a���  �� Property � y�	 �� Value$	 	Collapsed=���  �� *
IsClient+ true.a���  � y�$	 Visible=��� $��3��$��80��$��10q�
�������$��Right=����� *UpdateCurrentViewModelCommand+.���� ���� " �� ��  �� *
IsClient+ true.a���  � ��$"	 /ImagesForProject/basket.png����  �� *	IsManager+ true.a���  � ��$"	 /ImagesForProject/report.png������ " �� ��  �� *
IsClient+ true.a���  � ��
   Basket#	 Z
 ��  � y�$	 Visible=���  �� *	IsManager+ true.a���  � ��   ReportsManager#	 Z ��  � y�$	 Visible=���  �� *	IsCourier+ true.a���  � y�$	 	Collapsed=��� $��2��$��80��$��10q�
�������$��Right=����� *UpdateCurrentViewModelCommand+���� " �� ��  �� *
IsClient+ true.a���  � ��   OrderHistory#	 Z ��  �� *	IsCourier+ true.a���  � ��   OrdersCourier#	 Z ��  �� *	IsManager+ true.a���  � ��   OrdersManager#	 Z .���� $&�� /ImagesForProject/ordersicon.png���� $��4��$��80��$��10q�
�������$��Right=����� *UpdateCurrentViewModelCommand+.���� $#��/ImagesForProject/profile.png������ " �� ��  �� *
IsClient+ true.a���  � ��   Profile#	 Z ��  �� *	IsCourier+ true.a���  � ��   ProfileCourier#	 Z ��  �� *	IsManager+ true.a���  � ��   ProfileManager#	 Z 