   M S B A M L   `   `   `  ���� H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  C&clr-namespace:PizzaDelivery.ViewModelsPizzaDelivery.ViewModels  +    %PizzaDelivery.Views.SelectedPizzaView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  :d2http://schemas.microsoft.com/expression/blend/2008  -local!clr-namespace:PizzaDelivery.Views  7
viewmodels&clr-namespace:PizzaDelivery.ViewModels    � 	Resources     listIngrTemplate �� CornerRadius �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value J� InputBindings	 d� MouseAction
 �� Command �� Path �� RelativeSource �� AncestorType �� Mode �� CommandParameter �� Mode  listIngrPanelTemplate��%*  &	        &	 	    �� .R��� $	��200��$	��150��$
��1000��$��5q�$ 10������ " �� ��  �� *IsIngredientSelected+	 false.a���  � ��
 �������  �� *IsIngredientSelected+ true.a���  � ��
 � �����  �� *
IsActive+	 false.a���  � ��
 �������  � ��$ 10q���  �� *
IsActive+ true.a���  � ��
 �������  � ��$ 2q� d� $	 	LeftClicke�
 �� $) #DataContext.SelectIngredientCommand� ��  UserControl$ FindAncestor=� �� *Id+._��� .+��� $��50��$��50��$��5q����� *Image+$ OneWay=��� $��Center=�$��16(�$
��Bold"����� *Name+$ OneWay=��� $��Center=�$��16(����� *Cost+$ OneWay=��� $��руб��$��Center=�$��14(��� .R�� .��� ����  �� Color$ Black�� �� Opacity$	 0.5Q�.+��� $
��Auto=�$
��Auto=�.��� $	��300��$	��300��$��Center=� � ColumnDefinitions �� $
��auto ��� $��* �.+��� $��0��$��10q� �� Padding$ 10q�$��Center=�$��Center=�$��3q�$ 10��  BrushPrimary1#��[ 
�������._��  �� �� .+�� $��0��.+�� $��Center=�$��Center=� � RowDefinitions �� �� .+��� $��UniformToFill=�$	��200��$	��200��$��0������ *Image+� $
��5 10q�$��1�� �� ��  �� �� .+��� $��18(�$��0��$��0��$
��5 10q�$��Center=�$��Center=�$��
Вес, г���� $��18(�$��1��$��0��$
��5 10q�$��Center=�$��Center=����� *FinalWeight+�� $��18(�$��0��$��1��$
��5 10q�$��Center=�$��Center=�$��Цена, руб���� $��18(�$��1��$��1��$
��5 10q�$��Center=�$��Center=����� *Price+� $	��600��$	��Top=�$��1�� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* ��� $
��auto �.+��� $
��5 10q�$��Center=�$��30(�$��0������ *Name+�� $��1��$��Disabled=�$
��Auto=�.���� $
��Wrap=�$	��500��$
��5 10q�$��16(����� *Description+� $
��5 10q�$��2��
���  �� �� �� �� .+�	� $��18(�$��0�� 
 RadBut#��[ )   #PizzaDelivery.ViewModels.PizzaSizes   Small#��Z $��Маленькая�� d� 	IsChecked �� *	IsSmall+$ OneWay=����� *UpdatePizzaSizeCommand+	� $��18(�$��1��#��[    Medium#��Z $��Средняя�� �� *
IsMedium+$ OneWay=����� *UpdatePizzaSizeCommand+	� $��18(�$��2��#��[    Large#��Z $��Большая�� �� *	IsLarge+$ OneWay=����� *UpdatePizzaSizeCommand+� $��3�� �� �� .+��� $
��5 10q�$��18(�$��0��$��Количество��%  Xceed.Wpf.Toolkit.IntegerUpDown  �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Minimum 1   Maximum 10$��10 10 10 10q�$��1��$	��200��   Value �� *Count+$ TwoWay=��� $��4��$
��5 10q�$��18(�$&�� Добавить по вкусу��� $	��800��$��5��.+��� $��5��$��Disabled=�$��Visible=�#��[  #��[ ���� *IngredientCollection+ �� SelectedItem �� *SelectedIngredient+$ TwoWay=��� $��6��$��5q�$��Center=�$��Center=�$��18(�  BaseButtonStyle#��[ $��В корзину��$
��20,3q����� *BuyPizzaCommand+�� 
������ $
��Left=�$	��Top=�$��1��$��50��$��50��#��[ ���� *ExitCommand+.���� $��/ImagesForProject/out.png��