   M S B A M L   `   `   `  ����H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  5      C&clr-namespace:PizzaDelivery.ViewModelsPizzaDelivery.ViewModels  5      +    %PizzaDelivery.Views.SelectedOrderView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      -local!clr-namespace:PizzaDelivery.Views  5      7
viewmodels&clr-namespace:PizzaDelivery.ViewModels  5        � 	Resources  5         listLinesTemplate �� CornerRadius � ColumnDefinitions � RowDefinitions �� Mode  listLinesPanelTemplate � Orientation��%'  &	        &	 �    �� 5   
   .R�5      �� $
��1200��6   $��5q�6%   $��2q�60   $ 10��6D   ._�5      �  5      �� 5      $
��auto �6+   �� 5      $
��auto �6+   �� 5      $
��auto �6+   �� 5      $
��auto �6+   �� 5      $
��auto �6+   �� 5      $
��auto �6+   �� 5      $
��auto �6+   �� 5      $
��auto �6+   �� 5      $
��auto �6+    5      �� 5       �� 5!      .+�5#      �� $��0��6   $��0��6*   $��50��6`   $��50��6k   $��5q�6w   ��6:   �� *Image+$ OneWay=�6w   �� 5$      $��5q�6    $��0��6+   $��1��69   $��X��6I   �� 5%      $��5q�6    $��0��6+   $��2��69   ��6I   �� *
Quantity+�� 5&      $��5q�6    $��0��6+   $��3��69   ��6I   �� *Size+�� 5'      $��5q�6    $��0��6+   $��4��69   ��6I   �� *Name+�� 5(      $��5q�6    $��0��6+   $��5��69   ��6I   �� *Price+�� 5)      $��5q�6    $��0��6+   $��6��69   $��руб��6I   �� 5*      $��5q�6    $��0��6+   $��7��69   ��6I   �� *Weight+�� 5+      $��5q�6    $��0��6+   $��8��68   $��г��6H   �� 5,      $��1��6    $��9��6-   ��6A   �� *
IngrList+5-      5/      50      �� 51   
   .R�52      � $ Vertical=�6   53      54      .��55      � ��57   
   �� 58       �� Color$ Black��6    �� Opacity$	 0.5Q�6,   .+�5:   
   � $	��900��6   $	��600��6   $��Center=�6.    5;      �� 5<      $
��auto �6#   �� 5=      $��* �6#   .+�5?      �� $��0��6   $��15q�6&    �� Padding$ 10q�62   $��Center=�5@      $��Center=�5A      $��3q�5B      $ 10��6!     BrushPrimary1#��[ 5C      
�������._�5G      � $	��800��6   $��5��6&   .+�5H      �� $��5��6   $��Disabled=�6+   $��Visible=�5I      #��[  5J      #��[ 5K      ��5L      �� *LinesCollection+	 �� SelectedItem	 5M   &   �� *SelectedLine+$ TwoWay=�5N      5O      5Q      �� 5R      
������ $
��Left=�6.   $	��Top=�6I   $��1��5S      $��50��6&   $��50��61   ��5T      �� *ExitCommand+.��5U      �� $��/ImagesForProject/out.png��6   5V      5W      5X      5Y      