   M S B A M L   `   `   `  ���� H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  R Nnetstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd514)clr-namespace:System;assembly=netstandardSystem ,    &PizzaDelivery.Views.BasketPresentation   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:PizzaDelivery.Views     X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  2s1)clr-namespace:System;assembly=netstandard    � 	Resources     listlinesTemplate �� CornerRadius �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� Binding	 �� Mode
 �� Value � ColumnDefinitions  BaseButtonStyle%  Xceed.Wpf.Toolkit.IntegerUpDown�  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Minimum   Maximum   Value �� UpdateSourceTrigger  listlinesPanelTemplate � Orientation��%0  &	        7  7  &	 �    �� .R��� $	��220��$��10q�$��2q�$ 10������ " �� P�  �@J�IsMouseOver$
 True��. ���  � ��
 �  ����  �� *
IsActive+$	 OneWay=�	
 False.a���  � ��
 �������  �� *
IsActive+$	 OneWay=�
 True.a���  � ��
 �����._��  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$	��200��$	��200��$��10q����� *Image+$	 OneWay=��� $��1��$��Center=�$��Center=�$��26(����� *Name+$	 OneWay=��� $��2��$��Цена, руб��$��10 10q�$��Center=�$��Center=�$��26(��� $��3��$��Center=�$��Center=�$��26(����� *Price+�� $��4��$��
Вес, г��$��10 10q�$��Center=�$��Center=�$��26(��� $��5��$��Center=�$��10 10 q�$��26(����� *Weight+�� 8��  $��10 10 10 10q�$	��200��$	��100��$��7��$��Center=�$��Center=�$��26(�$��Изменить������ *UpdateYourself+  $��50��$��8��$��22(� 1 10$��10 10q�$	��100�� �� *
Quantity+$	 TwoWay=�$ PropertyChanged=��� 8�� $��50��$��50��$��9������ *DeleteYourself+.���� $��/ImagesForProject/out.png���� .R�� $ Vertical=�.��� -    �Name$ 
LayoutRoot��.+�� -   $ Overlay�� K� ZIndex$
 1000������ " � ��  �� *IsPizzaSelected+	
 false.a���  � y�$ 	Collapsed=���  �� *IsPizzaSelected+
 true.a���  � y�$ Visible=�.+�+   %PizzaDelivery.Views.SelectedPizzaView   � DataContext �� *AddingPizza+� -   $ Overlay1��$
 1000������ " � ��  �� *Confirmation+	
 false.a���  � y�$ 	Collapsed=���  �� *Confirmation+
 true.a���  � y�$ Visible=�����  �� Color$ Black�� �� Opacity$	 0.5Q�.+�� $��Center=�$��Center=�
������� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��20(�$��10q�$��0��$7��1Вы согласны оформить заказ��� $��1�� �� $
��auto ��� $
��auto ��� $
��auto �.+��� $��20(�$��0��$��10q�$��на сумму���� $��20(�$��1��$��10q����� *Price+�� $��20(�$��2��$��10q�$��рублей?��� $��2�� �� $
��auto ��� $
��auto �.+��� $��20(�$��10q�$��0��$"��Адрес доставки:���� $��20(�$��1��$��10q����� *	Address+� $��Center=�$��3�� �� $
��auto ��� $
��auto �.+��� $��30��#��[ $��0��$
��Да������ *ConfirmCommand+����True���� #��[ $��1��$��Нет��$��10q����� *ConfirmCommand+����	False���  �� $
��auto ��� $��* ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��24(�$
��Bold"�$��0������ *	Message+���� " �� ��  �� *IsMessageActive+
 true.a���  � y�$ Visible=���  �� *IsMessageActive+	
 false.a���  � y�$ 	Collapsed=��� $��1��$��Stretch=�$
��Auto=�$��Visible=�#��[  #��[ ���� *LinesCollection+ �� SelectedItem �� *SelectedLine+$	 TwoWay=�� $��2�� �� $
��auto ��� $
��auto �.+��� $��10 10q�$��20(�$*��$Общий вес заказа, г: ��$��0��$��Right=��� $��10 10q�$��20(�$��Right=�$��1������ *Weight+� $��3�� �� $
��auto ��� $
��auto �.+��� $��10 10q�$��20(�$6��0Итоговая цена заказа, руб: ��$��0��$��Right=��� $��10 10q�$��20(�$��Right=�$��1������ *Price+� $��4�� �� $
��auto ��� $
��auto �.+��� $��10 10q�$��20(�$2��,Введите адрес доставки: ��$��0��$��Right=��� $��10 10q�$	��150��$��20(�$��Right=�$��1������ *	Address+$ PropertyChanged=��� $��5��$��5q�$��Center=�#��[ $��Center=�$��26(�$��Заказать��$
��20,3q����� *SubmitCommand+