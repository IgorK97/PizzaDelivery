   M S B A M L   `   `   `  ���� H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  C&clr-namespace:PizzaDelivery.ViewModelsPizzaDelivery.ViewModels  3    -PizzaDelivery.Views.AuthorizationPresentation   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:PizzaDelivery.Views     =
viewmodels&clr-namespace:PizzaDelivery.ViewModels     $��24(�  � 	Resources     
LoginImage �� ImageSource j� Stretch��%L   &	        �� $( "../ImagesForProject/LoginImage.jpg��$ UniformToFill=�.��� #��[  .+��� $��25q� �� Padding$ 50q�$��Center=�$��Center=�$��3q� �� CornerRadius$ 10��  BrushPrimary1#��[ 
�������._��  � IsSharedSizeScope$
 true�� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$��40(�$��Center=�$��Pizza Delivery���� $��1��$
��0 10q�$��16(�$
��Thin"�$��Center=�$ ��Вход в аккаунт��� $��2��$
��0 10q� �� $
��auto ��� $
��auto ��� $
��auto �.+�� $��0��$
��0 10q� � ColumnDefinitions ��  z� SharedSizeGroup$ Label��$
��auto ��� $	��300 �.+��� $��0��$��
Логин���� $��20 0 0 0q�$��1������ *	TextLogin+	 �� UpdateSourceTrigger$	 PropertyChanged=�� $��1��$
��0 10q� �� $ Label��$
��auto ��� $	��300 �.+��� $��0��$��Пароль��G� -   
 G�Name$
 
pbPassword��$��20 0 0 0q�$��1����  �� Orientation$ 
Horizontal=�$��Center=�$��2��.+���   BaseButtonStyle#��[ $��5q�$��Center=�$��Center=�$��
Войти��$
��20,3q����� *LoginCommand+�� $��5q�#��[ $��Center=�$��Center=�$��Нет аккаунта?��$
��20,3q����� *ViewRegisterCommand+