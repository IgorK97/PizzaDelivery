   M S B A M L   `   `   `  ���� H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  2    ,PizzaDelivery.Views.OrderHistoryPresentation   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -local!clr-namespace:PizzaDelivery.Views    � 	Resources     orderlistTemplate �� CornerRadius �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value � RowDefinitions	 � ColumnDefinitions
 �� Binding �� Value  BaseButtonStyle  listorderlinesPanelTemplate � Orientation��%  &	        7  7  &	 �    �� .R��� $��Center=�$	��500��$	��400��$��10q�$��2q�$ 10������ " �� P�  �@J�IsMouseOver$
 True��. ���  � ��
 �  ����  � ��
 �����._��  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+�� $
��Left=�$��0��	 �� $
��auto ��� $
��auto �.+��� $��0��$��10 10q�$��
Номер��$��26(��� $��1��$��10 10q�$��26(����� *Number+�� $��1��$��10 10q�$��26(����� *	OrderDate+�� $��2��$��10 10q�$��26(����� *	Address+� $��3��	 �� $
��auto ��� $
��auto �.+��� $��0��$��Цена��$��10 10q�$��26(��� $��1��$��10 10q�$��26(����� *Cost+� $��4��	 �� $
��auto ��� $
��auto �.+��� $��0��$��Вес��$��10 10q�$��26(��� $��1��$��10 10q�$��26(����� *Weight+� $��5��	 �� $
��auto ��� $
��auto �.+��� $��0��$��Статус��$��10 10q�$��26(��� $��1��$��10 10q�$��26(����� *Status+� $��6������ " � �� 
 �� *IsDelivered+	 false.a���  � y�$ 	Collapsed=��� 
 �� *IsDelivered+ true.a���  � y�$ Visible=�.+��� $0��*Время окончания заказа��$��10 10q�$��26(��� $��10 10q�$��26(����� *DeliveryDate+� $��7������ " � �� 
 �� *
IsCanceled+ true.a���  � y�$ Visible=��� 
 �� *
IsCanceled+	 false.a���  � y�$ 	Collapsed=�.+��� $��Отменить��$��10 10q�$��26(�8��  ���� *CancelCommand+�� $��8��$��Подробнее��$��10 10q�$��26(�8�� ���� *
AboutOrder+�� .R�� $ Vertical=�.��� -    �Name$ 
LayoutRoot��.+�� -   $ Overlay�� K� ZIndex$
 1000������ " � �� 
 �� *IsOrderSelected+	 false.a���  � y�$ 	Collapsed=��� 
 �� *IsOrderSelected+ true.a���  � y�$ Visible=�.+�+   %PizzaDelivery.Views.SelectedOrderView  $��18(� � DataContext �� *WatchingOrder+� .+��� $��Center=�$��Disabled=�$��Visible=�#��[  #��[ ���� *OrderCollection+ �� SelectedItem �� *SelectedOrder+ �� Mode$ TwoWay=�