   M S B A M L   `   `   `  ���� H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  E AInterfaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-%clr-namespace:DTO;assembly=InterfacesDTO 3    -PizzaDelivery.Views.OrdersCourierPresentation   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:PizzaDelivery.Views     X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  4statuses%clr-namespace:DTO;assembly=Interfaces  $��18(�  � 	Resources     listordersTemplate �� CornerRadius �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value � ColumnDefinitions	 �� Mode
 �� Binding �� Value  BaseButtonStyle �� BasedOn  DTO.DeliveryStatus   
HandedOver   AtTheCourier   	Delivered   IsBeingFormed   Canceled   	IsCooking   NotDelivered  listordersPanelTemplate � Orientation��%�	  &	        7  7  &	 �	    �� .R��� $	��220��$��10q�$��2q�$ 10������ " �� P�  �@J�IsMouseOver$
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
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$��Center=�$��Center=����� *Number+$	 OneWay=��� $��1��$��Время заказа��$��10 10q�$��Center=�$��Center=��� $��2��$��Center=�$��Center=����� *	OrderDate+�� $��3��$��
Адрес��$��10 10q�$��Center=�$��Center=��� $��4��$��Center=�$��10 10 q����� *	Address+�� $��5��$!��Время доставки��$��Center=�$��10 10 q����� " �� �� 
 �� *IsDelivered+ true.a���  � y�$ Visible=��� 
 �� *IsDelivered+	 false.a���  � y�$ 	Collapsed=��� $��6��$��Center=�$��10 10 q����� *DeliveryDate+���� " �� �� 
 �� *IsDelivered+ true.a���  � y�$ Visible=��� 
 �� *IsDelivered+	 false.a���  � y�$ 	Collapsed=��� $��7��$��Цена��$��Center=�$��10 10 q��� $��8��$��Center=�$��10 10 q����� *Cost+�� $��9��$��руб��$��Center=�$��10 10 q��� $��10��$��Вес��$��Center=�$��10 10 q��� $��11��$��Center=�$��10 10 q����� *Weight+�� $��12��$��г��$��Center=�$��10 10 q��� 8��  $
��auto��$��50��$��13��$��Center=�$��Center=�$��Подробнее������ *
AboutOrder+�� $��5q�$
��auto��$��50��$��14������ " ��8   �� # Z 
 �� *OrderStatus+.a���  � ��$ Принять заказ����  � �� �� *	TakeOrder+��  � ��# Z �� # Z 
 �� *OrderStatus+.a���  � ��$, &Пометить по доставке����  � �� �� *
DelOrder+��  � ��# Z �� # Z 
 �� *OrderStatus+.a���  � y�$ 	Collapsed=��� # Z 
 �� *OrderStatus+.a���  � y�$ 	Collapsed=��� # Z 
 �� *OrderStatus+.a���  � y�$ 	Collapsed=��� # Z 
 �� *OrderStatus+.a���  � y�$ 	Collapsed=��� # Z 
 �� *OrderStatus+.a���  � ��$1 +Посмотреть комментарий����  � �� �� *
DelOrder+��  � ��# Z �� .R�� $ Vertical=�.��� -    �Name$ 
LayoutRoot��.+�� -   $ Overlay�� K� ZIndex$
 1000������ " � �� 
 �� *IsOrderSelected+	 false.a���  � y�$ 	Collapsed=��� 
 �� *IsOrderSelected+ true.a���  � y�$ Visible=�.+�+   %PizzaDelivery.Views.SelectedOrderView   � DataContext �� *SelectedOrderVM+� -   $ Overlay1��$
 1000������ " � �� 
 �� *IsOrderCommented+	 false.a���  � y�$ 	Collapsed=��� 
 �� *IsOrderCommented+ true.a���  � y�$ Visible=�.+�%   PizzaDelivery.Views.CommentView   �� *SelectedOrderCommentVM+�  � RowDefinitions �� $
��auto ��� $��* �.+�� $
��5 10q�$��0��
���  �� �� �� �� �� �� .+�	� $��18(�$��0�� 
 RadBut#��[ #��Z $#��Ожидают курьера�� d� 	IsChecked �� *
HandedOver+$	 OneWay=����� *SelectStatus+	� $��18(�$��1��#��[ #��Z $��В доставке�� �� *AtTheCourier+$	 OneWay=����� *SelectStatus+	� $��18(�$��2��#��[ #��Z $��Доставленные�� �� *	Delivered+$	 OneWay=����� *SelectStatus+	� $��18(�$��3��#��[ #��Z $#��Не доставленные�� �� *NotDelivered+$	 OneWay=����� *SelectStatus+	� $��18(�$��4��#��[ #��Z $��Отмененные�� �� *
Canceled+$	 OneWay=����� *SelectStatus+�� $��1��$��Stretch=�$
��Auto=�$��Visible=�#��[  #��[ ���� *OrdersCollection+ �� SelectedItem �� *SelectedOrder+$	 TwoWay=�