   M S B A M L   `   `   `  ���� H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  E AInterfaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-%clr-namespace:DTO;assembly=InterfacesDTO 2    ,PizzaDelivery.Views.OrderHistoryPresentation   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -local!clr-namespace:PizzaDelivery.Views  4statuses%clr-namespace:DTO;assembly=Interfaces    � 	Resources     orderlistTemplate �� CornerRadius �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value � RowDefinitions	 � ColumnDefinitions
 �� Binding �� Value  BaseButtonStyle �� BasedOn  DTO.DeliveryStatus   NotDelivered   	Delivered   AtTheCourier   Canceled   
HandedOver   IsBeingFormed   	IsCooking  listorderlinesPanelTemplate � Orientation��%�	  &	        7  7  7  &	 t	    �� .R��� $��Center=�$	��500��$	��500��$��10q�$��2q�$ 10������ " �� P�  �@J�IsMouseOver$
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
��auto �.+��� $��0��$��Цена, руб��$��10 10q�$��26(��� $��1��$��10 10q�$��26(����� *Cost+� $��4��	 �� $
��auto ��� $
��auto �.+��� $��0��$��
Вес, г��$��10 10q�$��26(��� $��1��$��10 10q�$��26(����� *Weight+� $��5��	 �� $
��auto ��� $
��auto �.+��� $��0��$��Статус��$��10 10q�$��26(��� $��1��$��10 10q�$��26(����� *Status+� $��6������ " � �� 
 �� *IsDelivered+	 false.a���  � y�$ 	Collapsed=��� 
 �� *IsDelivered+ true.a���  � y�$ Visible=�	 �� $
��auto ��� $
��auto �.+��� $��0��$!��Время доставки��$��10 10q�$��26(��� $��1��$��10 10q�$��26(����� *DeliveryDate+� $��7������ " � �� 
 �� *
IsCanceled+ true.a���  � y�$ Visible=��� 
 �� *
IsCanceled+	 false.a���  � y�$ 	Collapsed=�.+��� $��Отменить��$��10 10q�$��26(�8��  ���� *CancelCommand+�� $��8��$��Подробнее��$��10 10q�$��26(�8�� ���� *
AboutOrder+�� $��9��$1��+Посмотреть комментарий��$��10 10q�$��26(����� *
DelOrder+���� 8  " �� �� # Z 
 �� *OrderStatus+.a���  � ��# Z ��  � y�$ Visible=��� # Z 
 �� *OrderStatus+.a���  � y�$ 	Collapsed=��� # Z 
 �� *OrderStatus+.a���  � y�$ 	Collapsed=��� # Z 
 �� *OrderStatus+.a���  � y�$ 	Collapsed=��� # Z 
 �� *OrderStatus+.a���  � y�$ 	Collapsed=��� # Z 
 �� *OrderStatus+.a���  � y�$ 	Collapsed=��� # Z 
 �� *OrderStatus+.a���  � y�$ 	Collapsed=��� .R�� $ Vertical=�.��� -    �Name$ 
LayoutRoot��.+�� -   $ Overlay�� K� ZIndex$
 1000������ " � �� 
 �� *IsOrderSelected+	 false.a���  � y�$ 	Collapsed=��� 
 �� *IsOrderSelected+ true.a���  � y�$ Visible=�.+�+   %PizzaDelivery.Views.SelectedOrderView  $��18(� � DataContext �� *WatchingOrder+� -   $ Overlay1��$
 1000������ " � �� 
 �� *IsOrderCommented+	 false.a���  � y�$ 	Collapsed=��� 
 �� *IsOrderCommented+ true.a���  � y�$ Visible=�.+�%   PizzaDelivery.Views.CommentView   �� *SelectedOrderCommentVM+� -   $ Overlay2��$
 1000������ " � �� 
 �� *Notification+	 false.a���  � y�$ 	Collapsed=��� 
 �� *Notification+ true.a���  � y�$ Visible=�����  �� Color$ Black�� �� Opacity$	 0.5Q�.+�� $��Center=�$��Center=�
������� �� $
��auto ��� $
��auto �.+��� $��20(�$��10q�$��0��$X��RВы действительно хотите отменить этот заказ?��� $��1��	 �� �� .+��� $��25(�#��[ $
��Да��$��10q�$��Center=�$��30 10q����� *Cancel+�� $��25(�#��[ $��Нет��$��10q�$��1��$��Center=�$��30 10q����� *Close+� .+��� $��Center=�$��Disabled=�$��Visible=�#��[  #��[ ���� *OrderCollection+ �� SelectedItem �� *SelectedOrder+ �� Mode$ TwoWay=�