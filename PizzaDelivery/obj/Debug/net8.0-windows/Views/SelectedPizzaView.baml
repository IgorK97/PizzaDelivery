   M S B A M L   `   `   `  ����H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  5      C&clr-namespace:PizzaDelivery.ViewModelsPizzaDelivery.ViewModels  5      +    %PizzaDelivery.Views.SelectedPizzaView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      -local!clr-namespace:PizzaDelivery.Views  5      7
viewmodels&clr-namespace:PizzaDelivery.ViewModels  5        � 	Resources  5         listIngrTemplate �� CornerRadius �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value J� InputBindings	 d� MouseAction
 �� Command �� Path �� RelativeSource �� AncestorType �� Mode �� CommandParameter �� Mode  listIngrPanelTemplate��%/  &	        &	 �    �� 5   
   .R�5      �� $	��200��6   $	��150��6!   $
��1000��6.   $��5q�6>   $ 10��6I   ��5      �� 5      " ��6    5      �� 5       6*   �� *IsIngredientSelected+	 false6S   .a�5   "   ��  � ��
 �����6?   5      �� 5       6*   �� *IsIngredientSelected+ true6S   .a�5   "   ��  � ��
 � ���6?   5      �� 5       6*   �� *
IsActive+	 false6G   .a�5   "   ��  � ��
 �����6@   �� 5   "    � ��$ 10q�6D   5      �� 5       6*   �� *
IsActive+ true6G   .a�5   "   ��  � ��
 �����6@   �� 5   "    � ��$ 2q�6D   5       5"       5$      d� 5%      $	 	LeftClicke�6#   
 5&      �� $) #DataContext.SelectIngredientCommand� ��  UserControl$ FindAncestor=� 5(      �� *Id+._�5*      �� .+�5+      �� $��50��6B   $��50��6M   $��5q�6Y   ��6   �� *Image+$ OneWay=�6Y   �� 5-      $��Center=�6C   $��16(�6`   $
��Bold"�6n   ��6    �� *Name+$ OneWay=�6n   �� 5.      $��Center=�6C   $��16(�5/      ��5.       �� *Cost+$ OneWay=�5/      �� 50      $��руб��6    $��Center=�6+   $��14(�6H   51      53      54      �� 55   
   .R�56      � 57      58      .��59      � ��5:   
   �� 5;       �� Color$ Black��6    �� Opacity$	 0.5Q�6,   .+�5=   
   �� $
��Auto=�6   $
��Auto=�6<   .��5>      � $	��300��6   $	��300��6"   $��Center=�62    � ColumnDefinitions 5?      �� 5@      $
��auto �6'   �� 5A      $��* �6'   .+�5C      �� $��0��6   $��10q�6*    �� Padding$ 10q�66   $��Center=�5D      $��Center=�5E      $��3q�5F      $ 10��6!     BrushPrimary1#��[ 5G      
�������._�5J      �  5K      �� 5L      �� 5M      .+�5P      � $��0��6   .+�5Q      � $��Center=�6#   $��Center=�6>    � RowDefinitions 5R   "   �� 5S   &   �� 5T   &   .+�5V   "   �� $��UniformToFill=�6(   $	��200��6@   $	��200��6O   $��0��6x   ��6_   �� *Image+6x   � 5W   "   $
��5 10q�6'   $��1��65    5X   &   �� 5Y   *   �� 5Z   *    5]   &   �� 5^   *   �� 5_   *   .+�5b   &   �� $��18(�60   $��0��6>   $��0��6N   $
��5 10q�6\   $��Center=�6j   $��Center=�5c   (   $��
Вес, г��6C   �� 5d   &   $��18(�60   $��1��6>   $��0��6N   $
��5 10q�6\   $��Center=�6j   $��Center=�5e      ��6'   �� *FinalWeight+�� 5f   &   $��18(�60   $��0��6>   $��1��6N   $
��5 10q�6\   $��Center=�6j   $��Center=�5g      $��Цена, руб��68   �� 5h   &   $��18(�60   $��1��6>   $��1��6N   $
��5 10q�6\   $��Center=�6j   $��Center=�5i      ��6   �� *Price+5j   #   5k      5l      � 5m      $	��600��6   $	��Top=�6/   $��1��6G    5n      �� 5o   "   $
��auto �60   �� 5p   "   $
��auto �60   �� 5q   "   $
��auto �60   �� 5r   "   $
��auto �60   �� 5s   "   $
��auto �60   �� 5t   "   $��* �60   �� 5u   "   $
��auto �60   .+�5w      �� $
��5 10q�6(   $��Center=�66   $��30(�6S   $��0��6b   ��6o   �� *Name+�� 5x      $��1��6+   $��Disabled=�68   $
��Auto=�5y   '   .��5z   "   �� $
��Wrap=�5{   $   $	��500��68   $
��5 10q�6G   $��16(�5|   $   ��63   �� *Description+5}      � 5~      $
��5 10q�6$   $��2��62   
���  �� 5   "   �� 5�   &   �� 5�   &   �� 5�   &   .+�5�   "   	� $��18(�6.   $��0��6<    
 RadBut#��[ 5�   *   )   #PizzaDelivery.ViewModels.PizzaSizes   Small#��Z 5�   &   $��Маленькая��5�   &    d� 	IsChecked 5�   *   �� *	IsSmall+$ OneWay=���5�   &   �� *UpdatePizzaSizeCommand+5�   &   	� 5�   "   $��18(�6.   $��1��6<   #��[ 5�   *      Medium#��Z 5�      $��Средняя��5�       5�   *   �� *
IsMedium+$ OneWay=���5�      �� *UpdatePizzaSizeCommand+5�      	� 5�   "   $��18(�6.   $��2��6<   #��[ 5�   *      Large#��Z 5�      $��Большая��5�       5�   *   �� *	IsLarge+$ OneWay=���5�      �� *UpdatePizzaSizeCommand+5�      5�      � 5�      $��3��6#    5�   "   �� 5�   &   �� 5�   &   .+�5�   "   �� $
��5 10q�6,   $��18(�6:   $��0��6H   $��Количество��6X   %  Xceed.Wpf.Toolkit.IntegerUpDown  5�   "   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Minimum 15�   !      Maximum 106-   $��10 10 10 10q�5�   F   $��1��6[   $	��200��6k      Value 6!   �� *Count+$ TwoWay=�6k   5�      �� 5�      $��4��6(   $
��5 10q�65   $��18(�6C   $&�� Добавить по вкусу��6Q   � 5�      $	��800��6#   $��5��62   .+�5�   "   �� $��5��6*   $��Disabled=�67   $��Visible=�5�      #��[  5�      #��[ 5�      ��5�      �� *IngredientCollection+ �� SelectedItem 5�   &   �� *SelectedIngredient+$ TwoWay=�5�   #   5�      �� 5�      $��6��6%   $��5q�62   $��Center=�6=   $��Center=�5�   !   $��18(�6<     BaseButtonStyle#��[ 5�   "   $��В корзину��5�   "   $
��20,3q�66   ��5�      �� *BuyPizzaCommand+5�   6   5�      5�      5�      �� 5�      
������ $
��Left=�62   $	��Top=�6M   $��1��5�      $��50��6&   $��50��61   #��[ 5�      ��5�      �� *ExitCommand+.��5�      �� $��/ImagesForProject/out.png��6   5�      5�      5�      5�      5�      