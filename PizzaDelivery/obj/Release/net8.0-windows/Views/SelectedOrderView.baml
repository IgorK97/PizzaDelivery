   M S B A M L   `   `   `  ���� H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  C&clr-namespace:PizzaDelivery.ViewModelsPizzaDelivery.ViewModels  +    %PizzaDelivery.Views.SelectedOrderView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -local!clr-namespace:PizzaDelivery.Views  7
viewmodels&clr-namespace:PizzaDelivery.ViewModels    � 	Resources     listLinesTemplate �� CornerRadius � ColumnDefinitions � RowDefinitions �� Mode  listLinesPanelTemplate � Orientation��%�  &	        &	 �    �� .R��� $
��1200��$��5q�$��2q�$ 10��._��  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � �� �� .+��� $��0��$��0��$��50��$��50��$��5q����� *Image+$ OneWay=��� $��5q�$��0��$��1��$��X���� $��5q�$��0��$��2������ *
Quantity+�� $��5q�$��0��$��3������ *Size+�� $��5q�$��0��$��4������ *Name+�� $��5q�$��0��$��5������ *Price+�� $��5q�$��0��$��6��$��руб���� $��5q�$��0��$��7������ *Weight+�� $��5q�$��0��$��8��$��г���� $��1��$��9������ *
IngrList+�� .R�� $ Vertical=�.��� ����  �� Color$ Black�� �� Opacity$	 0.5Q�.+�� $	��900��$	��600��$��Center=� �� $
��auto ��� $��* �.+��� $��0��$��15q� �� Padding$ 10q�$��Center=�$��Center=�$��3q�$ 10��  BrushPrimary1#��[ 
�������._�� $	��800��$��5��.+��� $��5��$��Disabled=�$��Visible=�#��[  #��[ ���� *LinesCollection+	 �� SelectedItem	 �� *SelectedLine+$ TwoWay=��� 
������ $
��Left=�$	��Top=�$��1��$��50��$��50������ *ExitCommand+.���� $��/ImagesForProject/out.png��