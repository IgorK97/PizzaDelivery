   M S B A M L   `   `   `  ����H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  5      C&clr-namespace:PizzaDelivery.ViewModelsPizzaDelivery.ViewModels  5      3    -PizzaDelivery.Views.AuthorizationPresentation   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PizzaDelivery.Views     5      =
viewmodels&clr-namespace:PizzaDelivery.ViewModels     5      $��24(�5        � 	Resources  5         
LoginImage �� ImageSource j� Stretch��%c   &	        �� 5   
   $( "../ImagesForProject/LoginImage.jpg��6(   $ UniformToFill=�5      5      .��5      � #��[  6   .+�5   
   �� $��25q�6    �� Padding$ 50q�6   $��Center=�5      $��Center=�5      $��3q�5       �� CornerRadius$ 10��6!     BrushPrimary1#��[ 5      
�������._�5      �  � IsSharedSizeScope$
 true��6    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5       $
��auto �6$   .+�5#      �� $��0��6   $��40(�6)   $��Center=�67   $��Pizza Delivery��6T   �� 5$      $��1��6   $
��0 10q�6)   $��16(�67   $
��Thin"�5%      $��Center=�5&      $ ��Вход в аккаунт��65   � 5'      $��2��6   $
��0 10q�6$    5(      �� 5)      $
��auto �6(   �� 5*      $
��auto �6(   �� 5,      $
��auto �6(   .+�5/      � $��0��6   $
��0 10q�6(    � ColumnDefinitions 50      �� 51       z� SharedSizeGroup$ Label��6/   $
��auto �6G   �� 52      $	��300 �6/   .+�54      �� $��0��6$   $��
Логин��64   �� 55      $��20 0 0 0q�6"   $��1��64   ��6D   �� *	TextLogin+	 �� UpdateSourceTrigger$	 PropertyChanged=�57      � 58      $��1��6   $
��0 10q�6(    59      �� 5:      $ Label��6/   $
��auto �6G   �� 5;      $	��300 �6/   .+�5>      �� $��0��6$   $��Пароль��64   G� 5?      -   5        
 G�Name$
 
pbPassword��5?   v   $��20 0 0 0q�6&   $��1��6f   6v   5A      �� 5D       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��2��6W   .+�5E      ��   BaseButtonStyle#��[ 5F      $��5q�5G      $��Center=�5H      $��Center=�5I      $��
Войти��5K      $
��20,3q�5L      ��5J      �� *LoginCommand+5L      �� 5M      $��5q�6!   #��[ 6-   $��Center=�5N      $��Center=�5O      $��Нет аккаунта?��5Q      $
��20,3q�5R      ��5P      �� *ViewRegisterCommand+5R      5S      5T      5V      5Y      5Z      5[      