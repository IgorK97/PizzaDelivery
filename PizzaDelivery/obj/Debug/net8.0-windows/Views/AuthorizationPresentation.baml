   M S B A M L   `   `   `  ����H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  5      C&clr-namespace:PizzaDelivery.ViewModelsPizzaDelivery.ViewModels  5      3    -PizzaDelivery.Views.AuthorizationPresentation   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PizzaDelivery.Views     5      =
viewmodels&clr-namespace:PizzaDelivery.ViewModels     5      $��24(�5        � 	Resources  5         
LoginImage �� ImageSource j� Stretch��%c   &	        �� 5   
   $( "../ImagesForProject/LoginImage.jpg��6(   $ UniformToFill=�5      5      .��5      � #��[  6   .+�5   
   � -   5         �Name$ Overlay1��5       K� ZIndex$
 1000��6!   ��5      �� 5       �� 
TargetType" �6    �� Triggers 5      �� 5       �� Binding 6&   �� *Notification+ �� Value	 false6G   .a�5      �� 	 �� Property	 � y�
 �� Value$
 	Collapsed=�6;   5      �� 5       6&   �� *Notification+ true6G   .a�5      �� 	 � y�$
 Visible=�6;   5      5      ��5      �� 5        �� Color$ Black��6"    �� Opacity$	 0.5Q�60   .+�5"      � $��Center=�6   $��Center=�60   
������� � RowDefinitions 5$      �� 5%      $
��auto �6$   �� 5&      $
��auto �6$   .+�5(      �� $��20(�6   $��10q�6*   $��0��66   $=��7Неправильный логин или пароль��6C   �� 5)        BaseButtonStyle#��[ 6   $��Закрыть��6B   $��10q�5*      $��1��6%   $��Center=�62   ��5)   T   �� *Close+5*   2   5-      5.      �� 5/   
   $��25q�6    �� Padding$ 50q�6   $��Center=�50      $��Center=�51      $��3q�52       �� CornerRadius$ 10��6!     BrushPrimary1#��[ 53      
�������._�57      �  � IsSharedSizeScope$
 true��6    59      �� 5:      $
��auto �6$   �� 5;      $
��auto �6$   �� 5=      $
��auto �6$   .+�5@      �� $��0��6   $��40(�6)   $��Center=�67   $��Pizza Delivery��6T   �� 5A      $��1��6   $
��0 10q�6)   $��16(�67   $
��Thin"�5B      $��Center=�5C      $ ��Вход в аккаунт��65   � 5D      $��2��6   $
��0 10q�6$    5E      �� 5F      $
��auto �6(   �� 5G      $
��auto �6(   �� 5I      $
��auto �6(   .+�5L      � $��0��6   $
��0 10q�6(    � ColumnDefinitions 5M      �� 5N       z� SharedSizeGroup$ Label��6/   $
��auto �6G   �� 5O      $	��300 �6/   .+�5Q      �� $��0��6$   $��
Логин��64   �� 5R      $��20 0 0 0q�6"   $��1��64   ��6D   �� *	TextLogin+ �� UpdateSourceTrigger$ PropertyChanged=�5T      � 5U      $��1��6   $
��0 10q�6(    5V      �� 5W      $ Label��6/   $
��auto �6G   �� 5X      $	��300 �6/   .+�5[      �� $��0��6$   $��Пароль��64   G� 5\      -   5         G�Name$ 
pbPassword��5\   v   $��20 0 0 0q�6&   $��1��6f   6v   5^      �� 5a       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��2��6W   .+�5b      �� #��[ 5c      $��5q�5d      $��Center=�5e      $��Center=�5f      $��
Войти��5h      $
��20,3q�5i      ��5g      �� *LoginCommand+5i      �� 5j      $��5q�6!   #��[ 6-   $��Center=�5k      $��Center=�5l      $��Нет аккаунта?��5n      $
��20,3q�5o      ��5m      �� *ViewRegisterCommand+5o      5p      5q      5s      5v      5w      5x      